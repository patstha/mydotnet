using System.Collections.Generic;

namespace tests;

public class SinglyLinkedListTests
{
    public class Node
    {
        public int? Value { get; set; }
        public Node Next { get; set; }
    }

    public class LinkedList
    {
        private Node head;

        public LinkedList()
        {
            head = null;
        }

        public int Get(int index)
        {
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                if (current == null) return -1;
                current = current.Next;
            }
            return current?.Value ?? -1;
        }

        public void InsertHead(int val)
        {
            Node newNode = new Node
            {
                Value = val,
                Next = head
            };
            head = newNode;
        }

        public void InsertTail(int val)
        {
            Node newNode = new Node
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
                Node current = head;
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

            Node current = head;
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
            Node current = head;
            while (current != null)
            {
                results.Add(current.Value ?? 0);
                current = current.Next;
            }
            return results;
        }
    }

    [Fact]
    public void InsertHeadInsertTailRemove_ShouldReturnOneValue()
    {
        List<int> expected = new List<int> { 0, 2 };

        LinkedList linkedList = new LinkedList();
        linkedList.InsertHead(1);
        linkedList.InsertTail(2);
        linkedList.InsertHead(0);
        bool removed = linkedList.Remove(1);
        removed.Should().BeTrue();
        List<int> actual = linkedList.GetValues();
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void InsertHeadInsertHeadGet_ShouldReturn()
    {
        LinkedList linkedList = new LinkedList();
        linkedList.InsertHead(1);
        linkedList.InsertHead(2);
        int actual = linkedList.Get(5);

        actual.Should().Be(-1);
    }
}


//Design Singly Linked List

//Design a Singly Linked List class.

//Your LinkedList class should support the following operations:

//    LinkedList() will initialize an empty linked list.
//    int get(int i) will return the value of the ith node (0-indexed). If the index is out of bounds, return -1.
//    void insertHead(int val) will insert a node with val at the head of the list.
//    void insertTail(int val) will insert a node with val at the tail of the list.
//    bool remove(int i) will remove the ith node (0-indexed). If the index is out of bounds, return false, otherwise return true.
//    int[] getValues() return an array of all the values in the linked list, ordered from head to tail.

//Example 1:

//Input: 
//["insertHead", 1, "insertTail", 2, "insertHead", 0, "remove", 1, "getValues"]

//Output:
//[null, null, null, true, [0, 2]]

//Example 2:

//Input:
//["insertHead", 1, "insertHead", 2, "get", 5]

//Output:
//[null, null, -1]

//Note:

//    The index int i provided to get(int i) and remove(int i) is guaranteed to be greater than or equal to 0.

//public class LinkedList
//{

//    public LinkedList()
//    {

//    }

//    public int Get(int index)
//    {

//    }

//    public void InsertHead(int val)
//    {

//    }

//    public void InsertTail(int val)
//    {

//    }

//    public bool Remove(int index)
//    {

//    }

//    public List<int> GetValues()
//    {

//    }
//}

