namespace tests;

public class MinimumTotalDistanceTraveledTests
{
    [Fact]
    public void MinimumTotalDistanceTraveled()
    {
        // arrange 
        List<int> robot = [0, 4, 6];
        int[][] factory = [[2, 2], [6, 2]];
        long expected = 4;
        
        // act 
        MinimumTotalDistanceTraveled solution = new();
        long actual = solution.MinimumTotalDistance(robot, factory);
        
        // assert 
        actual.Should().Be(expected);
    }
}