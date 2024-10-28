namespace hellolib;

public class SinglyLinkedListNode
{
    public int? Value { get; set; }
    public SinglyLinkedListNode Next { get; set; }
}

public class SinglyLinkedList
{
    private SinglyLinkedListNode _head;

    public SinglyLinkedList()
    {
        _head = null;
    }

    public int Get(int index)
    {
        SinglyLinkedListNode current = _head;
        for (int i = 0; i < index; i++)
        {
            if (current == null) return -1;
            current = current.Next;
        }
        return current?.Value ?? -1;
    }

    public void InsertHead(int val)
    {
        SinglyLinkedListNode newNode = new()
        {
            Value = val,
            Next = _head
        };
        _head = newNode;
    }

    public void InsertTail(int val)
    {
        SinglyLinkedListNode newNode = new()
        {
            Value = val,
            Next = null
        };

        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            SinglyLinkedListNode current = _head;
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
            if (_head == null) return false;
            _head = _head.Next;
            return true;
        }

        SinglyLinkedListNode current = _head;
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
        List<int> results = [];
        SinglyLinkedListNode current = _head;
        while (current != null)
        {
            results.Add(current.Value ?? 0);
            current = current.Next;
        }
        return results;
    }
}