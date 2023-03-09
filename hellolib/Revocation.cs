using MoreLinq;
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
        reader.Close();
        return result;
    }

    public static void GetBatches(string filename, int size)
    {
        List<string> source = ReadCsv(filename);
        IEnumerable<IEnumerable<string>> batches = source.Batch(size);
        foreach (IEnumerable<string> bat in batches)
        {
            int x = bat.ToList().Count;
            Console.WriteLine(x);
        }
    }
}
