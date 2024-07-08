namespace hellolib;

public class ListNode(int val = 0, ListNode next = null)
{
    public int val = val;
    public ListNode next = next;
}

public class Solution
{
    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        int first = GetIntegerFromList(l1);
        int second = GetIntegerFromList(l2);
        int sum = first + second;
        ListNode result = GetListFromInteger(sum);
        return result;
    }

    public static int GetIntegerFromList(ListNode l1)
    {
        int result = 0;
        int counter = 0;
        while (l1.next != null)
        {
            int val = l1.val * (int)Math.Pow(10, counter);
            result += val;
            l1 = l1.next;
            counter++;
        }
        result += l1.val * (int)Math.Pow(10, counter);
        return result;
    }

    public static ListNode GetListFromInteger(int input)
    {
        if (input / 10 == 0)
        {
            return new ListNode()
            {
                val = input,
                next = null
            };
        }
        int currentVal = input % 10;
        ListNode current = new()
        {
            val = currentVal
        };
        // how do I tell if next exists? 
        if (input / 10 > 0)
        {
            current.next = new()
            {
                val = input / 10
            };
            input /= 10;
        }

        while (input / 10 > 0)
        {
            ListNode current2 = new()
            {
                val = currentVal
            };
            input /= 10;
            if (input == 0)
            {
                current2.next = null;
            }
            else
            {
                current2.next = new()
                {
                    val = input % 10
                };
            }
        }

        return current;
    }
}