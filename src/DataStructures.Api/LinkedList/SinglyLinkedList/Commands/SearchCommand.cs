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
    public class SearchCommand<T> : Command<Result<int>>
    {
        private readonly string key;
        private readonly T data;
        private readonly ConnectionMultiplexer redis;

        public SearchCommand(string key, T data)
        {
            this.key = key;
            this.data = data;
            this.redis = ConnectionMultiplexer.Connect(Constants.RedisHost);
        }

        public override async Task<Result<int>> ExecuteAsync()
        {
            try
            {
                var database = this.redis.GetDatabase();
                var list = await new RetrieveCommand<T>(this.key).ExecuteAsync();
                if(list.IsError)
                {
                    return new Result<int>(
                        Int32.MinValue,
                        list.StatusCode,
                        true,
                        list.ErrorMessage
                    );
                }
                int searchResult = list.Data.Search(this.data);
                return new Result<int>(
                    searchResult,
                    (searchResult != -1) ? StatusCodes.Status200OK : StatusCodes.Status404NotFound,
                    false,
                    null
                );
            }
            catch(Exception ex)
            {
                return new Result<int>(
                    Int32.MinValue,
                    StatusCodes.Status500InternalServerError,
                    true,
                    ex.Message
                );
            }
        }
    }
}
