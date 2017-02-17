using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Structures_CSharp.Shared;

namespace Data_Structures_CSharp.LinkedList
{
    /// <summary>
    /// Class which represents a single node for a Linked List data structure.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedListNode<T> : Node<T>
    {
        private LinkedListNode<T> next;

        /// <summary>
        /// Default constructor.
        /// Initializes the current node's next pointer to null.
        /// </summary>
        /// <param name="input">Passed to constructor of base class.</param>
        public LinkedListNode(T input) : base(input)
        {
            this.next = null;
        }

        /// <summary>
        /// Returns the current node's next node pointer.
        /// </summary>
        /// <returns>Returns current node's next node object.</returns>
        public LinkedListNode<T> getNext()
        {
            return this.next;
        }

        /// <summary>
        /// Sets the value of the current node's next pointer to a given object.
        /// </summary>
        /// <param name="input">Object to be passed and set as current node's next pointer.</param>
        public void setNext(LinkedListNode<T> input)
        {
            this.next = input;
        }
    }

}
