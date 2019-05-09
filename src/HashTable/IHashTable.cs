using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    public interface IHashTable<TValue>
    {
        TValue Get(string key);

        void Set(string key, TValue value);

        TValue Delete(string key);
    }
}
