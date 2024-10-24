using System.Collections.Generic;

namespace tests;

public class MinimumCoinTests
{
    private MinimumCoin _minimumCoin;
    public MinimumCoinTests()
    {
        List<int> coinValues = [1, 5, 10, 25];
        _minimumCoin = new MinimumCoin(coinSet: coinValues, repeatFactor: 5);
    }

    [Theory]
    [InlineData(2, 2, 4)]
    [InlineData(1, 2, 3)]
    [InlineData(0, 2, 2)]
    [InlineData(2, 0, 2)]
    [InlineData(9, 5, 14)]
    [InlineData(24, 24, 48)]
    public void Freebie(int firstNumber, int secondNumber, int expectedSum)
    {
        // Arrange, Act
        int actualSum = firstNumber + secondNumber;

        // Assert 
        _ = actualSum.Should().Be(expectedSum, $"because {firstNumber} + {secondNumber} is {expectedSum}", new List<int>[firstNumber, secondNumber, actualSum]);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void GetTrivialCase(int input)
    {
        Assert.Equal(input, _minimumCoin.GetCount(input));
    }

    [Fact]
    public void GetCaseOfTwoCoins()
    {
        if (_minimumCoin.CoinSet.Count > 1 && !_minimumCoin.CoinSet.Contains(_minimumCoin.CoinSet[0] + _minimumCoin.CoinSet[1]))
        {
            int total = _minimumCoin.CoinSet[0] + _minimumCoin.CoinSet[1];
            int actual = _minimumCoin.GetCount(total);
            Assert.Equal(2, actual);
        }
    }

    [Fact]
    public void GetCaseOfFourCoins()
    {
        int total = _minimumCoin.CoinSet[0] + _minimumCoin.CoinSet[1] + _minimumCoin.CoinSet[2] + _minimumCoin.CoinSet[3];
        if (_minimumCoin.CoinSet.Count > 1 && !_minimumCoin.CoinSet.Contains(total))
        {
            int actual = _minimumCoin.GetCount(total);
            Assert.Equal(4, actual);
        }
    }

    [Fact]
    public void GetCaseOfEightCoins()
    {
        int total = _minimumCoin.CoinSet[0] + _minimumCoin.CoinSet[1] + _minimumCoin.CoinSet[2] + _minimumCoin.CoinSet[3] + _minimumCoin.CoinSet[0] + _minimumCoin.CoinSet[1] + _minimumCoin.CoinSet[2] + _minimumCoin.CoinSet[3];
        if (_minimumCoin.CoinSet.Count > 1 && !_minimumCoin.CoinSet.Contains(total))
        {
            int actual = _minimumCoin.GetCount(total);
            Assert.True(6 >= actual);
        }
    }

    [Fact]
    public void GetFreqLabsTwoCoins()
    {
        List<int> coinValues = [1, 120, 200];
        _minimumCoin = new MinimumCoin(coinSet: coinValues, repeatFactor: 6);
        Assert.Equal(2, _minimumCoin.GetCount(240));
    }

    [Fact]
    public void GetCount_ShouldReturnCorrectCount()
    {
        // Arrange
        List<int> coinSet = [1, 2, 5];
        int repeatFactor = 3;
        MinimumCoin minimumCoin = new(coinSet, repeatFactor);
        int total = 11;
        int expectedCount = 3; // 5 + 5 + 1

        // Act
        int count = minimumCoin.GetCount(total);

        // Assert
        count.Should().Be(expectedCount);
    }

    [Fact]
    public void GetCount_ShouldReturnZeroWhenTotalIsLessThanMinimumCoin()
    {
        // Arrange
        List<int> coinSet = [2, 3, 5];
        int repeatFactor = 3;
        MinimumCoin minimumCoin = new(coinSet, repeatFactor);
        int total = 1;
        int expectedCount = 0;

        // Act
        int count = minimumCoin.GetCount(total);

        // Assert
        count.Should().Be(expectedCount);
    }

    [Fact]
    public void GetCount_ShouldReturnOneWhenTotalIsInCoinSet()
    {
        // Arrange
        List<int> coinSet = [1, 2, 5];
        int repeatFactor = 3;
        MinimumCoin minimumCoin = new(coinSet, repeatFactor);
        int total = 5;
        int expectedCount = 1;

        // Act
        int count = minimumCoin.GetCount(total);

        // Assert
        count.Should().Be(expectedCount);
    }
}
