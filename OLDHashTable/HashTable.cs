using System;


namespace HashTable
{
    internal class HashTable<TKey, TValue> : IHashTable<TKey, TValue> where TKey : IComparable
    {
        private const int Count = 8;
        private readonly Dictionary[] _table = new Dictionary[Count];

        public HashTable()
        {
            for (var i = 0; i < Count; i++)
            {
                _table[i] = new Dictionary();
            }
        }
        
        public void Add(TKey key, TValue value)
        {
            _table[HashIndex(key)].Add(key, value);
        }

        public TValue Get(TKey key)
        {
            return _table[HashIndex(key)].Get(key);
        }

        private int HashIndex(TKey value)
        {
            return value.GetHashCode() % Count;
        }

        private class Dictionary
        {
            private readonly List<Pair> _list = new List<Pair>();

            public TValue Get(TKey key)
            {
                foreach (var pair in _list)
                {
                    if (key.Equals(pair.Key))
                    {
                        return pair.Value;
                    }
                }
                throw new ArgumentException("No such key in the Dictionary");
            }

            public void Add(TKey key, TValue value)
            {
                _list.Add(new Pair(key, value));
            }
            
            private class Pair
            {
                public TKey Key { get; }
                public TValue Value { get; }

                public Pair(TKey key, TValue value)
                {
                    Key = key;
                    Value = value;
                }

            }
        
        }
    }
}