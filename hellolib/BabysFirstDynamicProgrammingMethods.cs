namespace hellolib;

public static class BabysFirstDynamicProgrammingMethods
{
    public static int FibonacciWithRecursion(int n)
    {
        if (n <= 1)
            return n;
        return FibonacciWithRecursion(n - 1) + FibonacciWithRecursion(n - 2);
    }
    
    public static int FibonacciWithoutRecursion(int n)
    {
        if (n <= 1)
            return n;

        int[] dp = new int[n + 1];
        dp[0] = 0;
        dp[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        return dp[n];
    }

    public static List<KnapsackItem> KnapsackBruteForce(int knapsackSize, List<KnapsackItem> knapsackItems)
    {
        List<KnapsackItem> newKnapsackItems = [];
        int currentKnapsackSize = 0;
        foreach (KnapsackItem t in knapsackItems.Where(t => currentKnapsackSize + t.Weight <= knapsackSize))
        {
            newKnapsackItems.Add(t);
            currentKnapsackSize += t.Weight;
        }
        return newKnapsackItems;
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
