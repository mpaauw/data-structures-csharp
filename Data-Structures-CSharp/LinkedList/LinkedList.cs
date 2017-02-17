﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_CSharp.LinkedList
{
    /// <summary>
    /// Represents a singly-linked Linked List data structure.
    /// </summary>
    /// <typeparam name="T">Underlying data type represented within the class object.</typeparam>
    public class LinkedList<T>
    {
        private LinkedListNode<T> head;

        private int size;

        /// <summary>
        /// Default constructor.
        /// Assigns initial head of list to an input parameter and increments the size of the list by 1.
        /// </summary>
        /// <param name="input">Item to be set as the initial head of the list.</param>
        public LinkedList(T input)
        {
            this.head = new LinkedListNode<T>(input);
            this.size++;
        }

        /// <summary>
        /// Returns the current size of the list..
        /// </summary>
        /// <returns>Returns an int value representing the current size of the list.</returns>
        public int getSize()
        {
            return this.size;
        }

        /// <summary>
        /// Inserts a value into the front of the list, and increments the size of the list by 1.
        /// The value is inserted into the front of the list in order to avoid costly traversal for each insertion.
        /// </summary>
        /// <param name="input">Item to be passed and added to the front of the list.</param>
        public void insert(T input)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(input);
            newNode.setNext(this.head);
            this.head = newNode;
            this.size++;
        }

        /// <summary>
        /// Deletes the first occurence of a value from the list, and decrements the size of the list by 1.
        /// </summary>
        /// <param name="input">Item to be searched for and removed from the list.</param>
        public void delete(T input)
        {
            LinkedListNode<T> temp = this.head;
            LinkedListNode<T> predecessor = null;
            do
            {
                if (temp.getData().Equals(input))
                {
                    if(predecessor != null)
                    {
                        predecessor.setNext(temp.getNext());
                        temp = predecessor;
                        this.size--;
                        return;
                    }
                    else
                    {
                        if (temp.getNext() != null)
                        {
                            temp = (LinkedListNode<T>)temp.getNext();
                            this.head = temp;
                            this.size--;
                            return;
                        }
                    }
                }
                predecessor = temp;
                temp = (LinkedListNode<T>)temp.getNext();
            } while (temp != null);
        }

        /// <summary>
        /// Determines whether or not a specified value exists within the list.
        /// Uses a wrapper method in order to achieve a recursive search.
        /// </summary>
        /// <param name="input">Item to be searched for within the list.</param>
        /// <returns>Returns true if the list contains the search term, false if otherwise.</returns>
        public bool search(T input)
        {
            LinkedListNode<T> temp = this.head;
            return search(input, temp);
        }
        private bool search(T input, LinkedListNode<T> node)
        {
            if (node == null)
            {
                return false;
            }
            else if (node.getData().Equals(input))
            {
                return true;
            }
            else
            {
                return search(input, (LinkedListNode<T>)node.getNext());
            }
        }
    }
}
