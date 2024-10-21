using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using System.Net.NetworkInformation;
namespace hellolib;
public class FindClosestNumberToZero
{
    public int FindClosestNumber(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return 0;
        }
        if (nums.Length == 1)
        {
            return nums[0];
        }
        int[] abs = [.. nums];
        for (int i = 0; i < nums.Length; i++)
        {
            abs[i] = Math.Abs(abs[i]);
        }
        Array.Sort(abs);
        if (nums.Contains(abs[0]))
        {
            return abs[0];
        }
        else
        {
             return -abs[0];
        }
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

