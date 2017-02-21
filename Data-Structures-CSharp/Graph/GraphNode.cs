using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Structures_CSharp.Shared;

namespace Data_Structures_CSharp.Graph
{
    class GraphNode<T> : Node<T>
    {
        public GraphNode(T input) : base(input) { }
    }
}
