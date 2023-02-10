using System;
using Xunit;
using hellolib;
namespace tests;

public class BubbleSortTests
{
    [Fact]
    public void SortSingleElementSortedArray()
    {
        int[] input = { 1 };
        Assert.Equal(BubbleSort.SortIntegers(input), input);
    }
    [Fact]
    public void SortTwoElementSortedArray()
    {
        int[] input = { 1, 2 };
        Assert.Equal(BubbleSort.SortIntegers(input), input);
    }
    [Fact]
    public void SortThreeElementSortedArray()
    {
        int[] input = { 1, 2, 3 };
        Assert.Equal(input, BubbleSort.SortIntegers(input));
    }
    [Fact]
    public void SortFourElementSortedArray()
    {
        int[] input = { 1, 2, 3, 4 };
        Assert.Equal(input, BubbleSort.SortIntegers(input));
    }
    [Fact]
    public void SortThreeElementUnsortedArray()
    {
        int[] input = { 3, 2, 1 };
        int[] expectedOutput = { 1, 2, 3 };
        Assert.Equal(expectedOutput, BubbleSort.SortIntegers(input));
    }
}