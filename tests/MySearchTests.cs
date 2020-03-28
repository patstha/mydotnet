using System;
using Xunit;
using hellolib;
namespace tests
{
    public class MySearchTests
    {
        [Fact]
        public void LinearSearchTestDoesNotExist()
        {
            int[] arrayToSearch = { 1, 2, 3, 4, 5, 6 };
            int queryItem = 9;
            Assert.False(MySearch.LinearSearchIntegers(arrayToSearch, queryItem));
        }
        [Fact]
        public void LinearSearchTestDoesExist()
        {
            int[] arrayToSearch = { 1, 2, 3, 4, 5, 6 };
            int queryItem = 4;
            Assert.True(MySearch.LinearSearchIntegers(arrayToSearch, queryItem));
        }
    }
}