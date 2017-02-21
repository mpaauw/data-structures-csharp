using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_CSharp.Graph
{
    public class GraphEdge<T>
    {
        GraphNode<T> parent { get; set; }
        GraphNode<T> child { get; set; }

        public GraphEdge(GraphNode<T> p, GraphNode<T> c)
        {
            this.parent = p;
            this.child = c;
        }
    }
}
