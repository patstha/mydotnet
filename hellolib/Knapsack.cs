﻿namespace hellolib;

public static class Knapsack
{
    public static List<KnapsackItem> BruteForce(int knapsackSize, List<KnapsackItem> knapsackItems)
    {
        List<KnapsackItem> bestCombination = [];
        decimal bestCost = 0;
        IEnumerable<IEnumerable<KnapsackItem>> combinations = SubSetsOf(knapsackItems);
        foreach (IEnumerable<KnapsackItem> combination in combinations)
        {
            IEnumerable<KnapsackItem> items = combination.ToList();
            IEnumerable<KnapsackItem> enumerable = items.ToList();
            decimal currentCost = enumerable.Sum(item => item.Cost);
            if (currentCost <= bestCost || items.Sum(x => x.Weight) > knapsackSize) continue;
            bestCost = currentCost;
            bestCombination = enumerable.ToList();
        }
        return bestCombination;
    }

    private static IEnumerable<IEnumerable<T>> SubSetsOf<T>(IEnumerable<T> source)
    {
        IEnumerable<T> enumerable = source.ToList();
        if (!enumerable.Any())
            return Enumerable.Repeat(Enumerable.Empty<T>(), 1);

        IEnumerable<T> element = enumerable.Take(1);

        IEnumerable<IEnumerable<T>> haveNots = SubSetsOf(enumerable.Skip(1));
        IEnumerable<IEnumerable<T>> second = haveNots.ToList();
        IEnumerable<IEnumerable<T>> haves = second.Select(set => element.Concat(set));

        return haves.Concat(second);
    }
}
public record KnapsackItem(string Name, decimal Cost, int Weight);


// you are a thief with a knapsack that can carry m pounds of goods
// for example, 4 lb 
// you have n items that you can put in a knapsack. 
// for example, 
// stereo   USD 3_000       4lbs
// laptop   USD 2_000       3lbs
// guitar   USD 1_500       1lb