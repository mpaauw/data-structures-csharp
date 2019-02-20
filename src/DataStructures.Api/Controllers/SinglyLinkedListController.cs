using DataStructures.Api.Common;
using DataStructures.Api.Commands.SinglyLinkedList;
using DataStructures.Core.LinkedList.SinglyLinkedList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace DataStructures.Api.Controllers
{
    [Route("api/[controller]")]
    public class SinglyLinkedListController : Controller
    {
        [HttpPost("Create")]
        public async Task<Result<string>> Create([FromBody] SinglyLinkedList<string> list = null)
        {
            if(list is null)
            {
                list = new SinglyLinkedList<string>();
            }

            var command = new CreateCommand()
            {
                List = list
            };

            return await command.ExecuteAsync();
        }

        [HttpGet("Retrieve/{key}")]
        public async Task<Result<SinglyLinkedList<dynamic>>> Retrieve([FromRoute] string key)
        {
            var command = new RetrieveCommand<dynamic>(key);
            return await command.ExecuteAsync();
        }

        [HttpPut("Update/{key}")]
        public async Task<Result<string>> Update(
            [FromRoute] string key,
            [FromBody] SinglyLinkedList<dynamic> list)
        {
            var command = new UpdateCommand<dynamic>(key, list);
            return await command.ExecuteAsync();
        }

        [HttpDelete("Remove/{key}")]
        public async Task<Result<string>> Remove([FromRoute] string key)
        {
            var command = new RemoveCommand(key);
            return await command.ExecuteAsync();
        }

        [HttpPost("Search/{key}")]
        public async Task<Result<int>> Search(
            [FromRoute] string key,
            [FromBody] dynamic data)
        {
            var command = new SearchCommand<dynamic>(key, data);
            return await command.ExecuteAsync();
        }

        [HttpPost("Insert/{key}")]
        public async Task<Result<bool>> Insert(
            [FromRoute] string key,
            [FromBody] dynamic data,
            [FromBody] bool insertAtHead = false,
            [FromBody] int index = -1)
        {
            var command = new InsertCommand<dynamic>(key, data, insertAtHead, index);
            return await command.ExecuteAsync();
        }

        [HttpDelete("Delete/{key}")]
        public async Task<Result<bool>> Delete(
            [FromRoute] string key,
            [FromBody] dynamic data = null,
            [FromBody] bool deleteFromHead = false)
        {
            var command = new DeleteCommand<dynamic>(key, data, deleteFromHead);
            return await command.ExecuteAsync();
        }

        public class Dummy
        {
            public Dummy() { }

            public string Cereal { get; set; }
        }

    }
}
