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
}
