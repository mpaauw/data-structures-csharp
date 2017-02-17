using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_CSharp.Shared
{
    /// <summary>
    /// Abstract base class which represents a single node for a data structure.
    /// </summary>
    /// <typeparam name="T">Underlying data type represented within the class object.</typeparam>
    abstract class Node<T>
    {
        public T data { get; set; }

        /// <summary>
        /// Default constructor.
        /// Initializes node data to a given input parameter, and initializes node's next pointer to null.
        /// </summary>
        /// <param name="input">Item to be passed and set as current node's data value.</param>
        public Node(T input)
        {
            this.data = input;
        }
    }
}
