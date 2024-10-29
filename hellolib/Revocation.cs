using System.IO;

namespace hellolib;

public static class Revocation
{
    public static List<string> ReadCsv(string filename)
    {
        using StreamReader reader = new(filename);
        List<string> result = [];
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }
            string[] values = line.Split(',');
            if (values.Length > 0)
            {
                result.Add(values[0]);
            }
        }
        return result;
    }


    public static void GetBatches(string filename, int size)
    {
        List<string> source = ReadCsv(filename);
        IEnumerable<IEnumerable<string>> batches = source.Batch(size);
        foreach (IEnumerable<string> bat in batches)
        {
            Console.WriteLine($"Batch size: {bat.Count()}");
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

        if (bucket != null)
        {
            yield return bucket.Take(count).ToArray();
        }
    }
}
