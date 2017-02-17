using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_CSharp.Shared
{
    abstract class LinkedNode<T>
    {
        private T data;

        private LinkedNode<T> next;

        public LinkedNode(T input)
        {
            this.data = input;
            this.next = null;
        }

        public T getData()
        {
            return this.data;
        }

        public void setData(T input)
        {
            this.data = input;
        }

        public LinkedNode<T> getNext()
        {
            return this.next;
        }

        public void setNext(LinkedNode<T> input)
        {
            this.next = input;
        }
    }
}
