using System.Collections.Generic;
using System.IO;
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
        authorizationIds.Count.Should().Be(187749);
    }

    [Fact]
    public void ReadCsv_ShouldHandleEmptyFile()
    {
        // arrange
        string filename = "empty.csv";
        File.WriteAllText(filename, string.Empty);

        // act
        List<string> authorizationIds = Revocation.ReadCsv(filename);

        // assert
        authorizationIds.Should().BeEmpty();
    }

    [Fact]
    public void Batch_ShouldBatchItemsCorrectly()
    {
        // arrange
        List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        // act
        IEnumerable<IEnumerable<int>> batches = numbers.Batch(3).ToList();

        // assert
        batches.Should().HaveCount(4);
        batches.First().Should().Equal(1, 2, 3);
    }

    [Fact]
    public void GetBatches_ShouldWorkWithDifferentSizes()
    {
        // arrange
        string filename = "authorizations.csv";

        // act
        Revocation.GetBatches(filename, 5);
        Revocation.GetBatches(filename, 20);

        // assert
        Assert.True(true); // Just to ensure no exceptions are thrown
    }
}
