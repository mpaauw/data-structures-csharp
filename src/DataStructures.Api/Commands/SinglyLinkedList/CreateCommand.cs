using DataStructures.Api.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using DataStructures.Core.LinkedList.SinglyLinkedList;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;


namespace DataStructures.Api.Commands.SinglyLinkedList
{
    public class CreateCommand<T> : Command<Result<string>>
    {
        public object List { get; set; }

        private readonly IConnectionMultiplexer redis;

        public CreateCommand()
        {
        }

        public CreateCommand(IConnectionMultiplexer redis)
        {
            this.redis = redis;
        }

        public override async Task<Result<string>> ExecuteAsync()
        {
            try
            {
                var database = this.redis.GetDatabase();
                var key = CommandHelper.BuildRedisKey(nameof(SinglyLinkedList));
                var response = await database.StringSetAsync(key, JsonConvert.SerializeObject(this.List));
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
