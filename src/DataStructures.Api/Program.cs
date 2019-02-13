using DataStructures.Core.LinkedList.SinglyLinkedList;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace DataStructures.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            //SinglyLinkedListController controller = new SinglyLinkedListController();

            //var list = new SinglyLinkedList<TestThingy>();

            //var createResult = controller.Create(JsonConvert.SerializeObject(list), list.GetType()).Result;

            //// ==========================================================================

            //var key = createResult.Data;
            //var data = new TestThingy()
            //{
            //    ImportantInteger = 9000,
            //    Killswitch = true
            //};
            //var insertResult = controller.Insert(key, data);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();

        public class TestThingy
        {
            public const string Floob = "Immutable";

            public int ImportantInteger { get; set; }

            public bool Killswitch { get; set; }
        }
    }
}
