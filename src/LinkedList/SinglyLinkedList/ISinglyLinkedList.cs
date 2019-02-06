namespace LinkedList.SinglyLinkedList
{
    public interface ISinglyLinkedList<T>
    {
        void InsertHead(T data);

        void InsertTail(T data);

        void InsertAt(int index, T data);

        void DeleteHead();

        void DeleteTail();

        void Delete(T data);

        int Search(T data);
    }
}
