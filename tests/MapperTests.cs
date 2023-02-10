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

        [Theory]
        [InlineData(
            "{\"Id\": \"Abraham Lincoln\", \"ContactEmail__c\": \"abe@whitehouse.gov\"}",
            "{\"Preferences\": [ { \"PrefCode\": \"email__c\" } ] } }"
        )]
        public void ManipulateJsonString_ShouldReturnExpectedJsonString(string json, string expected)
        {
            // arrange, act
            string actual = Mapper.ManipulateJsonString(json);

            // assert 
            expected.Should().Be(actual);
        }
    }
}
