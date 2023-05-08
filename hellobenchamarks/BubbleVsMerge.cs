using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Disassemblers;
using hellolib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace hellobenchamarks;

public class BubbleVsMerge
{
    private const int N = 10000;
    private readonly int[] data;
    public BubbleVsMerge()
    {
        data = new int[N];
        Random randNum = new();
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = randNum.Next(0, 100000);
        }
    }

    [Benchmark]
    public void Bubble() => BubbleSort.SortIntegers(data);

    [Benchmark]
    public void Merge() => MergeSort.SortIntegers(data);
}
