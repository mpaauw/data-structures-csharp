using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_CSharp.Graph
{
    /// <summary>
    /// Represents a graph data structure.
    /// </summary>
    /// <typeparam name="T">Underlying data type represented within the class object.</typeparam>
    public class Graph<T>
    {
        private Dictionary<GraphNode<T>, List<GraphNode<T>>> adjacencyList;

        public int numVertices { get; set; }

        public int numEdges { get; set; }

        bool directed;

        /// <summary>
        /// Default constructor.
        /// Assigns graph to either a directed or undirected type.
        /// </summary>
        /// <param name="d">Optional boolean parameter that determines graph's type.</param>
        public Graph(bool d = false)
        {
            this.adjacencyList = new Dictionary<GraphNode<T>, List<GraphNode<T>>>();
            this.numVertices = 0;
            this.numEdges = 0;
            this.directed = d;
        }

        /// <summary>
        /// Determines whether or not a specified vertex exists within the graph.
        /// </summary>
        /// <param name="input">Item to be searched for within the graph.</param>
        /// <returns>Returns true if the graph contains the search term, false if otherwise.</returns>
        public bool searchVertex(GraphNode<T> input)
        {
            if (this.adjacencyList.ContainsKey(input))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Inserts a vertex into the graph.
        /// </summary>
        /// <param name="input">Input node representing the vertex to be inserted into the graph.</param>
        public void insertVertex(GraphNode<T> input)
        {
            if (!this.adjacencyList.ContainsKey(input))
            {
                this.adjacencyList.Add(input, new List<GraphNode<T>>());
                this.numVertices++;
            }
        }

        /// <summary>
        /// Determines whether or not a specified edge exists within the graph from point x to point y.
        /// </summary>
        /// <param name="x">Input node representing one side of the edge to be searched for.</param>
        /// <param name="y">Input node representing opposite side of the edge to be searched for.</param>
        /// <returns>Returns true if the graph contains an edge between the two nodes, false if otherwise.</returns>
        public bool searchEdge(GraphNode<T> x, GraphNode<T> y)
        {
            if (this.adjacencyList.ContainsKey(x))
            {
                if (this.adjacencyList[x].Contains(y))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Inserts an edge between two nodes into a graph.
        /// Functions differently depending on if the graph is directed or undirected.
        /// </summary>
        /// <param name="x">Input node representing one side of the edge to be inserted.</param>
        /// <param name="y">Input node representing opposite side of the edge to be inserted.</param>
        public void insertEdge(GraphNode<T> x, GraphNode<T> y)
        {        
            if (!this.directed)
            {
                if(this.adjacencyList.ContainsKey(x) & this.adjacencyList.ContainsKey(y))
                {
                    this.adjacencyList[x].Add(y);
                    this.adjacencyList[y].Add(x);
                    this.numEdges += 2;
                }
            }
            else
            {
                if (this.adjacencyList.ContainsKey(x))
                {
                    if (!this.adjacencyList[x].Contains(y))
                    {
                        this.adjacencyList[x].Add(y);
                        this.numEdges++;
                    }
                }
            }
        }

        /// <summary>
        /// Performs a breadth-first search traversal on the graph, starting at the first node within the adjacency list.
        /// Uses a wrapper method in order to achieve a recursive traversal.
        /// </summary>
        /// <returns>Returns an array representing the traversal ordering of the nodes within the graph.</returns>
        public GraphNode<T>[] breadthFirstSearch()
        {
            Queue<GraphNode<T>> queue = new Queue<GraphNode<T>>();
            queue.Enqueue(this.adjacencyList.Keys.ElementAt(0));
            return breadthFirstSearch(queue, new List<GraphNode<T>>()).ToArray();
        }
        private List<GraphNode<T>> breadthFirstSearch(Queue<GraphNode<T>> queue, List<GraphNode<T>> order)
        {
            while(queue.Count() > 0)
            {
                GraphNode<T> node = queue.Dequeue();
                order.Add(node);
                foreach(GraphNode<T> child in this.adjacencyList[node])
                {
                    if(child.state == GraphNode<T>.VisitState.Unvisited)
                    {
                        child.state = GraphNode<T>.VisitState.Visiting;
                        queue.Enqueue(child);                       
                    }
                }
                order = breadthFirstSearch(queue, order);
                node.state = GraphNode<T>.VisitState.Visited;
            }
            return order;
        }

        /// <summary>
        /// Performs a depth-first search traversal on the graph, starting at the first node within the adjacency list.
        /// Uses a wrapper method in order to acheive a recursive traversal.
        /// </summary>
        /// <returns>Returns an array representing the traversal ordering of the nodes within a graph.</returns>
        public GraphNode<T>[] depthFirstSearch()
        {
            Stack<GraphNode<T>> stack = new Stack<GraphNode<T>>();
            stack.Push(this.adjacencyList.Keys.ElementAt(0));
            return depthFirstSearch(stack, new List<GraphNode<T>>()).ToArray();
        }
        private List<GraphNode<T>> depthFirstSearch(Stack<GraphNode<T>> stack, List<GraphNode<T>> order)
        {
            while(stack.Count > 0)
            {
                GraphNode<T> node = stack.Pop();
                order.Add(node);
                foreach(GraphNode<T> child in this.adjacencyList[node])
                {
                    if(child.state == GraphNode<T>.VisitState.Unvisited)
                    {
                        child.state = GraphNode<T>.VisitState.Visiting;
                        stack.Push(child);
                    }
                }
                order = depthFirstSearch(stack, order);
                node.state = GraphNode<T>.VisitState.Visited;
            }
            return order;
        }
    }
}
