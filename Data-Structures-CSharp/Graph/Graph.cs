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

        public bool searchVertex(GraphNode<T> input)
        {
            if (this.adjacencyList.ContainsKey(input))
            {
                return true;
            }
            return false;
        }

        public void insertVertex(GraphNode<T> input)
        {
            if (!adjacencyList.ContainsKey(input))
            {
                adjacencyList.Add(input, new List<GraphNode<T>>());
                numVertices++;
            }
        }

        public bool searchEdge(GraphNode<T> x, GraphNode<T> y)
        {
            if (adjacencyList.ContainsKey(x))
            {
                if (adjacencyList[x].Contains(y))
                {
                    return true;
                }
            }
            return false;
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

        public GraphNode<T>[] breadthFirstSearch()
        {
            Queue<GraphNode<T>> queue = new Queue<GraphNode<T>>();
            queue.Enqueue(adjacencyList.Keys.ElementAt(0));
            return breadthFirstSearch(queue, new List<GraphNode<T>>()).ToArray();
        }
        private List<GraphNode<T>> breadthFirstSearch(Queue<GraphNode<T>> queue, List<GraphNode<T>> order)
        {
            while(queue.Count() > 0)
            {
                GraphNode<T> node = queue.Dequeue();
                if(node.state == GraphNode<T>.VisitState.Visited)
                {
                    return null; // loop encountered
                }
                order.Add(node);
                foreach(GraphNode<T> child in this.adjacencyList[node])
                {
                    if(child.state == GraphNode<T>.VisitState.Unvisited)
                    {
                        child.state = GraphNode<T>.VisitState.Visiting;
                        queue.Enqueue(child);
                        order = breadthFirstSearch(queue, order);
                    }
                }
                node.state = GraphNode<T>.VisitState.Visited;
            }
            return order;
        }
    }
}
