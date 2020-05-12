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
    }
}