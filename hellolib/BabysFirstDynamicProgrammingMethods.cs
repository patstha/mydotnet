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
        List<KnapsackItem> bestCombination = [];
        decimal bestCost = 0;

        int n = knapsackItems.Count;
        // There are 2^n possible combinations of items
        for (int i = 0; i < (1 << n); i++)
        {
            List<KnapsackItem> currentCombination = [];
            int currentWeight = 0;
            decimal currentCost = 0;

            for (int j = 0; j < n; j++)
            {
                // Check if the j-th item is included in the i-th combination
                if ((i & (1 << j)) != 0)
                {
                    KnapsackItem item = knapsackItems[j];
                    currentWeight += item.Weight;
                    currentCost += item.Cost;
                    currentCombination.Add(item);
                }
            }

            // Debugging output
            Console.WriteLine($"Combination {i}: Weight = {currentWeight}, Cost = {currentCost}");

            // Update the best combination if the current one is better
            if (currentWeight <= knapsackSize && currentCost > bestCost)
            {
                bestCombination = currentCombination;
                bestCost = currentCost;
            }
        }

        return bestCombination;
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
