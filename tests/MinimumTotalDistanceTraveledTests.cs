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
        int[][] factory = [[-2,1],[2,1]];
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
        List<int> robot = new List<int> { 3, 8, 12 };
        int[][] factory = new int[][] { new int[] { 5, 1 }, new int[] { 10, 2 } };
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
        List<int> robot = new List<int> { -5, -3, 2, 7 };
        int[][] factory = new int[][] { new int[] { -4, 2 }, new int[] { 6, 2 } };
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
        List<int> robot = new List<int> { 0, 0, 0 };
        int[][] factory = new int[][] { new int[] { 0, 3 } };
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
        List<int> robot = new List<int> { 1, 2, 3, 4 };
        int[][] factory = new int[][] { new int[] { 2, 2 }, new int[] { 3, 2 } };
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
        List<int> robot = new List<int> { -10, -5, 0, 5, 10 };
        int[][] factory = new int[][] { new int[] { -7, 1 }, new int[] { 7, 1 }, new int[] { 0, 3 } };
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
        List<int> robot = new List<int> { 10, 20, 30 };
        int[][] factory = new int[][] { new int[] { 15, 1 }, new int[] { 25, 2 } };
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
        List<int> robot = new List<int> { -1, -2, -3, -4 };
        int[][] factory = new int[][] { new int[] { -2, 2 }, new int[] { -3, 2 } };
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
        List<int> robot = new List<int> { 5, 10, 15, 20 };
        int[][] factory = new int[][] { new int[] { 10, 2 }, new int[] { 20, 2 } };
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
        List<int> robot = new List<int> { 0, 100, 200 };
        int[][] factory = new int[][] { new int[] { 50, 1 }, new int[] { 150, 2 } };
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
        List<int> robot = new List<int> { -100, -50, 0, 50, 100 };
        int[][] factory = new int[][] { new int[] { -75, 1 }, new int[] { 75, 1 }, new int[] { 0, 3 } };
        const long expected = 250;
        
        // act 
        long actual = MinimumTotalDistanceTraveled.MinimumTotalDistance(robot, factory);
        
        // assert 
        actual.Should().Be(expected);
    }
}
