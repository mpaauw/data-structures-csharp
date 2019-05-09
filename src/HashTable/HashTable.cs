using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    public class HashTable<TKey, TValue> : IHashTable<TKey, TValue>
    {
        private int size;
        private TValue[] hashTable;

        public HashTable(int size = -1)
        {
            this.size = (size == -1) ? new Random().Next(1, 100) : size;
            this.hashTable = new TValue[this.size];
        }

        public TValue Get(TKey key)
        {
            throw new NotImplementedException();
        }

        public void Set(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public TValue Delete(TKey key)
        {
            throw new NotImplementedException();
        }
    }
}
