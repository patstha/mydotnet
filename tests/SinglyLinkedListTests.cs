﻿using System.Collections.Generic;

namespace tests;

public class SinglyLinkedListTests
{
    [Fact]
    public void InsertHeadInsertTailRemove_ShouldReturnOneValue()
    {
        List<int> expected = new List<int> { 0, 2 };

        SinglyLinkedList linkedList = new SinglyLinkedList();
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
        SinglyLinkedList linkedList = new SinglyLinkedList();
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
