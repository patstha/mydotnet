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
        [InlineData(new int[]{ 1, 5, 3, 7, 02, 8 }, 10)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 8 }, 20)]
        [InlineData(new int[]{ 1, 5, 3, 7, 22, 8 }, 30)]
        [InlineData(new int[]{ 1, 5, 3, 7, 32, 8 }, 40)]
        [InlineData(new int[]{ 1, 5, 3, 7, 42, 8 }, 50)]
        [InlineData(new int[]{ 1, 5, 3, 7, 52, 8 }, 60)]
        [InlineData(new int[]{ 1, 5, 3, 7, 62, 8 }, 70)]
        [InlineData(new int[]{ 1, 5, 3, 7, 72, 8 }, 80)]
        [InlineData(new int[]{ 1, 5, 3, 7, 82, 8 }, 90)]
        [InlineData(new int[]{ 1, 5, 3, 7, 92, 8 }, 100)]
        public void SumExistsInCheckExists(int[] a, int X)
        {
            Assert.True(TwoSum.CheckExists(a, X));
        }
        [Theory]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 9 }, 20)]
        [InlineData(new int[]{ 1, 5, 3, 7, 22, 9 }, 30)]
        [InlineData(new int[]{ 1, 5, 3, 7, 32, 9 }, 40)]
        [InlineData(new int[]{ 1, 5, 3, 7, 42, 9 }, 50)]
        [InlineData(new int[]{ 1, 5, 3, 7, 52, 9 }, 60)]
        [InlineData(new int[]{ 1, 5, 3, 7, 62, 9 }, 70)]
        [InlineData(new int[]{ 1, 5, 3, 7, 72, 9 }, 80)]
        [InlineData(new int[]{ 1, 5, 3, 7, 82, 9 }, 90)]
        public void SumDoesNotExistInCheckExists(int[] a, int X)
        {
            Assert.False(TwoSum.CheckExists(a, X));
        }
        [Theory]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 9 }, 20)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 9 }, 30)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 9 }, 40)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 9 }, 50)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 9 }, 60)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 9 }, 70)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 9 }, 80)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 9 }, 90)]
        public void SumDoesNotExistInCheckExistsTen(int[] a, int X)
        {
            Assert.False(TwoSum.CheckExists(a, X));
        }
        [Theory]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 10, 09 }, 10)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 10, 19 }, 20)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 10, 29 }, 30)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 10, 39 }, 40)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 10, 49 }, 50)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 10, 59 }, 60)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 10, 69 }, 70)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 10, 79 }, 80)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 10, 89 }, 90)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 10, 99 }, 100)]
        public void SumExistsInCheckExistsTen(int[] a, int X)
        {
            Assert.True(TwoSum.CheckExists(a, X));
        }
        [Theory]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 08 }, 20)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 18 }, 30)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 28 }, 40)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 38 }, 50)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 48 }, 60)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 58 }, 70)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 68 }, 80)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 78 }, 90)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 88 }, 100)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 98 }, 110)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 108 }, 120)]
        public void SumExistsInCheckExistsHashed(int[] a, int X)
        {
            Assert.True(TwoSum.CheckExistsHashed(a, X));
        }
        [Theory]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 09 }, 20)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 19 }, 30)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 29 }, 40)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 39 }, 50)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 49 }, 60)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 59 }, 70)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 69 }, 80)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 79 }, 90)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 89 }, 100)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 99 }, 110)]
        [InlineData(new int[]{ 1, 5, 3, 7, 10, 109 }, 120)]
        public void SumDoesNotExistInCheckExistsHashedTen(int[] a, int X)
        {
            Assert.False(TwoSum.CheckExistsHashed(a, X));
        }
        [Theory]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 09 }, 20)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 19 }, 30)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 29 }, 40)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 39 }, 50)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 49 }, 60)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 59 }, 70)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 69 }, 80)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 79 }, 90)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 89 }, 100)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 99 }, 110)]
        [InlineData(new int[]{ 1, 5, 3, 7, 12, 109 }, 120)]
        public void SumDoesNotExistInCheckExistsHashed(int[] a, int X)
        {
            Assert.False(TwoSum.CheckExistsHashed(a, X));
        }
    }
}