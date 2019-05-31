using System;
 using Xunit;
 using hashtable;
 
 namespace HashTableTest
 {
     public class UnitTest1
     {
         [Fact]
         public void AddTest()
         {
             const int expected = 4;
             var expectedKey = expected;
             var table = new HashTable<int, int>();
             table.Add(expectedKey, expected);
             var actual = table.Get(expectedKey);
             Assert.Equal(expected, actual);
         }
 
         [Fact]
         public void DeleteTest()
         {
             const int expected = 4;
             const int addictional = 7;
             var addictionalKey = addictional;
             var expectedKey = expected;
             var table = new HashTable<int, int>();
             table.Add(expectedKey, expected);
             table.Add(addictionalKey, addictional);
             table.Delete(expectedKey);
             Assert.Null(table);
         }
     }
 }