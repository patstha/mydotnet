namespace hellolib
{
    public class ListNode(int val = 0, ListNode next = null)
    {
        public int Val
        {
            get => val;
            set => val = value;
        }
        public ListNode Next
        {
            get => next;
            set => next = value;
        }
    }

    public class SinglyLinkedListAddTwoNumbers(ILogger<SinglyLinkedListAddTwoNumbers> logger)
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            logger.LogInformation("Starting AddTwoNumbers with list nodes {l1} and {l2}", l1?.Val, l2?.Val);
            ListNode dummyHead = new(0);
            ListNode p = l1, q = l2, current = dummyHead;
            int carry = 0;

            while (p != null || q != null)
            {
                int x = (p != null) ? p.Val : 0;
                int y = (q != null) ? q.Val : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                current.Next = new ListNode(sum % 10);
                current = current.Next;
                if (p != null) p = p.Next;
                if (q != null) q = q.Next;
            }

            if (carry > 0)
            {
                current.Next = new ListNode(carry);
            }

            return dummyHead.Next;
        }

        public int GetIntegerFromListNode(ListNode l)
        {
            int number = 0;
            int multiplier = 1;

            while (l != null)
            {
                number += l.Val * multiplier;
                multiplier *= 10;
                l = l.Next;
            }
            logger.LogInformation("The result is {number}", number);
            return number;
        }
    }
}
