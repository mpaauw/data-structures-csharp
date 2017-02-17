using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Structures_CSharp.Shared;

namespace Data_Structures_CSharp.BinarySearchTree
{
    class BinarySearchTreeNode<T> : Node<T>
    {
        public BinarySearchTreeNode<T> parent { get; set; }

        public BinarySearchTreeNode<T> left { get; set; }

        public BinarySearchTreeNode<T> right { get; set; }

        public BinarySearchTreeNode(T input) : base(input)
        {
            this.parent = null;
            this.left = null;
            this.right = null;
        }
    }
}
