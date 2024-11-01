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
        long actual = MinimumTotalDistanceTraveled.MinimumTotalDistance(robot, factory);
        
        // assert 
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void MinimumTotalDistanceTraveled1()
    {
        // arrange 
        List<int> robot = [1, -1];
        int[][] factory = [[-2, 1], [2, 1]];
        const long expected = 2;
        
        // act 
        long actual = MinimumTotalDistanceTraveled.MinimumTotalDistance(robot, factory);
        
        // assert 
        actual.Should().Be(expected);
    }
    
    [Fact]
    public void MinimumTotalDistanceTraveled2()
    {
        // arrange 
        List<int> robot = [9,11,99,101];
        int[][] factory = [[10,1],[7,1],[14,1],[100,1],[96,1],[103,1]];
        const long expected = 6;
        
        // act 
        long actual = MinimumTotalDistanceTraveled.MinimumTotalDistance(robot, factory);
        
        // assert 
        actual.Should().Be(expected);
    }

}
