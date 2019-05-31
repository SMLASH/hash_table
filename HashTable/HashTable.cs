using System;
using list;

namespace hashtable
{   
    public class HashTable<TKey, TValue> : IHashTable<TKey, TValue> where TKey : IComparable
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
        
        public void Delete(TKey key)
        {
            _table[HashIndex(key)].Delete(key);
        }

        public TValue Get(TKey key)
        {
            return _table[HashIndex(key)].GetValue(key);
        }

        private int HashIndex(TKey value)
        {
            return value.GetHashCode() % Count;
        }
        
        private class Dictionary
        {
            private readonly List<Pair> _list = new List<Pair>();

            public TValue GetValue(TKey key)
            {
                for (int i = 0; i < Count; i++)
                {
                    var pair = _list[i];
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

            public void Delete(TKey key)
            {
                var pair = GetPair(key);
                _list.DeleteValue(pair);
            }

            private Pair GetPair(TKey key)
            {
                for (int i = 0; i < Count; i++)
                {
                    var pair = _list[i];
                    if (key.Equals(pair.Key))
                    {
                        return pair;
                    }
                }
                throw new ArgumentException("No such key in the Dictionary");
            }

            private class Pair : IComparable
            {
                public TKey Key { get; }
                public TValue Value { get; }

                public Pair(TKey key, TValue value)
                {
                    Key = key;
                    Value = value;
                }

                public int CompareTo(object obj)
                {
                    var other = (Pair) obj;
                    if (Key.Equals(other.Key) && Value.Equals(other.Value))
                    {
                        return 0;
                    }

                    return 1;
                }
            }
        }
    }
}