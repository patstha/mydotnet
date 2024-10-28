namespace hellolib;

public class MinimumCoin(List<int> coinSet, int repeatFactor)
{
    public List<int> CoinSet { get; private set; } = coinSet;
    public int RepeatFactor { get; private set; } = repeatFactor;

    private static IEnumerable<IEnumerable<T>> SubSetsOf<T>(IEnumerable<T> source)
    {
        List<T> sourceList = source.ToList(); // Materialize the source into a list

        if (!sourceList.Any())
        {
            return Enumerable.Repeat(Enumerable.Empty<T>(), 1);
        }

        IEnumerable<T> element = sourceList.Take(1);

        IEnumerable<IEnumerable<T>> haveNots = SubSetsOf(sourceList.Skip(1));
        IEnumerable<IEnumerable<T>> enumerable = haveNots.ToList();
        IEnumerable<IEnumerable<T>> haves = enumerable.Select(set => element.Concat(set));

        return haves.Concat(enumerable);
    }


    private static int GetCountInternal(int total, List<int> repeatedList)
    {
        int currentCount = int.MaxValue;
        IEnumerable<IEnumerable<int>> x = SubSetsOf(repeatedList);
        foreach (IEnumerable<int> y in x)
        {
            IEnumerable<int> enumerable = y.ToList();
            int sum = enumerable.Sum();
            if (sum == total && currentCount > enumerable.Count())
            {
                currentCount = enumerable.Count();
            }
        }
        return currentCount;
    }

    public int GetCount(int total)
    {
        if (CoinSet.Contains(total))
        {
            return 1;
        }

        if (CoinSet.Min() > total)
        {
            return 0;
        }

        List<int> repeatedList = [];
        for (int i = 0; i < RepeatFactor; i++)
        {
            foreach (int x in CoinSet)
            {
                repeatedList.Add(x);
            }
        }
        return GetCountInternal(total, repeatedList);
    }
}
