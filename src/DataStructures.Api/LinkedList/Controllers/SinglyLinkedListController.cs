using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DataStructures.Api.LinkedList.Controllers
{
    [Route("api/[controller]")]
    public class SinglyLinkedListController : Controller
    {
        /// <summary>
        /// Create a new singly linked list
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public HttpResponse Create(Type type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve a singly linked list head node, given it's key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet("Retrieve/{key}")]
        public HttpResponse Retrieve([FromRoute] string key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes a singly linked list, given it's key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete("Remove/{key}")]
        public HttpResponse Remove([FromRoute] string key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches a given linked list for a supplied value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost("Search/{key}")]
        public HttpResponse Search(
            [FromRoute] string key,
            [FromBody] Type type,
            [FromBody] object data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts a new value into a given list, several options
        /// </summary>
        /// <param name="key"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="insertAtHead"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        [HttpPost("Insert/{key}")]
        public HttpResponse Insert(
            [FromRoute] string key,
            [FromBody] Type type,
            [FromBody] object data,
            [FromBody] bool insertAtHead = false,
            [FromBody] int index = -1)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a value from a given list, several options
        /// </summary>
        /// <param name="key"></param>
        /// <param name="type"></param>
        /// <param name="deleteFromHead"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{key}")]
        public HttpResponse Delete(
            [FromRoute] string key,
            [FromBody] Type type,
            [FromBody] bool deleteFromHead = false,
            [FromBody] object data = null)
        {
            throw new NotImplementedException();
        }

    }
}
