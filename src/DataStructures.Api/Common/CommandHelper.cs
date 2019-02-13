using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Api.Common
{
    public static class CommandHelper
    {
        public static string BuildRedisKey(string typeName)
        {
            return $"{typeName}:{Guid.NewGuid()}";
        }
    }
}
