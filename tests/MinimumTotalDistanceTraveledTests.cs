namespace tests;

public class MinimumTotalDistanceTraveledTests
{
    [Fact]
    public void MinimumTotalDistanceTraveled0()
    {
        // arrange 
        List<int> robot = [0, 4, 6];
        int[][] factory = [[2, 2], [6, 2]];
        const long expected = 4;
        
        // act 
        MinimumTotalDistanceTraveled solution = new();
        long actual = solution.MinimumTotalDistance(robot, factory);
        
        // assert 
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void MinimumTotalDistanceTraveled1()
    {
        // arrange 
        List<int> robot = [1, -1];
        int[][] factory = [[-2,1],[2,1]];
        const long expected = 2;
        
        // act 
        MinimumTotalDistanceTraveled solution = new();
        long actual = solution.MinimumTotalDistance(robot, factory);
        
        // assert 
        actual.Should().Be(expected);
    }
}