namespace hellolib;

public class SinglyLinkedListNode
{
    public int? Value { get; set; }
    public SinglyLinkedListNode Next { get; set; }
}

public class SinglyLinkedList
{
    private SinglyLinkedListNode head;

    public SinglyLinkedList()
    {
        head = null;
    }

    public int Get(int index)
    {
        SinglyLinkedListNode current = head;
        for (int i = 0; i < index; i++)
        {
            if (current == null) return -1;
            current = current.Next;
        }
        return current?.Value ?? -1;
    }

    public void InsertHead(int val)
    {
        SinglyLinkedListNode newNode = new SinglyLinkedListNode
        {
            Value = val,
            Next = head
        };
        head = newNode;
    }

    public void InsertTail(int val)
    {
        SinglyLinkedListNode newNode = new SinglyLinkedListNode
        {
            Value = val,
            Next = null
        };

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            SinglyLinkedListNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public bool Remove(int index)
    {
        if (index == 0)
        {
            if (head == null) return false;
            head = head.Next;
            return true;
        }

        SinglyLinkedListNode current = head;
        for (int i = 0; i < index - 1; i++)
        {
            if (current == null || current.Next == null) return false;
            current = current.Next;
        }

        if (current.Next == null) return false;
        current.Next = current.Next.Next;
        return true;
    }

    public List<int> GetValues()
    {
        List<int> results = new List<int>();
        SinglyLinkedListNode current = head;
        while (current != null)
        {
            results.Add(current.Value ?? 0);
            current = current.Next;
        }
        return results;
    }
}