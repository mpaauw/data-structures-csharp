using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_CSharp.Graph
{
    public class Graph<T>
    {
        private Dictionary<GraphNode<T>, List<GraphNode<T>>> adjacencyList;

        public int numVertices { get; set; }

        public int numEdges { get; set; }

        bool directed;

        public Graph(bool d = false)
        {
            this.adjacencyList = new Dictionary<GraphNode<T>, List<GraphNode<T>>>();
            this.numVertices = 0;
            this.numEdges = 0;
            this.directed = d;
        }

        public void insertVertex(GraphNode<T> input)
        {
            if (!adjacencyList.ContainsKey(input))
            {
                adjacencyList.Add(input, new List<GraphNode<T>>());
                numVertices++;
            }
        }

        public void insertEdge(GraphNode<T> x, GraphNode<T> y)
        {
            if (adjacencyList.ContainsKey(x))
            {
                if (!adjacencyList[x].Contains(y))
                {
                    adjacencyList[x].Add(y);
                    numEdges++;
                }
            }
        }
    }
}
