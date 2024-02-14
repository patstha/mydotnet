namespace hellolib;

public static class TwoSum
{
    public static int[] GetTwoSumNaive(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (i != j && nums[i] + nums[j] == target)
                {
                    return [i, j];
                }
            }
        }
        return [];
    }

    public static int[] GetTwoSumOptimized(int[] nums, int target)
    {
        // create a hash map to store the elements and their indices
        Dictionary<int, int> map = new Dictionary<int, int>();

        // iterate through the array
        for (int i = 0; i < nums.Length; i++)
        {
            // calculate the complement of the current element
            int complement = target - nums[i];

            // check if the complement is already in the hash map
            if (map.ContainsKey(complement))
            {
                // return the indices of the current element and its complement
                return new int[] { map[complement], i };
            }

            // add the current element and its index to the hash map
            map[nums[i]] = i;
        }

        // return an empty array if no solution is found
        return new int[] { };
    }

    public static bool CheckExists(int[] a, int X)
    {
        List<int> myList = [.. a];
        for (int i = 0; i < myList.Count; i++)
        {
            for (int j = i + 1; j < myList.Count; j++)
            {
                if (myList[i] + myList[j] == X)
                {
                    return true;
                }
            }
        }
        return false;
    }


    public static bool CheckExistsHashed(int[] array, int target)
    {
        HashSet<int> mySet = [];
        foreach (int element in array)
        {
            if (mySet.Contains(element))
            {
                return true;
            }
            else
            {
                _ = mySet.Add(target - element);
            }
        }
        return false;
    }
}