namespace tests;
public class PascalsTriangleTests
{
    [Fact]
    public void GeneratePascalsTriangle_WithZeroRows_ReturnsEmptyList()
    {
        List<List<int>> result = PascalTriangle.GeneratePascalsTriangle(0);
        Assert.Empty(result);
    }

    [Fact]
    public void GeneratePascalsTriangle_WithOneRow_ReturnsCorrectTriangle()
    {
        List<List<int>> expected = [[1]];
        List<List<int>> result = PascalTriangle.GeneratePascalsTriangle(1);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GeneratePascalsTriangle_WithFiveRows_ReturnsCorrectTriangle()
    {
        List<List<int>> expected =
        [
            [1],
            [1, 1],
            [1, 2, 1],
            [1, 3, 3, 1],
            [1, 4, 6, 4, 1]
        ];
        List<List<int>> result = PascalTriangle.GeneratePascalsTriangle(5);
        Assert.Equal(expected, result);
    }
}
