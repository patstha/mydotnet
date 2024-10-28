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
        const string filename = "authorizations.csv";

        // act
        List<string> authorizationIds = Revocation.ReadCsv(filename);

        // assert
        authorizationIds.Count.Should().Be(187749);
    }

    [Fact]
    public void ReadCsv_ShouldHandleEmptyFile()
    {
        // arrange
        const string filename = "empty.csv";
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
    [Fact]
    public void ReadCsv_ShouldHandleLinesWithCommas()
    {
        // Arrange
        string filename = "test_with_commas.csv";
        File.WriteAllText(filename, "value1,value2,value3\nvalue4,value5,value6");

        // Act
        List<string> result = Revocation.ReadCsv(filename);

        // Assert
        result.Should().Contain(["value1", "value4"]);
    }
    [Fact]
    public void ReadCsv_ShouldHandleLinesWithoutCommas()
    {
        // Arrange
        string filename = "test_without_commas.csv";
        File.WriteAllText(filename, "value1\nvalue2");

        // Act
        List<string> result = Revocation.ReadCsv(filename);

        // Assert
        result.Should().Contain(["value1", "value2"]);
    }
    [Fact]
    public void ReadCsv_ShouldHandleNullLines()
    {
        // Arrange
        string filename = "test_with_null_line.csv";
        File.WriteAllText(filename, "value1\n\nvalue2");

        // Act
        List<string> result = Revocation.ReadCsv(filename);

        // Assert
        result.Should().Contain(["value1", "value2"]);
    }
}
