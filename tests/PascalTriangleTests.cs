﻿using System.Collections.Generic;

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
        List<List<int>> expected = [new List<int> { 1 }];
        List<List<int>> result = PascalTriangle.GeneratePascalsTriangle(1);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GeneratePascalsTriangle_WithFiveRows_ReturnsCorrectTriangle()
    {
        List<List<int>> expected =
        [
            new List<int> { 1 },
            new List<int> { 1, 1 },
            new List<int> { 1, 2, 1 },
            new List<int> { 1, 3, 3, 1 },
            new List<int> { 1, 4, 6, 4, 1 }
        ];
        List<List<int>> result = PascalTriangle.GeneratePascalsTriangle(5);
        Assert.Equal(expected, result);
    }
}