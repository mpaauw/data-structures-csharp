namespace LinkedList.SinglyLinkedList
{
    public interface ISinglyLinkedList<T>
    {
        void InsertHead(T data);

        void InsertTail(T data);

        // zero-based
        void InsertAt(int index, T data);

        void DeleteHead();

        void DeleteTail();

        void Delete(T data);

        // zero-based
        int Search(T data);
    }
}
