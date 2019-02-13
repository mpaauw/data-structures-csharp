using DataStructures.Api.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Api
{
    public class Startup
    {
        private readonly Container container;

        public Startup()
        {
            this.container = new Container();
        }

        public void Configure(IApplicationBuilder app)
        {

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConnectionMultiplexer>(x => ConnectionMultiplexer.Connect(Constants.RedisConfig));
        }
    }
}
