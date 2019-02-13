using DataStructures.Api.Common;
using Microsoft.AspNetCore.Http;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Api.LinkedList.SinglyLinkedList.Commands
{
    public class RemoveCommand : Command<Result<string>>
    {
        private readonly string key;
        private readonly ConnectionMultiplexer redis;

        public RemoveCommand(string key)
        {
            this.key = key;
            this.redis = ConnectionMultiplexer.Connect(Constants.RedisConfig);
        }

        public override async Task<Result<string>> ExecuteAsync()
        {
            try
            {
                var database = this.redis.GetDatabase();
                var response = await database.KeyDeleteAsync(this.key);
                return new Result<string>(
                    null,
                    (response) ? StatusCodes.Status200OK : StatusCodes.Status404NotFound,
                    (response) ? false : true,
                    (response) ? null : Constants.KeyNotFoundErrorMessage
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
