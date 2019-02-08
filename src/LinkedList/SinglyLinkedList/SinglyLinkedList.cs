using System;

namespace LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : ISinglyLinkedList<T>
    {
        public SinglyLinkedListNode<T> Head { get; private set; }
        public SinglyLinkedListNode<T> Tail { get; private set; }
        public int Size { get; private set; }

        public SinglyLinkedList()
        {
            this.Size = 0;
        }

        public void InsertHead(T data)
        {
            if(this.Head is null)
            {
                this.Head = new SinglyLinkedListNode<T>(data);
                this.Tail = this.Head;
                this.Size++;
                return;
            }
            var newHead = new SinglyLinkedListNode<T>(data, this.Head);
            this.Head = newHead;
            this.Size++;
        }

        public void InsertTail(T data)
        {
            if (this.Tail is null)
            {
                this.Tail = new SinglyLinkedListNode<T>(data);
                this.Head = this.Tail;
                this.Size++;
                return;
            }
            var newTail = new SinglyLinkedListNode<T>(data);
            this.Tail.Next = newTail;
            this.Tail = newTail;
            this.Size++;
        }

        public void InsertAt(int index, T data)
        {
            if(index > this.Size || index <= 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if(index == 1)
            {
                this.InsertHead(data);
                return;
            }
            else if(index == this.Size)
            {
                this.InsertTail(data);
                return;
            }
            var current = this.Head;
            for(int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            var oldNext = current.Next;
            var newNode = new SinglyLinkedListNode<T>(data, oldNext);
            current.Next = newNode;
            //this.Head = current;
            this.Size++;
        }

        public void DeleteHead()
        {
            if(Head is null)
            {
                return;
            }
            else if(this.Size == 1)
            {
                this.Head = null;
                this.Tail = this.Head;
                this.Size--;
                return;
            }
            this.Head = this.Head.Next;
            this.Size--;
            if (this.Size <= 1)
            {
                this.Tail = this.Head;
            }
        }

        public void DeleteTail()
        {
            if(Tail is null)
            {
                return;
            }
            else if(this.Size == 1)
            {
                this.Tail = null;
                this.Head = Tail;
                this.Size--;
                return;
            }
            var current = this.Head;
            do
            {
                current = current.Next;
            } while (!current.Next.Equals(this.Tail));
            this.Tail = current;
            this.Size--;
        }

        public void Delete(T data)
        {
            if(this.Head.Data.Equals(data))
            {
                this.Head = this.Head.Next;
                this.Size--;
                return;
            }
            var current = this.Head;
            do
            {
                current = current.Next;
            } while (!current.Next.Data.Equals(data));
            current.Next = current.Next.Next;
            this.Head = current;
            this.Size--;
        }

        public int Search(T data)
        {
            var current = this.Head;
            for(int i = 1; i <= this.Size; i++)
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
