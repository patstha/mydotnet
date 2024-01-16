using hellolib;
using System.Collections.Generic;
using System.Linq;

namespace tests;

public class RevocationTests
{
    [Fact]
    public void Freebie()
    {
        Assert.True(true);
    }

    [Fact]
    public void ReadCsv_ShouldReturnTokens()
    {
        // arrange
        string filename = "authorizations.csv";

        // act
        List<string> authorizationIds = Revocation.ReadCsv(filename);

        // assert
        _ = authorizationIds.Count.Should().Be(187749);
    }


    [Fact]
    public void GetBatches()
    {
        // arrange
        string filename = "authorizations.csv";

        // act
        List<int> actual = Revocation.GetBatches(filename, 10);

        // assert
        Assert.True(true);
        for (int i = 0; i < actual.Count - 1; i++)
        {
            actual[i].Should().Be(10);
        }
        actual.Skip(actual.Count - 1).Take(1).Single().Should().BeOneOf(10, 187749 % 10);
    }
}
