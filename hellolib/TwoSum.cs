namespace hellolib;

public static class TwoSum
{
    public static bool CheckExists(int[] a, int X)
    {
        return Enumerable.Range(0, a.Length)
                         .SelectMany(i => Enumerable.Range(i + 1, a.Length - i - 1), (i, j) => new { i, j })
                         .Any(pair => a[pair.i] + a[pair.j] == X);
    }

    public static bool CheckExistsHashed(int[] array, int target)
    {
        HashSet<int> mySet = new();
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