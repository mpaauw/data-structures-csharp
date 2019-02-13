using DataStructures.Api.LinkedList.Controllers;
using DataStructures.Core.LinkedList.SinglyLinkedList;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace DataStructures.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedListController controller = new SinglyLinkedListController();

            var list = new SinglyLinkedList<TestThingy>();

            var result = controller.Create(JsonConvert.SerializeObject(list), list.GetType()).Result;
        }

        public class TestThingy
        {
            public const string Floob = "Immutable";

            public int ImportantInteger { get; set; }

            public bool Killswitch { get; set; }
        }
    }
}
