using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Structures_CSharp.Shared;

namespace Data_Structures_CSharp.Graph
{
    public class GraphEdgeNode<T> : Node<T>
    {
        public GraphEdgeNode(T input, int w = 0) : base(input)
        {
            this.weight = w;
            this.next = null;
        }

        public GraphEdgeNode<T> next;

        public int weight { get; set; }
    }
}
