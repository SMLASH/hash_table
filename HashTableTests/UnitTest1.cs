using System;
using Xunit;
using HashTable;

namespace HashTableTests
{
    public class UnitTest1
    {
        [Fasct]
        public void AddTest()
        {
            const int expected = 4;
            var table = new HashTable<int, int>;
            table.Add(4, 4);
            Assert(expected, table.Get(4));
        }
    }
}