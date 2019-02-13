using DataStructures.Api.Common;
using Microsoft.AspNetCore.Http;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Api.Commands.SinglyLinkedList
{
    public class InsertCommand<T> : Command<Result<bool>>
    {
        private readonly string key;
        private readonly T data;
        private readonly bool insertAtHead;
        private readonly int index;
        private readonly ConnectionMultiplexer redis;

        public InsertCommand(string key, T data, bool insertAtHead, int index)
        {
            this.key = key;
            this.data = data;
            this.insertAtHead = insertAtHead;
            this.index = index;
            this.redis = ConnectionMultiplexer.Connect(Constants.RedisConfig);
        }

        public override async Task<Result<bool>> ExecuteAsync()
        {
            try
            {
                var database = this.redis.GetDatabase();
                var list = await new RetrieveCommand<T>(this.key).ExecuteAsync();
                if (list.IsError)
                {
                    return new Result<bool>(
                        false,
                        list.StatusCode,
                        true,
                        list.ErrorMessage
                    );
                }
                if(this.insertAtHead)
                {
                    list.Data.InsertHead(this.data);
                }
                else if(this.index != -1)
                {
                    list.Data.InsertAt(this.index, this.data);
                }
                else
                {
                    list.Data.InsertTail(this.data);
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
