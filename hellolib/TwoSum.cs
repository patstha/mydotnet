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
        Dictionary<int, int> map = [];
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (map.TryGetValue(complement, out int value))
            {
                return [value, i];
            }
            map[nums[i]] = i;
        }
        return [];
    }

    public static bool CheckExists(int[] a, int x)
    {
        List<int> myList = [.. a];
        for (int i = 0; i < myList.Count; i++)
        {
            for (int j = i + 1; j < myList.Count; j++)
            {
                if (myList[i] + myList[j] == x)
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

            _ = mySet.Add(target - element);
        }
        return false;
    }
}