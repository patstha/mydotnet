using System;
using System.Collections.Generic;

namespace hellolib
{
    public static class TwoSum
    {
        public static bool CheckExists(int[] a, int X)
        {
            List<int> myList = new List<int>();
            foreach (int element in a)
            {
                myList.Add(element);
            }
            foreach (int element in myList)
            {
                if (myList.Contains(X - element))
                {
                    return true;
                }
            }
            return false;
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
}