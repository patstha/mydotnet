using hellolib;

namespace tests;

public class AddTwoNumbersTests
{
    [Fact]
    public void AddTwoNumbers_Freebie()
    {
        Solution solution = new();
        solution.Should().NotBeNull();
    }

    [Fact]
    public void AddTwoNumbers_ShouldReturnSumWhenBothInputsAreSingleDigitAndZero()
    {
        // Arrange
        ListNode first = new()
        {
            val = 0,
            next = null
        };
        ListNode second = new()
        {
            val = 0,
            next = null
        };
        Solution solution = new ();

        // Act
        ListNode actual = Solution.AddTwoNumbers(first, second);

        // Assert
        actual.val.Should().Be(0);
        actual.next.Should().BeNull();
    }

    [Fact]
    public void AddTwoNumbers_ShouldReturnSumWhenBothInputsAreSingleDigitAndOne()
    {
        // Arrange
        ListNode first = new()
        {
            val = 1,
            next = null
        };
        ListNode second = new()
        {
            val = 1,
            next = null
        };
        Solution solution = new();

        // Act
        ListNode actual = Solution.AddTwoNumbers(first, second);

        // Assert
        actual.val.Should().Be(2);
        actual.next.Should().BeNull();
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
            val = first1,
            next = null
        };
        ListNode firstB = new()
        {
            val = first2,
            next = firstA
        };
        ListNode secondA = new()
        {
            val = second1,
            next = null
        };
        ListNode secondB = new()
        {
            val = second2,
            next = secondA
        };
        Solution solution = new();

        // Act
        ListNode actual = Solution.AddTwoNumbers(firstB, secondB);

        // Assert
        actual.val.Should().Be(result2);
        actual.next.val.Should().Be(result1);
    }
}



/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
//public class Solution
//{
//    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
//    {
//        int first = GetIntegerFromList(l1);
//        int second = GetIntegerFromList(l2);
//        int sum = first + second;
//        ListNode result = GetListFromInteger(sum);
//        return result;
//    }

//    public int GetIntegerFromList(ListNode l1)
//    {
//        if (l1.next == null) { return l1.val; }
//        int result = 0;
//        int counter = 0;
//        while (l1.next != null)
//        {
//            int val = l1.val * (int)System.Math.Pow(10, counter);
//            result += val;
//            l1 = l1.next;
//            counter++;
//        }
//        result += l1.val * (int)System.Math.Pow(10, counter);
//        return result;
//    }

//    public ListNode GetListFromInteger(int input)
//    {
//        System.Console.WriteLine(input);
//        if (input / 10 == 0)
//        {
//            return new ListNode()
//            {
//                val = input,
//                next = null
//            };
//        }
//        int currentVal = input % 10;
//        List<ListNode> nodes = new();
//        ListNode current = new ListNode()
//        {
//            val = currentVal
//        };
//        // how do I tell if next exists? 
//        if (input / 10 > 0)
//        {
//            current.next = new()
//            {
//                val = input % 10
//            };
//            input = input / 10;
//        }

//        while (input / 10 > 0)
//        {
//            ListNode current2 = new()
//            {
//                val = currentVal
//            };
//            input = input / 10;
//            if (input == 0)
//            {
//                current2.next = null;
//            }
//            else
//            {
//                current2.next = new()
//                {
//                    val = input % 10
//                };
//            }
//        }

//        return current;
//    }
//}