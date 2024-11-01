namespace hellolib;

public class BabysFirstDynamicProgrammingMethods
{
    public static int FibonacciWithRecursion(int n)
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
    
    static int FibonacciWithoutRecursion(int n)
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

// using System;
//
// class Program
// {
//     static void Main()
//     {
//         int n = 10; // Example input
//         Console.WriteLine($"Fibonacci({n}) = {Fibonacci(n)}");
//     }
//
//     static int Fibonacci(int n)
//     {
//         if (n <= 1)
//             return n;
//
//         int[] dp = new int[n + 1];
//         dp[0] = 0;
//         dp[1] = 1;
//
//         for (int i = 2; i <= n; i++)
//         {
//             dp[i] = dp[i - 1] + dp[i - 2];
//         }
//
//         return dp[n];
//     }
// }
