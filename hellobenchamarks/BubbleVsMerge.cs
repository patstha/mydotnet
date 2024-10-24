using BenchmarkDotNet.Attributes;
using hellolib;

namespace hellobenchamarks;

public class BubbleVsMerge
{
    private const int N = 10000;
    private readonly int[] _data;
    public BubbleVsMerge()
    {
        _data = new int[N];
        Random randNum = new();
        for (int i = 0; i < _data.Length; i++)
        {
            _data[i] = randNum.Next(0, 100000);
        }
    }

    [Benchmark]
    public void Bubble() => BubbleSort.SortIntegers(_data);

    [Benchmark]
    public void Merge() => MergeSort.SortIntegers(_data);
}
