using System.Collections.Generic;

namespace tests;
public class PascalsTriangleTests
{
    [Fact]
    public void GeneratePascalsTriangle_WithZeroRows_ReturnsEmptyList()
    {
        var result = PascalTriangle.GeneratePascalsTriangle(0);
        Assert.Empty(result);
    }

    [Fact]
    public void GeneratePascalsTriangle_WithOneRow_ReturnsCorrectTriangle()
    {
        var expected = new List<List<int>> { new List<int> { 1 } };
        var result = PascalTriangle.GeneratePascalsTriangle(1);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GeneratePascalsTriangle_WithFiveRows_ReturnsCorrectTriangle()
    {
        var expected = new List<List<int>>
        {
            new List<int> { 1 },
            new List<int> { 1, 1 },
            new List<int> { 1, 2, 1 },
            new List<int> { 1, 3, 3, 1 },
            new List<int> { 1, 4, 6, 4, 1 }
        };
        var result = PascalTriangle.GeneratePascalsTriangle(5);
        Assert.Equal(expected, result);
    }
}
