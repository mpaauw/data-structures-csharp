using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Structures_CSharp.LinkedList;

namespace Data_Structures_CSharp.Queue
{
    public class Queue<T>
    {
        private Data_Structures_CSharp.LinkedList.LinkedList<T> queue;
        private int size;

        public Queue(T input)
        {
            this.queue = new Data_Structures_CSharp.LinkedList.LinkedList<T>(input);
            this.size++;
        }

        public int getSize()
        {
            return this.size;
        }

        public void enqueue(T input)
        {
            this.queue.insertEnd(input);
            this.size++;
        }

        public T dequeue()
        {
            T head = this.queue.getElementAt(0);
            this.queue.delete(head);
            this.size--;
            return head;
        }

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
