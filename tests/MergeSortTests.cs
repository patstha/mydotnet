using hellolib;
namespace tests;

public class MergeSortTests
{
    [Fact]
    public void SortSingleElementSortedArray()
    {
        int[] input = { 1 };
        int[] output = { 1 };
        MergeSort.SortIntegers(output);
        Assert.Equal(output, input);
    }
    [Fact]
    public void SortTwoElementSortedArray()
    {
        int[] input = { 1, 2 };
        int[] output = { 1, 2 };
        MergeSort.SortIntegers(output);
        Assert.Equal(output, input);
    }
    [Fact]
    public void SortThreeElementSortedArray()
    {
        int[] input = { 1, 2, 3 };
        int[] output = { 1, 2, 3 };
        MergeSort.SortIntegers(output);
        Assert.Equal(input, output);
    }
    [Fact]
    public void SortFourElementSortedArray()
    {
        int[] input = { 1, 2, 3, 4 };
        int[] output = { 1, 2, 3, 4 };
        MergeSort.SortIntegers(output);
        Assert.Equal(input, output);
    }
    [Fact]
    public void SortThreeElementUnsortedArray()
    {
        int[] input = { 3, 2, 1 };
        int[] output = { 3, 2, 1 };
        int[] expectedOutput = { 1, 2, 3 };
        MergeSort.SortIntegers(output);
        Assert.Equal(expectedOutput, output);
    }
    [Fact]
    public void SortIntegers_ShouldSortArrayInAscendingOrder()
    {
        // Arrange
        int[] input = new int[] { 5, 3, 1, 4, 2 };
        int[] expected = new int[] { 1, 2, 3, 4, 5 };

        // Act
        MergeSort.SortIntegers(input);

        // Assert
        input.Should().Equal(expected);
    }

    [Fact]
    public void SortIntegers_ShouldNotChangeAlreadySortedArray()
    {
        // Arrange
        int[] input = new int[] { 1, 2, 3, 4, 5 };
        int[] expected = new int[] { 1, 2, 3, 4, 5 };

        // Act
        MergeSort.SortIntegers(input);

        // Assert
        input.Should().Equal(expected);
    }

    [Fact]
    public void SortIntegers_ShouldNotChangeArrayWithSameElements()
    {
        // Arrange
        int[] input = new int[] { 1, 1, 1, 1 };
        int[] expected = new int[] { 1, 1, 1, 1 };

        // Act
        MergeSort.SortIntegers(input);

        // Assert
        input.Should().Equal(expected);
    }
}