using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Structures_CSharp.Shared;

namespace Data_Structures_CSharp.BinarySearchTree
{
    /// <summary>
    /// Class which represents a single node for a Binary Search Tree data structure.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class BinarySearchTreeNode<T> : Node<T>
    {
        public BinarySearchTreeNode<T> parent { get; set; }

        public BinarySearchTreeNode<T> left { get; set; }

        public BinarySearchTreeNode<T> right { get; set; }

        /// <summary>
        /// Default constructor.
        /// Initializes the current node's parent, left and right pointers to null.
        /// </summary>
        /// <param name="input">Passed to constructor of base class.</param>
        public BinarySearchTreeNode(T input) : base(input)
        {
            this.parent = null;
            this.left = null;
            this.right = null;
        }
    }
}
