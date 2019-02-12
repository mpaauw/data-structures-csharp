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
    public class UpdateCommand<T> : Command<Result<string>>
    {
        private readonly string key;
        private readonly ISinglyLinkedList<T> list;
        private readonly ConnectionMultiplexer redis;

        public UpdateCommand(string key, ISinglyLinkedList<T> list)
        {
            this.key = key;
            this.list = list;
            this.redis = ConnectionMultiplexer.Connect(Constants.RedisHost);
        }

        public override async Task<Result<string>> ExecuteAsync()
        {
            try
            {
                var database = this.redis.GetDatabase();
                var response = await database.StringSetAsync(this.key, JsonConvert.SerializeObject(this.list));
                return new Result<string>(
                    (response) ? this.key : null,
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
