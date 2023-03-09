using hellolib;
using Xunit;
namespace tests;

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
    [Fact]
    public void BinarySearchDoesExist4Twice()
    {
        int[] arrayToSearch = { 1, 2, 3, 4, 4, 5, 6 };
        int queryItem = 4;
        Assert.True(MySearch.BinarySearchIntegers(arrayToSearch, queryItem).Equals(3));
    }
    [Fact]
    public void BinarySearchDoesExistOdd4Twice()
    {
        int[] arrayToSearch = { 1, 2, 3, 4, 4, 5, 6, 7 };
        int queryItem = 4;
        Assert.True(MySearch.BinarySearchIntegers(arrayToSearch, queryItem).Equals(3));
    }
    [Fact]
    public void BinarySearchExistsKhan()
    {
        int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
        int result = MySearch.BinarySearchIntegers(primes, 73);
        Assert.Equal(20, result);
    }
}