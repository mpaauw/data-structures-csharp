using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Structures_CSharp.Shared;

namespace Data_Structures_CSharp.Graph
{
    public class GraphNode<T> : Node<T>
    {
        public GraphNode(T input) : base(input)
        {
            this.state = VisitState.Unvisited;
        }

        public VisitState state { get; set; }

        public enum VisitState
        {
            Unvisited, Visiting, Visited
        }
    }
}
