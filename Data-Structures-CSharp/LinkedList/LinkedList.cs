using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_CSharp.LinkedList
{
    class LinkedList<T>
    {
        private LinkedListNode<T> head;

        private int size;

        public LinkedList(T input)
        {
            this.head = new LinkedListNode<T>(input);
            this.size++;
        }

        public int getSize()
        {
            return this.size;
        }

        public void insert(T input)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(input);
            newNode.setNext(this.head); // insert node to beginning of list to avoid traversal
            this.head = newNode;
            this.size++;
        }

        public void delete(T input)
        {
            LinkedListNode<T> temp = this.head;
            LinkedListNode<T> predecessor = null;
            do
            {
                if (temp.getData().Equals(input))
                {
                    if(!predecessor.Equals(null))
                    {
                        predecessor.setNext(temp.getNext());
                        temp = predecessor;
                        return;
                    }
                    else
                    {
                        if (!temp.getNext().Equals(null))
                        {
                            temp = (LinkedListNode<T>)temp.getNext();
                            this.head = temp;
                            return;
                        }
                    }
                }
                predecessor = temp;
                temp = (LinkedListNode<T>)temp.getNext();
            } while (temp != null);
        }

        public bool search(T input)
        {
            LinkedListNode<T> temp = this.head;
            return search(input, temp);
        }
        private bool search(T input, LinkedListNode<T> node)
        {
            if (node.getData().Equals(null))
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
