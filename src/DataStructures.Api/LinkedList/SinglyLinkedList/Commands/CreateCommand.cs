using DataStructures.Api.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using DataStructures.Core.LinkedList.SinglyLinkedList;
using Newtonsoft.Json;

namespace DataStructures.Api.LinkedList.SinglyLinkedList.Commands
{
    public class CreateCommand<T> : Command<Result<string>>
    {
        private readonly ConnectionMultiplexer redis;

        public CreateCommand()
        {
            this.redis = ConnectionMultiplexer.Connect(Constants.RedisHost);
        }

        public override async Task<Result<string>> ExecuteAsync()
        {
            try
            {
                var database = this.redis.GetDatabase();
                var key = new Guid().ToString();
                var response = await database.StringSetAsync(key, JsonConvert.SerializeObject(new SinglyLinkedList<T>()));
                return new Result<string>(
                    (response) ? key.ToString() : null,
                    (response) ? StatusCodes.Status201Created : StatusCodes.Status400BadRequest,
                    (response) ? false : true,
                    (response) ? null : Constants.UnableToSetErrorMessage
                );
            }
            catch(Exception ex)
            {
                return new Result<string>(
                    null,
                    StatusCodes.Status500InternalServerError,
                    true,
                    ex.Message
                );
            }
        }
    }
}
