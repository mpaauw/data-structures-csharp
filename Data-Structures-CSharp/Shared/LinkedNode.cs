using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_CSharp.Shared
{
    /// <summary>
    /// Abstract base class which represents a single node for a linked data structure.
    /// </summary>
    /// <typeparam name="T">Underlying data type represented within the class object.</typeparam>
    abstract class LinkedNode<T>
    {
        private T data;

        private LinkedNode<T> next;

        /// <summary>
        /// Default constructor.
        /// Initializes node data to a given input parameter, and initializes node's next pointer to null.
        /// </summary>
        /// <param name="input">Item to be passed and set as current node's data value.</param>
        public LinkedNode(T input)
        {
            this.data = input;
            this.next = null;
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

        /// <summary>
        /// Returns the current node's next node pointer.
        /// </summary>
        /// <returns>Returns current node's next node object.</returns>
        public LinkedNode<T> getNext()
        {
            return this.next;
        }

        /// <summary>
        /// Sets the value of the current node's next pointer to a given object.
        /// </summary>
        /// <param name="input">Object to be passed and set as current node's next pointer.</param>
        public void setNext(LinkedNode<T> input)
        {
            this.next = input;
        }
    }
}
