using System;

namespace hashtable
{
    public interface IHashTable<TKey,TValue> where TKey : IComparable
    {
        void Add(TKey key, TValue value);
        void Delete(TKey key);
        TValue Get(TKey key);
    }
}