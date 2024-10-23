using System.Collections.Generic;

namespace tests;

public class SinglyLinkedListTests
{
    public class Node
    {
        public int? Value { get; set; } = null;
        public Node Next { get; set; } = null;
    }
    public class LinkedList
    {
        private Node node;
        public LinkedList()
        {
            node = new();
        }

        public int Get(int index)
        {
            Node placeholder = node;
            for (int i = 0; i < index; i++)
            {
                placeholder = placeholder.Next;
            }
            return placeholder.Value ?? 0;
        }

        public void InsertHead(int val)
        {
            Node placeholder = node;
            Node newNode = new()
            {
                Value = val,
                Next = placeholder
            };
            node = newNode;
        }

        public void InsertTail(int val)
        {
            Node placeholder = node;
            while (placeholder != null)
            {
                placeholder = placeholder.Next;
            }
            placeholder = new()
            {
                Value = val,
                Next = null
            };
        }

        public bool Remove(int index)
        {
            Node placeholder = node;
            for (int i = 0; i < index; i++)
            {
                if (placeholder == null)
                {
                    return false;
                }
            }
            placeholder = placeholder.Next;
            return true;
        }

        public List<int> GetValues()
        {
            List<int> results = new();
            Node placeholder = node;
            while (placeholder != null && placeholder.Value != null)
            {
                results.Add(placeholder.Value ?? 0);
                placeholder = placeholder.Next;
            }
            return results;
        }
    }

    [Fact]
    public void InsertHeadInsertTaiilRemove_ShouldReturnOneValue()
    {
        // input ["insertHead", 1, "insertTail", 2, "insertHead", 0, "remove", 1, "getValues"]
        // expected [null,null,null,true,[0, 2]]
        // actual [null,null,null,true,[0, 1]]

        List<int> expected = [0, 2];

        LinkedList linkedList = new();
        linkedList.InsertHead(1);
        linkedList.InsertTail(2);
        bool removed = linkedList.Remove(1);
        removed.Should().BeTrue();
        List<int> actual = linkedList.GetValues();
        actual.Should().BeEquivalentTo(expected);
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

