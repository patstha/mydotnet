using FluentAssertions;
using hellolib;
using System.Collections.Generic;
using Xunit;

namespace tests
{
    public class MinimumCoinTests
    {
        private MinimumCoin minimumCoin;
        public MinimumCoinTests()
        {
            List<int> coinValues = new() { 1, 5, 10, 25 };
            minimumCoin = new MinimumCoin(CoinSet: coinValues, RepeatFactor: 5);
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
            Assert.Equal(input, minimumCoin.GetCount(input));
        }

        [Fact]
        public void GetCaseOfTwoCoins()
        {
            if (minimumCoin.CoinSet.Count > 1 && !minimumCoin.CoinSet.Contains(minimumCoin.CoinSet[0] + minimumCoin.CoinSet[1]))
            {
                int total = minimumCoin.CoinSet[0] + minimumCoin.CoinSet[1];
                int actual = minimumCoin.GetCount(total);
                Assert.Equal(2, actual);
            }
        }

        [Fact]
        public void GetCaseOfFourCoins()
        {
            int total = minimumCoin.CoinSet[0] + minimumCoin.CoinSet[1] + minimumCoin.CoinSet[2] + minimumCoin.CoinSet[3];
            if (minimumCoin.CoinSet.Count > 1 && !minimumCoin.CoinSet.Contains(total))
            {
                ;
                int actual = minimumCoin.GetCount(total);
                Assert.Equal(4, actual);
            }
        }

        [Fact]
        public void GetCaseOfEightCoins()
        {
            int total = minimumCoin.CoinSet[0] + minimumCoin.CoinSet[1] + minimumCoin.CoinSet[2] + minimumCoin.CoinSet[3] + minimumCoin.CoinSet[0] + minimumCoin.CoinSet[1] + minimumCoin.CoinSet[2] + minimumCoin.CoinSet[3];
            if (minimumCoin.CoinSet.Count > 1 && !minimumCoin.CoinSet.Contains(total))
            {
                ;
                int actual = minimumCoin.GetCount(total);
                Assert.True(6 >= actual);
            }
        }

        [Fact]
        public void GetFreqLabsTwoCoins()
        {
            List<int> coinValues = new() { 1, 120, 200 };
            minimumCoin = new MinimumCoin(CoinSet: coinValues, RepeatFactor: 6);
            Assert.Equal(2, minimumCoin.GetCount(240));
        }
    }
}
