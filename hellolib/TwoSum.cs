namespace hellolib;

public static class TwoSum
{
    public static bool CheckExists(int[] a, int X)
    {
        List<int> myList = new List<int>();
        myList.AddRange(a);
        myList.Remove(X / 2);
        return myList.Any(x => myList.Contains(X - x));
    }
    public static bool CheckExistsHashed(int[] array, int target)
    {
        HashSet<int> mySet = new HashSet<int>();
        foreach (int element in array)
        {
            if (mySet.Contains(element))
            {
                return true;
            }
            else
            {
                mySet.Add(target - element);
            }
        }
        return false;
    }
}