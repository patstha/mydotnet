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
        [Fact]
        public void BinarySearchDoesNotExist()
        {
            int[] arrayToSearch = { 1, 2, 3, 4, 5, 6 };
            int queryItem = 9;
            Assert.True(MySearch.BinarySearchIntegers(arrayToSearch, queryItem).Equals(-1));
        }
        [Fact]
        public void BinarySearchDoesNotExistOdd()
        {
            int[] arrayToSearch = { 1, 2, 3, 4, 5, 6, 7 };
            int queryItem = 9;
            Assert.True(MySearch.BinarySearchIntegers(arrayToSearch, queryItem).Equals(-1));
        }
        [Fact]
        public void BinarySearchDoesExist()
        {
            int[] arrayToSearch = { 1, 2, 3, 4, 5, 6 };
            int queryItem = 1;
            Assert.True(MySearch.BinarySearchIntegers(arrayToSearch, queryItem).Equals(0));
        }
        [Fact]
        public void BinarySearchDoesExistOdd()
        {
            int[] arrayToSearch = { 1, 2, 3, 4, 5, 6, 7 };
            int queryItem = 1;
            Assert.True(MySearch.BinarySearchIntegers(arrayToSearch, queryItem).Equals(0));
        }
        [Fact]
        public void BinarySearchDoesExist2()
        {
            int[] arrayToSearch = { 1, 2, 3, 4, 5, 6 };
            int queryItem = 2;
            Assert.True(MySearch.BinarySearchIntegers(arrayToSearch, queryItem).Equals(1));
        }
        [Fact]
        public void BinarySearchDoesExistOdd2()
        {
            int[] arrayToSearch = { 1, 2, 3, 4, 5, 6, 7 };
            int queryItem = 2;
            Assert.True(MySearch.BinarySearchIntegers(arrayToSearch, queryItem).Equals(1));
        }
        [Fact]
        public void BinarySearchDoesExist3()
        {
            int[] arrayToSearch = { 1, 2, 3, 4, 5, 6 };
            int queryItem = 3;
            Assert.True(MySearch.BinarySearchIntegers(arrayToSearch, queryItem).Equals(2));
        }
        [Fact]
        public void BinarySearchDoesExistOdd3()
        {
            int[] arrayToSearch = { 1, 2, 3, 4, 5, 6, 7 };
            int queryItem = 3;
            Assert.True(MySearch.BinarySearchIntegers(arrayToSearch, queryItem).Equals(2));
        }
                [Fact]
        public void BinarySearchDoesExist4()
        {
            int[] arrayToSearch = { 1, 2, 3, 4, 5, 6 };
            int queryItem = 4;
            Assert.True(MySearch.BinarySearchIntegers(arrayToSearch, queryItem).Equals(3));
        }
        [Fact]
        public void BinarySearchDoesExistOdd4()
        {
            int[] arrayToSearch = { 1, 2, 3, 4, 5, 6, 7 };
            int queryItem = 4;
            Assert.True(MySearch.BinarySearchIntegers(arrayToSearch, queryItem).Equals(3));
        }
    }
}