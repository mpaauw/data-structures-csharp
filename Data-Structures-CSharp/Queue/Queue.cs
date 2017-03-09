using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Structures_CSharp.LinkedList;

namespace Data_Structures_CSharp.Queue
{
    /// <summary>
    /// Represents a Queue data structure implemented using a Linked-List.
    /// </summary>
    /// <typeparam name="T">Underlying data type represented within the class object.</typeparam>
    public class Queue<T>
    {
        private Data_Structures_CSharp.LinkedList.LinkedListNode<T> front;

        private Data_Structures_CSharp.LinkedList.LinkedListNode<T> rear;

        private int size;

        /// <summary>
        /// Default constructor.
        /// Assigns initial value of the queue to an input parameter, increments the size of the queue by 1.
        /// </summary>
        /// <param name="input">Initial value to assign to the head of the queue.</param>
        public Queue(T input)
        {
            this.front = new Data_Structures_CSharp.LinkedList.LinkedListNode<T>(input);
            this.rear = this.front;
            this.size++;
        }

        /// <summary>
        /// Returns the current size of the queue.
        /// </summary>
        /// <returns>Returns an int value representing the current size of the queue.</returns>
        public int getSize()
        {
            return this.size;
        }

        /// <summary>
        /// Inserts a new element at the end of the queue.
        /// </summary>
        /// <param name="input">Item to be passed and added to the queue.</param>
        public void enqueue(T input)
        {
            Data_Structures_CSharp.LinkedList.LinkedListNode<T> newNode = new Data_Structures_CSharp.LinkedList.LinkedListNode<T>(input);
            if(this.rear != null)
            {
                this.rear.next = newNode;
            }
            this.rear = newNode;
            if(this.front == null)
            {
                this.front = rear;
            }
            this.size++;
        }

        /// <summary>
        /// Returns the head element of the queue and deletes it from the structure.
        /// </summary>
        /// <returns>Returns an element of underlying data type T representing the element at the top of the queue.</returns>
        public T dequeue()
        {
            if(this.front == null)
            {
                throw new Exception();
            }
            T output = this.front.data;
            this.front = this.front.next;
            if(this.front == null)
            {
                this.rear = null;
            }
            this.size--;
            return output;
        }

        /// <summary>
        /// Determines whether or not the queue is empty.
        /// </summary>
        /// <returns>Returns true if the queue is empty, false if otherwise.</returns>
        public bool isEmpty()
        {
            if(this.size < 1)
            {
                return true;
            }
            return false;
        }
    }
}
