namespace tests;

public class AddTwoNumbersTests
{
    private readonly ILogger<SinglyLinkedListAddTwoNumbers> _logger = Substitute.For<ILogger<SinglyLinkedListAddTwoNumbers>>();

    [Fact]
    public void AddTwoNumbers_Freebie()
    {
        SinglyLinkedListAddTwoNumbers solution = new(_logger);
        solution.Should().NotBeNull();
    }

    [Fact]
    public void AddTwoNumbers_ShouldReturnSumWhenBothInputsAreSingleDigitAndZero()
    {
        // Arrange
        ListNode first = new()
        {
            Val = 0,
            Next = null
        };
        ListNode second = new()
        {
            Val = 0,
            Next = null
        };
        SinglyLinkedListAddTwoNumbers solution = new (_logger);

        // Act
        ListNode actual = solution.AddTwoNumbers(first, second);

        // Assert
        actual.Val.Should().Be(0);
        actual.Next.Should().BeNull();
    }

    [Fact]
    public void AddTwoNumbers_ShouldReturnSumWhenBothInputsAreSingleDigitAndOne()
    {
        // Arrange
        ListNode first = new()
        {
            Val = 1,
            Next = null
        };
        ListNode second = new()
        {
            Val = 1,
            Next = null
        };
        SinglyLinkedListAddTwoNumbers solution = new(_logger);

        // Act
        ListNode actual = solution.AddTwoNumbers(first, second);

        // Assert
        actual.Val.Should().Be(2);
        actual.Next.Should().BeNull();
    }

    [Theory]
    [InlineData(1, 2, 3, 4, 4, 6)]
    [InlineData(5, 6, 4, 3, 9, 9)]
    [InlineData(5, 4, 4, 3, 9, 7)]
    [InlineData(1, 1, 1, 1, 2, 2)]
    [InlineData(0, 2, 1, 1, 1, 3)]
    [InlineData(1, 2, 0, 1, 1, 3)]
    public void AddTwoNumbers_ShouldReturnSumWhenBothInputsAreTwoDigits(int first1, int first2, int second1, int second2, int result1, int result2)
    {
        // Arrange
        ListNode firstA = new()
        {
            Val = first1,
            Next = null
        };
        ListNode firstB = new()
        {
            Val = first2,
            Next = firstA
        };
        ListNode secondA = new()
        {
            Val = second1,
            Next = null
        };
        ListNode secondB = new()
        {
            Val = second2,
            Next = secondA
        };
        SinglyLinkedListAddTwoNumbers solution = new(_logger);

        // Act
        ListNode actual = solution.AddTwoNumbers(firstB, secondB);

        // Assert
        actual.Val.Should().Be(result2);
        actual.Next.Val.Should().Be(result1);
    }

    [Fact]
    public void GetIntegerFromListNode_ShouldReturnCorrectInteger()
    {
        // Arrange
        ListNode node1 = new() { Val = 1, Next = null };
        ListNode node2 = new() { Val = 2, Next = node1 };
        ListNode node3 = new() { Val = 3, Next = node2 };
        SinglyLinkedListAddTwoNumbers solution = new(_logger);

        // Act
        int result = solution.GetIntegerFromListNode(node3);

        // Assert
        result.Should().Be(123);
    }

    [Fact]
    public void GetIntegerFromListNode_ShouldReturnZeroForEmptyList()
    {
        // Arrange
        SinglyLinkedListAddTwoNumbers solution = new(_logger);

        // Act
        int result = solution.GetIntegerFromListNode(null);

        // Assert
        result.Should().Be(0);
    }
    [Fact]
    public void AddTwoNumbers_ShouldHandleCarryOver()
    {
        // Arrange
        ListNode first = new()
        {
            Val = 5,
            Next = new ListNode(6)
        };
        ListNode second = new()
        {
            Val = 5,
            Next = new ListNode(4)
        };
        SinglyLinkedListAddTwoNumbers solution = new(_logger);

        // Act
        ListNode actual = solution.AddTwoNumbers(first, second);

        // Assert
        actual.Val.Should().Be(0); // 5 + 5 = 10, so 0 is the first digit
        actual.Next.Val.Should().Be(1); // 6 + 4 + 1 (carry) = 11, so 1 is the next digit
        actual.Next.Next.Val.Should().Be(1); // carry over 1 should be added as a new node
        actual.Next.Next.Next.Should().BeNull(); // no more nodes
    }

}
