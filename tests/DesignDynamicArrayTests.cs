namespace tests;

public class DesignDynamicArrayTests
{
    [Fact]
    public void GetSizeGetCapacity_ShouldReturn()
    {
        DesignDynamicArray dynamicArray = new(1);
        int size = dynamicArray.GetSize();
        size.Should().Be(0);
        int capacity = dynamicArray.GetCapacity();
        capacity.Should().Be(1);
    }

    [Fact]
    public void PushbackGetCapacityPushBackGetCapacity_ShouldReturn()
    {
        DesignDynamicArray dynamicArray = new(1);
        dynamicArray.PushBack(1);
        int capacity = dynamicArray.GetCapacity();
        capacity.Should().Be(1);
        dynamicArray.PushBack(2);
        capacity = dynamicArray.GetCapacity();
        capacity.Should().Be(2);
    }

    [Fact]
    public void PushbackPopback_ShouldReturn()
    {
        DesignDynamicArray dynamicArray = new(1);
        int size = dynamicArray.GetSize();
        size.Should().Be(0);
        int capacity = dynamicArray.GetCapacity();
        capacity.Should().Be(1);
        dynamicArray.PushBack(1);
        size = dynamicArray.GetSize();
        size.Should().Be(1);
        capacity = dynamicArray.GetCapacity();
        capacity.Should().Be(1);
        dynamicArray.PushBack(2);
        size = dynamicArray.GetSize();
        size.Should().Be(2);
        capacity = dynamicArray.GetCapacity();
        capacity.Should().Be(2);
        int get = dynamicArray.Get(1);
        get.Should().Be(2);
        dynamicArray.Set(1, 3);
        int pop = dynamicArray.PopBack();
        pop.Should().Be(3);
        size = dynamicArray.GetSize();
        size.Should().Be(1);
        capacity = dynamicArray.GetCapacity();
        capacity.Should().Be(2);
    }
    [Fact]
    public void PopBack_ShouldThrowException_WhenArrayIsEmpty()
    {
        // Arrange
        DesignDynamicArray dynamicArray = new(1);

        // Act
        Action act = () => dynamicArray.PopBack();

        // Assert
        act.Should().Throw<InvalidOperationException>().WithMessage("Array is empty.");
    }

}



//Design Dynamic Array(Resizable Array)

//Design a Dynamic Array(aka a resizable array) class, such as an ArrayList in Java or a vector in C++.

//Your DynamicArray class should support the following operations:

//    DynamicArray(int capacity) will initialize an empty array with a capacity of capacity, where capacity > 0.
//    int get(int i) will return the element at index i.Assume that index i is valid.
//    void set(int i, int n) will set the element at index i to n.Assume that index i is valid.
//    void pushback(int n) will push the element n to the end of the array.
//    int popback() will pop and return the element at the end of the array.Assume that the array is non-empty.
//    void resize() will double the capacity of the array.
//    int getSize() will return the number of elements in the array.
//    int getCapacity() will return the capacity of the array.

//If we call void pushback(int n) but the array is full, we should resize the array first.

//Example 1:

//Input:
//["Array", 1, "getSize", "getCapacity"]

//Output:
//[null, 0, 1]

//Example 2:

//Input:
//["Array", 1, "pushback", 1, "getCapacity", "pushback", 2, "getCapacity"]

//Output:
//[null, null, 1, null, 2]

//Example 3:

//Input:
//["Array", 1, "getSize", "getCapacity", "pushback", 1, "getSize", "getCapacity", "pushback", 2, "getSize", "getCapacity", "get", 1, "set", 1, 3, "get", 1, "popback", "getSize", "getCapacity"]

//Output:
//[null, 0, 1, null, 1, 1, null, 2, 2, 2, null, 3, 3, 1, 2]

//Note:

//    The index i provided to get(int i) and set(int i) is guaranteed to be greater than or equal to 0 and less than the number of elements in the array.

