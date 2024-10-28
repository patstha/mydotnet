namespace tests;

public class FindClosestNumberToZeroTests
{
    private readonly ILogger<FindClosestNumberToZero> _logger;

    public FindClosestNumberToZeroTests() => _logger = Substitute.For<ILogger<FindClosestNumberToZero>>();

    [Fact]
    public void FindClosestNumber_ShouldReturn1()
    {
        // arrange
        int[] nums = [-4, -2, 1, 4, 8];
        int expected = 1;

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
        int expected = -100000;

        // act 
        FindClosestNumberToZero find = new(_logger);
        int actual = find.FindClosestNumber(nums);

        // assert 
        actual.Should().Be(expected);
    }
}
