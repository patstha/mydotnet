namespace hellolib;

public class MinimumCoin(List<int> coinSet, int repeatFactor)
{
    public List<int> CoinSet { get; private set; } = coinSet;
    public int RepeatFactor { get; private set; } = repeatFactor;

    private static IEnumerable<IEnumerable<T>> SubSetsOf<T>(IEnumerable<T> source)
    {
        if (!source.Any())
        {
            return Enumerable.Repeat(Enumerable.Empty<T>(), 1);
        }

        IEnumerable<T> element = source.Take(1);

        IEnumerable<IEnumerable<T>> haveNots = SubSetsOf(source.Skip(1));
        IEnumerable<IEnumerable<T>> haves = haveNots.Select(set => element.Concat(set));

        return haves.Concat(haveNots);
    }

    private static int GetCountInternal(int total, List<int> repeatedList)
    {
        int currentCount = int.MaxValue;
        IEnumerable<IEnumerable<int>> x = SubSetsOf<int>(repeatedList);
        foreach (IEnumerable<int> y in x)
        {
            int sum = y.Sum();
            if (sum == total && currentCount > y.Count())
            {
                currentCount = y.Count();
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
        else if (CoinSet.Min() > total)
        {
            return 0;
        }
        else
        {
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
}
