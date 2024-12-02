namespace tests;

public class MySearchTests
{
    [Fact]
    public void LinearSearchTestDoesNotExist()
    {
        // Arrange
        int[] arrayToSearch = [1, 2, 3, 4, 5, 6];
        const int queryItem = 9;

        // Act
        bool result = MySearch.LinearSearchIntegers(arrayToSearch, queryItem);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void LinearSearchTestDoesExist()
    {
        // Arrange
        int[] arrayToSearch = [1, 2, 3, 4, 5, 6];
        const int queryItem = 4;

        // Act
        bool result = MySearch.LinearSearchIntegers(arrayToSearch, queryItem);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void BinarySearchDoesNotExist()
    {
        // Arrange
        int[] arrayToSearch = [1, 2, 3, 4, 5, 6];
        const int queryItem = 9;

        // Act
        int result = MySearch.BinarySearchIntegers(arrayToSearch, queryItem);

        // Assert
        result.Should().Be(-1);
    }

    [Fact]
    public void BinarySearchDoesExist()
    {
        // Arrange
        int[] arrayToSearch = [1, 2, 3, 4, 5, 6];
        const int queryItem = 1;

        // Act
        int result = MySearch.BinarySearchIntegers(arrayToSearch, queryItem);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void BinarySearchDoesExistOdd()
    {
        // Arrange
        int[] arrayToSearch = [1, 2, 3, 4, 5, 6, 7];
        const int queryItem = 1;

        // Act
        int result = MySearch.BinarySearchIntegers(arrayToSearch, queryItem);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void BinarySearchDoesExist2()
    {
        // Arrange
        int[] arrayToSearch = [1, 2, 3, 4, 5, 6];
        const int queryItem = 2;

        // Act
        int result = MySearch.BinarySearchIntegers(arrayToSearch, queryItem);

        // Assert
        result.Should().Be(1);
    }

    [Fact]
    public void BinarySearchDoesExistOdd2()
    {
        // Arrange
        int[] arrayToSearch = [1, 2, 3, 4, 5, 6, 7];
        const int queryItem = 2;

        // Act
        int result = MySearch.BinarySearchIntegers(arrayToSearch, queryItem);

        // Assert
        result.Should().Be(1);
    }

    [Fact]
    public void BinarySearchDoesExist3()
    {
        // Arrange
        int[] arrayToSearch = [1, 2, 3, 4, 5, 6];
        const int queryItem = 3;

        // Act
        int result = MySearch.BinarySearchIntegers(arrayToSearch, queryItem);

        // Assert
        result.Should().Be(2);
    }

    [Fact]
    public void BinarySearchDoesExistOdd3()
    {
        // Arrange
        int[] arrayToSearch = [1, 2, 3, 4, 5, 6, 7];
        const int queryItem = 3;

        // Act
        int result = MySearch.BinarySearchIntegers(arrayToSearch, queryItem);

        // Assert
        result.Should().Be(2);
    }

    [Fact]
    public void BinarySearchDoesExist4()
    {
        // Arrange
        int[] arrayToSearch = [1, 2, 3, 4, 5, 6];
        const int queryItem = 4;

        // Act
        int result = MySearch.BinarySearchIntegers(arrayToSearch, queryItem);

        // Assert
        result.Should().Be(3);
    }

    [Fact]
    public void BinarySearchDoesExistOdd4()
    {
        // Arrange
        int[] arrayToSearch = [1, 2, 3, 4, 5, 6, 7];
        const int queryItem = 4;

        // Act
        int result = MySearch.BinarySearchIntegers(arrayToSearch, queryItem);

        // Assert
        result.Should().Be(3);
    }

    [Fact]
    public void BinarySearchDoesExist4Twice()
    {
        // Arrange
        int[] arrayToSearch = [1, 2, 3, 4, 4, 5, 6];
        const int queryItem = 4;

        // Act
        int result = MySearch.BinarySearchIntegers(arrayToSearch, queryItem);

        // Assert
        result.Should().Be(3);
    }

    [Fact]
    public void BinarySearchDoesExistOdd4Twice()
    {
        // Arrange
        int[] arrayToSearch = [1, 2, 3, 4, 4, 5, 6, 7];
        const int queryItem = 4;

        // Act
        int result = MySearch.BinarySearchIntegers(arrayToSearch, queryItem);

        // Assert
        result.Should().Be(3);
    }

    [Fact]
    public void BinarySearchExistsKhan()
    {
        // Arrange
        int[] primes = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97];
        const int queryItem = 73;

        // Act
        int result = MySearch.BinarySearchIntegers(primes, queryItem);

        // Assert
        result.Should().Be(20);
    }
}
