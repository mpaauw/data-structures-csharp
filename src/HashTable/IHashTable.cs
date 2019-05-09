using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    public interface IHashTable<TKey, TValue>
    {
        TValue Get(TKey key);

        void Set(TKey key, TValue value);

        TValue Delete(TKey key);
    }
}
