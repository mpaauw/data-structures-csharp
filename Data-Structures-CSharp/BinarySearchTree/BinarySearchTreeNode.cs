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
        private BinarySearchTreeNode<T> parent;

        private BinarySearchTreeNode<T> left;

        private BinarySearchTreeNode<T> right;

        public BinarySearchTreeNode(T input) : base(input)
        {
            this.parent = null;
            this.left = null;
            this.right = null;
        }

        public BinarySearchTreeNode<T> getParent()
        {
            return this.parent;
        }

        public void setParent(BinarySearchTreeNode<T> input)
        {
            this.parent = input;
        }

        public BinarySearchTreeNode<T> getLeft()
        {
            return this.left;
        }

        public void setLeft(BinarySearchTreeNode<T> input)
        {
            this.left = input;
        }

        public BinarySearchTreeNode<T> getRight()
        {
            return this.right;
        }

        public void setRight(BinarySearchTreeNode<T> input)
        {
            this.right = input;
        }
    }
}
