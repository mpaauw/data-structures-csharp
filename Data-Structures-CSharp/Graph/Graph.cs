using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_CSharp.Graph
{
    public class Graph<T>
    {
        private LinkedList<T> vertices;

        private LinkedList<T> edges;

        private int numVertices;

        private int numEdges;

        public Graph()
        {
            this.vertices = new LinkedList<T>();
            this.edges = new LinkedList<T>();
            this.numVertices = 0;
            this.numEdges = 0;
        }


    }
}
