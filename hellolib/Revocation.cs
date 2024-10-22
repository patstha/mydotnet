using System.IO;

namespace hellolib;

public static class Revocation
{
    public static List<string> ReadCsv(string filename)
    {
        using StreamReader reader = new(filename);
        List<string> result = new();
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            result.Add(values[0]);
        }
        return result;
    }

    public static void GetBatches(string filename, int size)
    {
        List<string> source = ReadCsv(filename);
        IEnumerable<IEnumerable<string>> batches = source.Batch(size);
        foreach (IEnumerable<string> bat in batches)
        {
            int x = bat.ToList().Count;
        }
    }

    public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(
                  this IEnumerable<TSource> source, int size)
    {
        TSource[] bucket = null;
        int count = 0;

        foreach (TSource item in source)
        {
            bucket ??= new TSource[size];
            bucket[count++] = item;

            if (count == size)
            {
                yield return bucket;
                bucket = null;
                count = 0;
            }
        }

        if (bucket != null && count > 0)
        {
            yield return bucket.Take(count).ToArray();
        }
    }
}
