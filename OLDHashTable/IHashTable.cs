using System;

namespace HashTable
{
    public interface IHashTable<TKey,TValue> where TKey : IComparable
    {
        void Add(TKey key, TValue value);
        TValue Get(TKey key);
    }
}