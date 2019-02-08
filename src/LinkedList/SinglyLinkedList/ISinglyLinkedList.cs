namespace LinkedList.SinglyLinkedList
{
    public interface ISinglyLinkedList<T>
    {
        /// <summary>
        /// Inserts a new node at the head (front) of the list.
        /// </summary>
        /// <param name="data">Data to be used within the new node.</param>
        void InsertHead(T data);

        /// <summary>
        /// Inserts a new node at the tail (end) of the list
        /// </summary>
        /// <param name="data">Data to be used within the new node.</param>
        void InsertTail(T data);

        /// <summary>
        /// Inserts a new node at a specified index within the list.
        /// Uses zero-based indexing.
        /// Throws an IndexOutOfRangeException if the supplied index exists outside the bounds of the list.
        /// </summary>
        /// <param name="index">Index at which to insert the new node.</param>
        /// <param name="data">Data to be used within the new node.</param>
        void InsertAt(int index, T data);

        /// <summary>
        /// Deletes the node at the head (front) of the list.
        /// Throws a NullReferenceException if the list is empty.
        /// </summary>
        void DeleteHead();

        /// <summary>
        /// Deletes the node at the tail (end) of the list.
        /// Throws a NullReferenceException if the list is empty.
        /// </summary>
        void DeleteTail();

        /// <summary>
        /// Deletes the first instance of a node containing the specified data.
        /// If a node containing the supplied data is not found, nothing happens.
        /// </summary>
        /// <param name="data">Data specifying which node to delete.</param>
        void Delete(T data);

        /// <summary>
        /// Searches for a node containing specified data.
        /// Returns the first encountered index of the node if found, -1 if node was not found.
        /// Uses zero-based indexing.
        /// </summary>
        /// <param name="data">The data to use during search.</param>
        /// <returns>An index-based integer representing the result of the search.</returns>
        int Search(T data);
    }
}
