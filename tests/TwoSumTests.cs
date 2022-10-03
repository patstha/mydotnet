using System;
using Xunit;
using hellolib;
namespace tests
{
    public class TwoSumTests
    {
        [Fact]
        public void Freebie()
        {
            Assert.True(true);
        }
        [Theory]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 8 }, 20)]
        public void SumExistsInCheckExists(int[] a, int X)
        {
            Assert.True(TwoSum.CheckExists(a, X));
        }
        [Theory]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 9 }, 20)]
        public void SumDoesNotExistInCheckExists(int[] a, int X)
        {
            Assert.False(TwoSum.CheckExists(a, X));
        }
        [Theory]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 9 }, 20)]
        public void SumDoesNotExistInCheckExistsTen(int[] a, int X)
        {
            Assert.False(TwoSum.CheckExists(a, X));
        }
        [Theory]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 10, 9 }, 20)]
        public void SumExistsInCheckExistsTen(int[] a, int X)
        {
            Assert.True(TwoSum.CheckExists(a, X));
        }
        [Theory]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 8 }, 20)]
        public void SumExistsInCheckExistsHashed(int[] a, int X)
        {
            Assert.True(TwoSum.CheckExistsHashed(a, X));
        }
        [Theory]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 9 }, 20)]
        public void SumDoesNotExistInCheckExistsHashedTen(int[] a, int X)
        {
            Assert.False(TwoSum.CheckExistsHashed(a, X));
        }
        [Theory]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 9 }, 20)]
        public void SumDoesNotExistInCheckExistsHashed(int[] a, int X)
        {
            Assert.False(TwoSum.CheckExistsHashed(a, X));
        }
    }
}