namespace hellolib;

public static class TwoSum
{
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