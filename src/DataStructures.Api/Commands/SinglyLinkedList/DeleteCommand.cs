using DataStructures.Api.Common;
using Microsoft.AspNetCore.Http;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Api.Commands.SinglyLinkedList
{
    public class DeleteCommand<T> : Command<Result<bool>>
    {
        private readonly string key;
        private readonly T data;
        private readonly bool deleteFromHead;
        private readonly ConnectionMultiplexer redis;

        public DeleteCommand(string key, T data, bool deleteFromHead)
        {
            this.key = key;
            this.data = data;
            this.deleteFromHead = deleteFromHead;
            this.redis = ConnectionMultiplexer.Connect(Constants.RedisConfig);
        }

        public override async Task<Result<bool>> ExecuteAsync()
        {
            try
            {
                var database = this.redis.GetDatabase();
                var list = await new RetrieveCommand<T>(this.key).ExecuteAsync();
                if(this.deleteFromHead)
                {
                    list.Data.DeleteHead();
                }
                else if(this.data != null)
                {
                    list.Data.Delete(this.data);
                }
                else
                {
                    list.Data.DeleteTail();
                }
                var updateResponse = await new UpdateCommand<T>(this.key, list.Data).ExecuteAsync();
                return new Result<bool>(
                    (!updateResponse.IsError) ? true : false,
                    (updateResponse.StatusCode.Equals(StatusCodes.Status201Created)) ? StatusCodes.Status200OK : updateResponse.StatusCode,
                    (updateResponse.IsError) ? true : false,
                    (updateResponse.ErrorMessage is null) ? null : updateResponse.ErrorMessage
                );
            }
            catch(Exception ex)
            {
                return new Result<bool>(
                    false,
                    StatusCodes.Status500InternalServerError,
                    true,
                    ex.Message
                );
            }
        }
    }
}
