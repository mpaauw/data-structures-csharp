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

        public void delete(IComparable input)
        {
            this.root = delete(input, this.root);
        }
        private BinarySearchTreeNode<T> delete(IComparable input, BinarySearchTreeNode<T> node)
        {
            if(node == null)
            {
                return node;
            }
            else if(input.CompareTo(node.data) < 0)
            {
                node.left = delete(input, node.left);
            }
            else if(input.CompareTo(node.data) > 0)
            {
                node.right = delete(input, node.right);
            }
            else if(node.left != null & node.right != null)
            {
                node.data = findMinimum(node.right);
                node.right = delete((IComparable)node.data, node.right);
            }
            else
            {
                node = (node.left != null) ? node.left : node.right;
            }
            return balanceTree(node);
        }

        private BinarySearchTreeNode<T> balanceTree(BinarySearchTreeNode<T> node)
        {
            int leftHeight = getTreeHeight(node.left, 0);
            int rightHeight = getTreeHeight(node.right, 0);
            if(Math.Abs(leftHeight - rightHeight) > 1)
            {
                if(leftHeight < rightHeight)
                {
                    BinarySearchTreeNode<T> oldNode = node;
                    node = node.right;
                    BinarySearchTreeNode<T> oldChild = node.left;
                    node.left = oldNode;
                    node.left.right = oldChild;
                }
                else if(leftHeight > rightHeight)
                {
                    BinarySearchTreeNode<T> oldNode = node;
                    node = node.left;
                    BinarySearchTreeNode<T> oldChild = node.right;
                    node.right = oldNode;
                    node.right.left = oldChild;
                }
            }
            else
            {
                return node;
            }
            return balanceTree(node);
        }

        private int getTreeHeight(BinarySearchTreeNode<T> node, int height)
        {
            if(node == null)
            {
                return height;
            }
            height++;
            int leftHeight = getTreeHeight(node.left, height);
            int rightHeight = getTreeHeight(node.right, height);
            return Math.Max(leftHeight, rightHeight);
        }
        
    }
}
