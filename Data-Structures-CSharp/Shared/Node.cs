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
        private T data;

        /// <summary>
        /// Default constructor.
        /// Initializes node data to a given input parameter, and initializes node's next pointer to null.
        /// </summary>
        /// <param name="input">Item to be passed and set as current node's data value.</param>
        public Node(T input)
        {
            this.data = input;
        }

        /// <summary>
        /// Returns the value of the node's data.
        /// </summary>
        /// <returns>Returns value of current node's data</returns>
        public T getData()
        {
            return this.data;
        }

        /// <summary>
        /// Sets the value of current node's data to a given input parameter.
        /// </summary>
        /// <param name="input">Item to be passed and set as current node's data value.</param>
        public void setData(T input)
        {
            this.data = input;
        }
    }
}
