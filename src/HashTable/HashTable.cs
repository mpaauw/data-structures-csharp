using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTable
{
    public class HashTable<TValue> : IHashTable<TValue>
    {
        private LinkedList<HashEntry<TValue>>[] hashTable;
        private int numEntries = 0;

        public HashTable(int size = -1)
        {
            size = (size == -1) ? new Random().Next(1, 100) : size;
            this.hashTable = new LinkedList<HashEntry<TValue>>[size];
            for (int i = 0; i < this.hashTable.Length; i++)
            {
                hashTable[i] = new LinkedList<HashEntry<TValue>>();
            }
        }

        public TValue Get(string key)
        {
            int hashLocation = this.Hash(key, this.hashTable.Length);
            HashEntry<TValue> entry = null;
            if(this.hashTable[hashLocation] != null)
            {
                entry = this.hashTable[hashLocation].Where(x => x.Key == key).FirstOrDefault();
            }
            return entry.Value;
        }

        public void Set(string key, TValue value)
        {
            int hashLocation = this.Hash(key, this.hashTable.Length);
            if(this.hashTable[hashLocation] is null)
            {
                this.hashTable[hashLocation] = new LinkedList<HashEntry<TValue>>();
            }
            this.hashTable[hashLocation].AddLast(
                new HashEntry<TValue>
                {
                    Key = key,
                    Value = value
                });
            this.numEntries++;
            this.Resize();
        }

        public TValue Delete(string key)
        {
            int hashLocation = this.Hash(key, this.hashTable.Length);
            HashEntry<TValue> entry = null;
            if (this.hashTable[hashLocation] != null)
            {
                entry = this.hashTable[hashLocation].Where(x => x.Key == key).FirstOrDefault();
                if(entry != null)
                {
                    this.hashTable[hashLocation].Remove(entry);
                }
            }
            return entry.Value;
        }

        private int Hash(string key, int tableSize)
        {
             return key.GetHashCode() % tableSize;
        }

        private void Resize()
        {
            double loadFactor = (double)this.numEntries / this.hashTable.Length;

            // upsize if load is greater than to 75%, to potentially decrease bucket size
            // downsize if load is less than 25%, to free up memory
            if (loadFactor > 0.75 || loadFactor < 0.10) 
            {
                // create
                var newHashTable = new LinkedList<HashEntry<TValue>>[(loadFactor > 0.75) ? this.hashTable.Length * 2 : this.hashTable.Length / 2]; // double table size if above threshold, halve if below
                
                // populate via re-hashing:
                foreach(var bucket in this.hashTable)
                {
                    if(bucket != null)
                    {
                        foreach(var entry in bucket)
                        {
                            int hashLocation = this.Hash(entry.Key, newHashTable.Length);
                            newHashTable[hashLocation] = new LinkedList<HashEntry<TValue>>();
                            newHashTable[hashLocation].AddLast(
                                new HashEntry<TValue>
                                {
                                    Key = entry.Key,
                                    Value = entry.Value
                                });
                        }
                    }
                }

                // vacate:
                this.hashTable = newHashTable;
            }
        }

        public class HashEntry<T>
        {
            public string Key { get; set; }

            public T Value { get; set; }
        }
    }
}
