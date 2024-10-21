namespace tests;

public class FindClosestNumberToZeroTests
{
    [Fact]
    public void FindClosestNumber_ShouldReturn1()
    {
        // arrange
        int[] nums = { -4, -2, 1, 4, 8 };
        int expected = 1;

        // act 
        FindClosestNumberToZero find = new();
        int actual = find.FindClosestNumber(nums);

        // assert 
        actual.Should().Be(expected);
    }
    // [-100000,-100000]

    [Fact]
    public void FindClosestNumber_ShouldReturn2()
    {
        // arrange
        int[] nums = { -100000, -100000 };
        int expected = -100000;

        // act 
        FindClosestNumberToZero find = new();
        int actual = find.FindClosestNumber(nums);

        // assert 
        actual.Should().Be(expected);
    }
}
