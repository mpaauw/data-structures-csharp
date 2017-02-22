using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Structures_CSharp.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_CSharp.Graph.Tests
{
    [TestClass]
    public class GraphTests
    {
        private char[] vertices = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
        private int[,] edgeIndices = new int[,] { { 0, 1 }, { 0, 4 }, { 3, 5 }, { 1, 3 }, { 2, 0 }, { 5, 1 }, { 5, 6 } };
        private GraphNode<char> nodes;
        private int numEdges = 6;
        private Graph<char> graph;

        public GraphTests()
        {
            this.graph = new Graph<char>(true);
        }

        [TestMethod]
        public void insertVertexTest()
        {
            int expectedSize = 0;
            Assert.AreEqual(expectedSize, this.graph.numVertices);
            foreach(char vertex in this.vertices)
            {
                GraphNode<char> newNode = new GraphNode<char>(vertex);
                this.graph.insertVertex(newNode);
                Assert.IsTrue(this.graph.searchVertex(newNode));
                expectedSize++;
                Assert.AreEqual(expectedSize, this.graph.numVertices);
            }
        }

        [TestMethod]
        public void insertEdgeTest()
        {
            GraphNode<char>[] nodes = new GraphNode<char>[this.vertices.Length];
            int expectedSize = 0;
            Assert.AreEqual(expectedSize, this.graph.numEdges);
            int iter = 0;
            foreach (char vertex in this.vertices)
            {
                GraphNode<char> newNode = new GraphNode<char>(vertex);
                this.graph.insertVertex(newNode);
                nodes[iter] = newNode;
                iter++;
            }
            for(int i = 0; i < numEdges; i++)
            {
                int[] pair = new int[2];
                for(int j = 0; j <= 1; j++)
                {
                    pair[j] = edgeIndices[i, j];
                }
                this.graph.insertEdge(nodes[pair[0]], nodes[pair[1]]);
                Assert.IsTrue(this.graph.searchEdge(nodes[pair[0]], nodes[pair[1]]));
                expectedSize++;
                Assert.AreEqual(expectedSize, this.graph.numEdges);
            }
        }

        [TestMethod]
        public void breadthFirstSearchTest()
        {
            GraphNode<char>[] nodes = new GraphNode<char>[this.vertices.Length];
            int iter = 0;
            foreach (char vertex in this.vertices)
            {
                GraphNode<char> newNode = new GraphNode<char>(vertex);
                this.graph.insertVertex(newNode);
                nodes[iter] = newNode;
                iter++;
            }
            for (int i = 0; i < numEdges; i++)
            {
                int[] pair = new int[2];
                for (int j = 0; j <= 1; j++)
                {
                    pair[j] = edgeIndices[i, j];
                }
                this.graph.insertEdge(nodes[pair[0]], nodes[pair[1]]);
            }
            GraphNode<char>[] expectedOrder = { nodes[0], nodes[1], nodes[4], nodes[3], nodes[5] }; 
            GraphNode<char>[] actualOrder = this.graph.breadthFirstSearch();
            for(int i = 0; i < expectedOrder.Length; i++)
            {
                Assert.AreEqual(expectedOrder[i], actualOrder[i]);
            }

        }
    }
}