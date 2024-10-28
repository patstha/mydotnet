namespace tests;

public class FindClosestNumberToZeroTests
{
    private readonly ILogger<FindClosestNumberToZero> _logger = Substitute.For<ILogger<FindClosestNumberToZero>>();
    
    [Fact]
    public void FindClosestNumber_EmptyArray_ReturnsZero()
    {
        // arrange
        int[] nums = [];
        const int expected = 0;

        // act 
        FindClosestNumberToZero find = new(_logger);
        int actual = find.FindClosestNumber(nums);

        // assert 
        actual.Should().Be(expected);
    }

    [Fact]
    public void FindClosestNumber_SingleElementArray_ReturnsElement()
    {
        // arrange
        int[] nums = [5];
        const int expected = 5;

        // act 
        FindClosestNumberToZero find = new(_logger);
        int actual = find.FindClosestNumber(nums);

        // assert 
        actual.Should().Be(expected);
    }

    [Fact]
    public void FindClosestNumber_PositiveAndNegativeNumbers_ReturnsClosest()
    {
        // arrange
        int[] nums = [-4, -2, 1, 4, 8];
        const int expected = 1;

        // act 
        FindClosestNumberToZero find = new(_logger);
        int actual = find.FindClosestNumber(nums);

        // assert 
        actual.Should().Be(expected);
    }

    [Fact]
    public void FindClosestNumber_MultipleClosestNumbers_ReturnsLargest()
    {
        // arrange
        int[] nums = [2, -1, 1];
        const int expected = 1;

        // act 
        FindClosestNumberToZero find = new(_logger);
        int actual = find.FindClosestNumber(nums);

        // assert 
        actual.Should().Be(expected);
    }

    [Fact]
    public void FindClosestNumber_AllPositiveNumbers_ReturnsSmallest()
    {
        // arrange
        int[] nums = [3, 5, 7, 9];
        const int expected = 3;

        // act 
        FindClosestNumberToZero find = new(_logger);
        int actual = find.FindClosestNumber(nums);

        // assert 
        actual.Should().Be(expected);
    }

    [Fact]
    public void FindClosestNumber_AllNegativeNumbers_ReturnsLargestNegative()
    {
        // arrange
        int[] nums = [-3, -5, -7, -9];
        const int expected = -3;

        // act 
        FindClosestNumberToZero find = new(_logger);
        int actual = find.FindClosestNumber(nums);

        // assert 
        actual.Should().Be(expected);
    }

    [Fact]
    public void FindClosestNumber_ShouldReturnNegative100000()
    {
        // arrange
        int[] nums = [-100000, -100000];
        const int expected = -100000;

        // act 
        FindClosestNumberToZero find = new(_logger);
        int actual = find.FindClosestNumber(nums);

        // assert 
        actual.Should().Be(expected);
    }
}
