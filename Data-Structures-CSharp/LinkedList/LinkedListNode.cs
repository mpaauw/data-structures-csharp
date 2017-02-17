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
    class LinkedListNode<T> : LinkedNode<T>
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="input">Passed to constructor of base class.</param>
        public LinkedListNode(T input) : base(input) { }
    }
}
