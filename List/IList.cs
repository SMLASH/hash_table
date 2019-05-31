using System;

namespace list
{
    public interface IList<T> where T : IComparable
    {
        bool Find(T value);
        void DeleteValue(T value);
        void Delete(int index);
        void Add(T value);
        T GetValue(int index);
    }
}