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
        [Fact]
        public void SumExistsInCheckExists()
        {
            int[] a = { 1, 5, 3, 7, 12, 8 };
            int X = 20;
            Assert.True(TwoSum.CheckExists(a, X));
        }
        [Fact]
        public void SumDoesNotExistInCheckExists()
        {
            int[] a = { 1, 5, 3, 7, 12, 9 };
            int X = 20;
            Assert.False(TwoSum.CheckExists(a, X));
        }
        [Fact]
        public void SumExistsInCheckExistsHashed()
        {
            int[] a = { 1, 5, 3, 7, 12, 8 };
            int X = 20;
            Assert.True(TwoSum.CheckExistsHashed(a, X));
        }
        [Fact]
        public void SumDoesNotExistInCheckExistsHashed()
        {
            int[] a = { 1, 5, 3, 7, 12, 9 };
            int X = 20;
            Assert.False(TwoSum.CheckExistsHashed(a, X));
        }
    }
}