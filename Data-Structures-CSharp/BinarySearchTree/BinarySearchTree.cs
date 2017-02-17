using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_CSharp.BinarySearchTree
{
    /// <summary>
    /// Represents a Binary Search Tree data structure.
    /// </summary>
    /// <typeparam name="T">Underlying data type represented within the class object.</typeparam>
    public class BinarySearchTree<T>
    {
        private BinarySearchTreeNode<T> root;

        private int size;

        /// <summary>
        /// Default constructor.
        /// Assigns initial root of tree to an input parameter and increments the size of the tree by 1.
        /// </summary>
        /// <param name="input">Item to be set as the initial root of the tree.</param>
        public BinarySearchTree(T input)
        {
            root = new BinarySearchTreeNode<T>(input);
            this.size++;
        }

        /// <summary>
        /// Determines whether or not a specified value exists within the tree.
        /// Uses a wrapper method in order to achieve a recursive search.
        /// </summary>
        /// <param name="input">Item to be searched for within the tree.</param>
        /// <returns>Returns true if the tree contains the search term, false if otherwise.</returns>
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

        /// <summary>
        /// Finds the smallest value within the tree.
        /// </summary>
        /// <returns>Returns an object of type T representing the smallest value within the tree.</returns>
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

        /// <summary>
        /// Finds the largest value within the tree.
        /// </summary>
        /// <returns>REturns an object of type T representing the largest value within the tree.</returns>
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

        /// <summary>
        /// Traverses the tree using an Inorder traversal pattern.
        /// </summary>
        /// <returns>Returns an array of BinarySearchTreeNode objects of type T ordered in the sequence they were encountered during tree traversal.</returns>
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

        /// <summary>
        /// Recursively inserts a value into the tree at an appropriate spot given the rules of a Binary Search Tree.
        /// </summary>
        /// <param name="input">Item to be passed and added to the tree; declared as an IComparable type in order to provide comparisons between the key values of other nodes within the tree.</param>
        public void insert(IComparable input)
        {
            this.root = insert(input, this.root);
        }
        private BinarySearchTreeNode<T> insert(IComparable input, BinarySearchTreeNode<T> node)
        {
            if(node == null)
            {
                node = new BinarySearchTreeNode<T>((T)input);
                this.size++;
                return node;
            }
            else
            {
                if(input.CompareTo(node.data) < 0)
                {
                    return insert(input, node.left);
                }
                else
                {
                    return insert(input, node.right);
                }
            }
        }
        
        /// <summary>
        /// Recursively deletes the first occurence of a value from the tree, then decrements the size of the tree by 1.
        /// </summary>
        /// <param name="input">Item to be searched for and removed from the tree; declared as an IComparable type in order to provide comparisons between the key values of other nodes.</param>
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
            if(input.CompareTo(node.data) < 0)
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
                this.size--;
            }
            return balance(node);
        }  

        /// <summary>
        /// Recursively conducts balancing operations on the tree.
        /// To be used after insertions and deletions.
        /// </summary>
        /// <param name="node">The node that is currently being examined for balance.</param>
        /// <returns>Recursively returns a BinarySearchTreeNode object of type T.</returns>
        private BinarySearchTreeNode<T> balance(BinarySearchTreeNode<T> node)
        {
            int leftHeight = getHeight(node.left, 0);
            int rightHeight = getHeight(node.right, 0);
            if(Math.Abs(leftHeight - rightHeight) > 1)
            {
                if(leftHeight < rightHeight)
                {
                    BinarySearchTreeNode<T> oldNode = node;
                    node = node.right;
                    BinarySearchTreeNode<T> oldLeftChild = node.left;
                    node.left = oldNode;
                    node.left.right = oldLeftChild;
                }
                else if(leftHeight > rightHeight)
                {
                    BinarySearchTreeNode<T> oldNode = node;
                    node = node.left;
                    BinarySearchTreeNode<T> oldRightChild = node.right;
                    node.right = oldNode;
                    node.right.left = oldRightChild;
                }
            }
            else
            {
                return node;
            }
            return balance(node);
        }

        /// <summary>
        /// Recursively finds the height of a tree given a node to parse.
        /// </summary>
        /// <param name="node">Current node to be checked for height.</param>
        /// <param name="height">Current value of tree height as it relates to the current node.</param>
        /// <returns>Returns an int representing the height of the tree at a given node.</returns>
        private int getHeight(BinarySearchTreeNode<T> node, int height)
        {
            if(node == null)
            {
                return height;
            }
            height++;
            int leftHeight = getHeight(node.left, height);
            int rightHeight = getHeight(node.right, height);
            return Math.Max(leftHeight, rightHeight);
        }
    }
}
