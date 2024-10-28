namespace hellolib;
public class DesignDynamicArray(int capacity)
{
    int?[] _values = new int?[capacity];
    int _size;

    public int Get(int i)
    {
        return _values[i] ?? 0;
    }

    public void Set(int i, int n)
    {
        _values[i] = n;
    }

    public void PushBack(int n)
    {
        if (_size == _values.Length)
        {
            Resize();
        }
        _values[_size] = n;
        _size++;
    }

    public int PopBack()
    {
        if (_size == 0) throw new InvalidOperationException("Array is empty.");
        int? returnValue = _values[_size - 1];
        _values[_size - 1] = null;
        _size--;
        return returnValue ?? 0;
    }

    private void Resize()
    {
        int capacity = _values.Length * 2;
        int?[] newValues = new int?[capacity];
        for (int i = 0; i < _values.Length; i++)
        {
            newValues[i] = _values[i];
        }
        _values = newValues;
    }

    public int GetSize()
    {
        return _size;
    }

    public int GetCapacity()
    {
        return _values.Length;
    }
}