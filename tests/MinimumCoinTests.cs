using System.Linq;
using Xunit;
using hellolib;
using System.Collections.Generic;

namespace tests
{
    public class MinimumCoinTests
    {
        MinimumCoin minimumCoin;
        public MinimumCoinTests()
        {
            var coinValues = new List<int>() { 1, 5, 10, 25 };
            minimumCoin = new MinimumCoin(CoinSet: coinValues, RepeatFactor: 6);
        }

        [Fact]
        public void Freebie()
        {
            Assert.Equal(4, 2 + 2);
        }

        [Fact]
        public void GetTrivialCaseOfZeroCoin()
        {
            Assert.Equal(0, minimumCoin.getCount(0));
        }

        [Fact]
        public void GetTrivialCaseOfOneCoin()
        {
            foreach (int i in minimumCoin.CoinSet)
            {
                Assert.Equal(1, minimumCoin.getCount(i));
            }
        }

        [Fact]
        public void GetCaseOfTwoCoins()
        {
            if (minimumCoin.CoinSet.Count > 1 && !minimumCoin.CoinSet.Contains(minimumCoin.CoinSet[0] + minimumCoin.CoinSet[1]))
            {
                int total = minimumCoin.CoinSet[0] + minimumCoin.CoinSet[1];
                int actual = minimumCoin.getCount(total);
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
                int actual = minimumCoin.getCount(total);
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
                int actual = minimumCoin.getCount(total);
                Assert.True(6 >= actual);
            }
        }

        [Fact]
        public void GetFreqLabsTwoCoins()
        {
            var coinValues = new List<int>() { 1, 120, 200 };
            minimumCoin = new MinimumCoin(CoinSet: coinValues, RepeatFactor: 6);
            Assert.Equal(2, minimumCoin.getCount(240));
        }
    }
}
