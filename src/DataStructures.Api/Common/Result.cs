using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Api.Common
{
    public class Result<T>
    {
        public Result() { }

        public Result(T data)
        {
            Data = data;
        }

        public Result(T data, int statusCode)
        {
            Data = data;
            StatusCode = statusCode;
        }

        public Result(T data, int statusCode, bool isError)
        {
            Data = data;
            StatusCode = statusCode;
            IsError = isError;
        }

        public Result(T data, int statusCode, bool isError, string errorMessage)
        {
            Data = data;
            StatusCode = statusCode;
            IsError = isError;
            ErrorMessage = errorMessage;
        }

        public T Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
    }
}
