namespace hellolib
{
    public class MinimumCoin
    {
        public List<int> CoinSet { get; private set; }
        public int RepeatFactor { get; private set; }

        public MinimumCoin(List<int> CoinSet, int RepeatFactor)
        {
            this.CoinSet = CoinSet;
            this.RepeatFactor = RepeatFactor;
        }

        private static IEnumerable<IEnumerable<T>> SubSetsOf<T>(IEnumerable<T> source)
        {
            if (!source.Any())
                return Enumerable.Repeat(Enumerable.Empty<T>(), 1);

            var element = source.Take(1);

            var haveNots = SubSetsOf(source.Skip(1));
            var haves = haveNots.Select(set => element.Concat(set));

            return haves.Concat(haveNots);
        }

        private int getCountInternal(int total, List<int> repeatedList)
        {
            int currentCount = int.MaxValue;
            var x = SubSetsOf<int>(repeatedList);
            foreach (var y in x)
            {
                int sum = y.Sum();
                if (sum == total && currentCount > y.Count())
                {
                    currentCount = y.Count();
                }
            }
            return currentCount;
        }

        public int getCount(int total)
        {
            if (this.CoinSet.Contains(total))
            {
                return 1;
            }
            else if (this.CoinSet.Min() > total)
            {
                return 0;
            }
            else
            {
                List<int> repeatedList = new List<int>();
                for (int i = 0; i < this.RepeatFactor; i++)
                {
                    foreach (int x in this.CoinSet)
                    {
                        repeatedList.Add(x);
                    }
                }
                return this.getCountInternal(total, repeatedList);
            }
        }
    }
}
