using System.Collections.Generic;

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
        Revocation.GetBatches(filename, 10);

        Assert.True(true);
    }
}
