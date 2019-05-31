using System;

namespace List
{
    public interface IList<T> where T : IComparable
    {
        bool Find(T value);
        void Delete(T value);
        void Add(T value);
        void Add(T value, int index);
        T GetValue(int index);
    }
}