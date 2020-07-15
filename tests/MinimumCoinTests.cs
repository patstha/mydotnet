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
            var coinValues = new List<int>(new int[]{ 1, 5, 10, 25 });
            this.minimumCoin = new MinimumCoin(CoinSet: coinValues, RepeatFactor: 6);
        }

        [Fact]
        public void Freebie()
        {
            Assert.Equal(4, 2 + 2);
        }

        [Fact]
        public void GetTrivialCaseOfZeroCoin()
        {
            Assert.Equal(0, this.minimumCoin.getCount(0));
        }

        [Fact]
        public void GetTrivialCaseOfOneCoin()
        {
            foreach(int i in this.minimumCoin.CoinSet)
            {
                Assert.Equal(1, this.minimumCoin.getCount(i));
            }
        }

        [Fact]
        public void GetCaseOfTwoCoins()
        {
            if (this.minimumCoin.CoinSet.Count > 1 && !this.minimumCoin.CoinSet.Contains(this.minimumCoin.CoinSet[0] + this.minimumCoin.CoinSet[1]))
            {
                int total = this.minimumCoin.CoinSet[0] + this.minimumCoin.CoinSet[1];
                int actual = this.minimumCoin.getCount(total);
                Assert.Equal(2, actual);
            }
        }

        [Fact]
        public void GetCaseOfFourCoins()
        {
            int total = this.minimumCoin.CoinSet[0] + this.minimumCoin.CoinSet[1] + this.minimumCoin.CoinSet[2] + this.minimumCoin.CoinSet[3];
            if (this.minimumCoin.CoinSet.Count > 1 && !this.minimumCoin.CoinSet.Contains(total))
            {;
                int actual = this.minimumCoin.getCount(total);
                Assert.Equal(4, actual);
            }
        }

        [Fact]
        public void GetCaseOfEightCoins()
        {
            int total = this.minimumCoin.CoinSet[0] + this.minimumCoin.CoinSet[1] + this.minimumCoin.CoinSet[2] + this.minimumCoin.CoinSet[3] + this.minimumCoin.CoinSet[0] + this.minimumCoin.CoinSet[1] + this.minimumCoin.CoinSet[2] + this.minimumCoin.CoinSet[3];
            if (this.minimumCoin.CoinSet.Count > 1 && !this.minimumCoin.CoinSet.Contains(total))
            {;
                int actual = this.minimumCoin.getCount(total);
                Assert.True(6 >= actual);
            }
        }
    }
}
