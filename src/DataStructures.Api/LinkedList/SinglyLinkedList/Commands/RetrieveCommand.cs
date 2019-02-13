using DataStructures.Api.Common;
using DataStructures.Core.LinkedList.SinglyLinkedList;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Api.LinkedList.SinglyLinkedList.Commands
{
    public class RetrieveCommand<T> : Command<Result<SinglyLinkedList<T>>>
    {
        private readonly string key;
        private readonly ConnectionMultiplexer redis;

        public RetrieveCommand(string key)
        {
            this.key = key;
            this.redis = ConnectionMultiplexer.Connect(Constants.RedisConfig);
        }

        public override async Task<Result<SinglyLinkedList<T>>> ExecuteAsync()
        {
            try
            {
                var database = this.redis.GetDatabase();
                var response = await database.StringGetAsync(this.key);
                return new Result<SinglyLinkedList<T>>(
                    (!response.Equals(RedisValue.Null)) ? JsonConvert.DeserializeObject<SinglyLinkedList<T>>(response) : null,
                    (!response.Equals(RedisValue.Null)) ? StatusCodes.Status200OK : StatusCodes.Status404NotFound,
                    (!response.Equals(RedisValue.Null)) ? false : true,
                    (!response.Equals(RedisValue.Null)) ? null : Constants.KeyNotFoundErrorMessage
                );
            }
            catch(Exception ex)
            {
                return new Result<SinglyLinkedList<T>>(
                    null,
                    StatusCodes.Status500InternalServerError,
                    true,
                    ex.Message
                );
            }
        }
    }
}
