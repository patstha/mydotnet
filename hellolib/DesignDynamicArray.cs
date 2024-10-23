namespace hellolib;
public class DesignDynamicArray
{
    int?[] values;
    int size;

    public DesignDynamicArray(int capacity)
    {
        values = new int?[capacity];
        size = 0;
    }

    public int Get(int i)
    {
        return values[i] ?? 0;
    }

    public void Set(int i, int n)
    {
        values[i] = n;
    }

    public void PushBack(int n)
    {
        if (size == values.Length)
        {
            Resize();
        }
        values[size] = n;
        size++;
    }

    public int PopBack()
    {
        if (size == 0) throw new InvalidOperationException("Array is empty.");
        int? returnValue = values[size - 1];
        values[size - 1] = null;
        size--;
        return returnValue ?? 0;
    }

    private void Resize()
    {
        int capacity = values.Length * 2;
        int?[] newValues = new int?[capacity];
        for (int i = 0; i < values.Length; i++)
        {
            newValues[i] = values[i];
        }
        values = newValues;
    }

    public int GetSize()
    {
        return size;
    }

    public int GetCapacity()
    {
        return values.Length;
    }
}