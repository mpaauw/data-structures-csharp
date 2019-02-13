using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Api.Common
{
    public static class Constants
    {
        public const string RedisHost = "localhost";

        public static readonly ConfigurationOptions RedisConfig = new ConfigurationOptions()
        {
            AbortOnConnectFail = false,
            EndPoints = { RedisHost },
            ConnectTimeout = 10000,
            ConnectRetry = 3
        };

        public const string UnableToSetErrorMessage = "Unable to set.";

        public const string KeyNotFoundErrorMessage = "Key not found.";
    }
}
