namespace LinkedList.SinglyLinkedList
{
    public class SinglyLinkedListNode<T> : ListNode<T>
    {
        public SinglyLinkedListNode() { }

        public SinglyLinkedListNode(T data) : base(data) { }

        public SinglyLinkedListNode(T data, SinglyLinkedListNode<T> next) : base(data)
        {
            Next = next;
        }

        public SinglyLinkedListNode<T> Next { get; set; }
    }
}
