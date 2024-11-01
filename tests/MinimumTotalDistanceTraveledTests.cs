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
        List<int> robot = [3, 8, 12];
        int[][] factory = [[5, 1], [10, 2]];
        const long expected = 7;
        
        // act 
        long actual = MinimumTotalDistanceTraveled.MinimumTotalDistance(robot, factory);
        
        // assert 
        actual.Should().Be(expected);
    }

    [Fact]
    public void MinimumTotalDistanceTraveled3()
    {
        // arrange 
        List<int> robot = [-5, -3, 2, 7];
        int[][] factory = [[-4, 2], [6, 2]];
        const long expected = 10;
        
        // act 
        long actual = MinimumTotalDistanceTraveled.MinimumTotalDistance(robot, factory);
        
        // assert 
        actual.Should().Be(expected);
    }

    [Fact]
    public void MinimumTotalDistanceTraveled4()
    {
        // arrange 
        List<int> robot = [0, 0, 0];
        int[][] factory = [[0, 3]];
        const long expected = 0;
        
        // act 
        long actual = MinimumTotalDistanceTraveled.MinimumTotalDistance(robot, factory);
        
        // assert 
        actual.Should().Be(expected);
    }

    [Fact]
    public void MinimumTotalDistanceTraveled5()
    {
        // arrange 
        List<int> robot = [1, 2, 3, 4];
        int[][] factory = [[2, 2], [3, 2]];
        const long expected = 2;
        
        // act 
        long actual = MinimumTotalDistanceTraveled.MinimumTotalDistance(robot, factory);
        
        // assert 
        actual.Should().Be(expected);
    }

    [Fact]
    public void MinimumTotalDistanceTraveled6()
    {
        // arrange 
        List<int> robot = [-10, -5, 0, 5, 10];
        int[][] factory = [[-7, 1], [7, 1], [0, 3]];
        const long expected = 25;
        
        // act 
        long actual = MinimumTotalDistanceTraveled.MinimumTotalDistance(robot, factory);
        
        // assert 
        actual.Should().Be(expected);
    }

    [Fact]
    public void MinimumTotalDistanceTraveled7()
    {
        // arrange 
        List<int> robot = [10, 20, 30];
        int[][] factory = [[15, 1], [25, 2]];
        const long expected = 20;
        
        // act 
        long actual = MinimumTotalDistanceTraveled.MinimumTotalDistance(robot, factory);
        
        // assert 
        actual.Should().Be(expected);
    }

    [Fact]
    public void MinimumTotalDistanceTraveled8()
    {
        // arrange 
        List<int> robot = [-1, -2, -3, -4];
        int[][] factory = [[-2, 2], [-3, 2]];
        const long expected = 2;
        
        // act 
        long actual = MinimumTotalDistanceTraveled.MinimumTotalDistance(robot, factory);
        
        // assert 
        actual.Should().Be(expected);
    }

    [Fact]
    public void MinimumTotalDistanceTraveled9()
    {
        // arrange 
        List<int> robot = [5, 10, 15, 20];
        int[][] factory = [[10, 2], [20, 2]];
        const long expected = 10;
        
        // act 
        long actual = MinimumTotalDistanceTraveled.MinimumTotalDistance(robot, factory);
        
        // assert 
        actual.Should().Be(expected);
    }

    [Fact]
    public void MinimumTotalDistanceTraveled10()
    {
        // arrange 
        List<int> robot = [0, 100, 200];
        int[][] factory = [[50, 1], [150, 2]];
        const long expected = 200;
        
        // act 
        long actual = MinimumTotalDistanceTraveled.MinimumTotalDistance(robot, factory);
        
        // assert 
        actual.Should().Be(expected);
    }

    [Fact]
    public void MinimumTotalDistanceTraveled11()
    {
        // arrange 
        List<int> robot = [-100, -50, 0, 50, 100];
        int[][] factory = [[-75, 1], [75, 1], [0, 3]];
        const long expected = 250;
        
        // act 
        long actual = MinimumTotalDistanceTraveled.MinimumTotalDistance(robot, factory);
        
        // assert 
        actual.Should().Be(expected);
    }
}
