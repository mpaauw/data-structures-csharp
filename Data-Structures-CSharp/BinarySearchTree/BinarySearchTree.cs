using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_CSharp.BinarySearchTree
{
    class BinarySearchTree<T>
    {
        private BinarySearchTreeNode<T> root;

        private int size;

        public BinarySearchTree(T input)
        {
            root = new BinarySearchTreeNode<T>(input);
            this.size++;
        }

        public bool search(IComparable input)
        {
            BinarySearchTreeNode<T> temp = this.root;
            return search(input, temp);
        }
        private bool search(IComparable input, BinarySearchTreeNode<T> node)
        {
            if(node == null)
            {
                return false;
            }
            else if (node.data.Equals(input))
            {
                return true;
            }
            else if(input.CompareTo(node.data) > 0)
            {
                return search(input, node.right);
            }
            else
            {
                return search(input, node.left);
            }
        }

        public T findMinimum()
        {
            BinarySearchTreeNode<T> temp = this.root;
            return findMinimum(temp);
        }
        private T findMinimum(BinarySearchTreeNode<T> node)
        {
            if(node.left == null)
            {
                return node.data;
            }
            return findMinimum(node.left);
        }

        public T findMaximum()
        {
            BinarySearchTreeNode<T> temp = this.root;
            return findMaximum(temp);
        }
        private T findMaximum(BinarySearchTreeNode<T> node)
        {
            if(node.right == null)
            {
                return node.data;
            }
            return findMaximum(node.right);
        }

        public T[] traverse()
        {
            BinarySearchTreeNode<T> temp = this.root;
            return traverse(new List<T>(), temp).ToArray();
        }
        private List<T> traverse(List<T> order, BinarySearchTreeNode<T> node)
        {
            if(node != null)
            {
                traverse(order, node.left);
                order.Add(node.data);
                traverse(order, node.right);
            }
            return order;
        }

        public void insert(IComparable input)
        {
            if(this.root == null)
            {
                this.root = new BinarySearchTreeNode<T>((T)input);
                this.size++;
            }
            else
            {
                BinarySearchTreeNode<T> temp = root;
                while(temp != null)
                {
                    if(input.CompareTo(temp.data) < 0)
                    {
                        temp = temp.left;
                    }
                    else
                    {
                        temp = temp.right;
                    }
                }
                temp = new BinarySearchTreeNode<T>((T)input);
                this.size++;
            }
        }
        
    }
}
