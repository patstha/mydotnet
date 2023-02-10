using Xunit;
using SalesforceMapper;
using FluentAssertions;

namespace tests
{
    public class MapperTests
    {
        [Fact]
        public void Freebie()
        {
            Assert.True(true);
        }


        [Fact]
        public void AddTwoIntegers_ShouldReturnFiveWhenAddingTwoAndThree()
        {
            // arrange 
            int first = 2;
            int second = 3;
            int expected = 5;

            // act 
            int actual = Mapper.AddTwoIntegers(first, second);

            // assert
            actual.Should().Be(expected);
        }
    }
}
