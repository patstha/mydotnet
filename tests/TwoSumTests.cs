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
            int[] a = { 1, 5, 3, 7, 12, 8};
            int X = 20;
            Assert.True(TwoSum.CheckExists(a, X));
        }
    }
}