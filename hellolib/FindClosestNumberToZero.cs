namespace hellolib;

public class FindClosestNumberToZero(ILogger<FindClosestNumberToZero> logger)
{
    public int FindClosestNumber(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            logger.LogWarning("Input array is null or empty.");
            return 0;
        }

        if (nums.Length == 1)
        {
            logger.LogInformation("Single element array, returning the only element.");
            return nums[0];
        }

        int[] abs = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            abs[i] = Math.Abs(nums[i]);
        }

        Array.Sort(abs);

        int closestNumber = nums.Contains(abs[0]) ? abs[0] : -abs[0];
        logger.LogInformation($"Closest number to zero found: {closestNumber}");

        return closestNumber;
    }
}



//Given an integer array nums of size n, return the number with the value closest to 0 in nums.If there are multiple answers, return the number with the largest value.



//Example 1:

//Input: nums = [-4, -2, 1, 4, 8]
//Output: 1
//Explanation:
//The distance from -4 to 0 is |-4| = 4.
//The distance from -2 to 0 is |-2| = 2.
//The distance from 1 to 0 is |1| = 1.
//The distance from 4 to 0 is |4| = 4.
//The distance from 8 to 0 is |8| = 8.
//Thus, the closest number to 0 in the array is 1.

//Example 2:

//Input: nums = [2, -1, 1]
//Output: 1
//Explanation: 1 and -1 are both the closest numbers to 0, so 1 being larger is returned.



//Constraints:

//    1 <= n <= 1000
//    -105 <= nums[i] <= 105

