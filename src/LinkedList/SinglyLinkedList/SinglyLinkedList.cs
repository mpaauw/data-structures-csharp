using System;

namespace LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : ISinglyLinkedList<T>
    {
        private SinglyLinkedListNode<T> head;
        private SinglyLinkedListNode<T> tail;
        private int size = 0;

        public void InsertHead(T data)
        {
            if(this.head is null)
            {
                this.head = new SinglyLinkedListNode<T>(data);
                this.tail = this.head;
                this.size++;
                return;
            }
            var newHead = new SinglyLinkedListNode<T>(data, this.head);
            this.head = newHead;
            this.size++;
        }

        public void InsertTail(T data)
        {
            if (this.tail is null)
            {
                this.tail = new SinglyLinkedListNode<T>(data);
                this.head = this.tail;
                this.size++;
                return;
            }
            var newTail = new SinglyLinkedListNode<T>(data);
            this.tail.Next = newTail;
            this.tail = newTail;
            this.size++;
        }

        public void InsertAt(int index, T data)
        {
            if(index > this.size || index <= 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if(index == 1)
            {
                this.InsertHead(data);
            }
            else if(index == this.size)
            {
                this.InsertTail(data);
            }
            var current = this.head;
            for(int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            var oldNext = current.Next;
            var newNode = new SinglyLinkedListNode<T>(data, oldNext);
            current.Next = newNode;
            this.head = current;
            this.size++;
        }

        public void DeleteHead()
        {
            if(head is null)
            {
                return;
            }
            else if(this.size == 1)
            {
                this.head = null;
                this.tail = this.head;
                this.size--;
                return;
            }
            this.head = this.head.Next;
            this.size--;
            if (this.size <= 1)
            {
                this.tail = this.head;
            }
        }

        public void DeleteTail()
        {
            if(tail is null)
            {
                return;
            }
            else if(this.size == 1)
            {
                this.tail = null;
                this.head = tail;
                this.size--;
                return;
            }
            var current = this.head;
            do
            {
                current = current.Next;
            } while (!current.Next.Equals(this.tail));
            this.tail = current;
            this.size--;
        }

        public void Delete(T data)
        {
            if(this.head.Data.Equals(data))
            {
                this.head = this.head.Next;
                this.size--;
                return;
            }
            var current = this.head;
            do
            {
                current = current.Next;
            } while (!current.Next.Data.Equals(data));
            current.Next = current.Next.Next;
            this.head = current;
            this.size--;
        }

        public int Search(T data)
        {
            var current = this.head;
            for(int i = 1; i <= this.size; i++)
            {
                if(current.Data.Equals(data))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
