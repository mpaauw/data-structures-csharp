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
        private Data_Structures_CSharp.LinkedList.LinkedList<T> queue;
        private int size;

        /// <summary>
        /// Default constructor.
        /// Assigns initial value of the queue to an input parameter, increments the size of the queue by 1.
        /// </summary>
        /// <param name="input">Initial value to assign to the head of the queue.</param>
        public Queue(T input)
        {
            this.queue = new Data_Structures_CSharp.LinkedList.LinkedList<T>(input);
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
            this.queue.insertEnd(input);
            this.size++;
        }

        /// <summary>
        /// Returns the head element of the queue and deletes it from the structure.
        /// </summary>
        /// <returns>Returns an element of underlying data type T representing the element at the top of the queue.</returns>
        public T dequeue()
        {
            T head = this.queue.getElementAt(0);
            this.queue.delete(head);
            this.size--;
            return head;
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
