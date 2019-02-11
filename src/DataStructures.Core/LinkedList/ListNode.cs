namespace DataStructures.Core.LinkedList
{
    public class ListNode<T>
    {
        public ListNode() { }

        public ListNode(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
