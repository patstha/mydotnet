using System;

namespace hellolib
{
    public static class MySearch
    {
        public static bool LinearSearchIntegers(int[] arrayToSearch, int queryItem)
        {
            for (int i = 0; i < arrayToSearch.Length; i++)
            {
                if (arrayToSearch[i] == queryItem)
                { 
                    return true;
                }
            }
            return false;
        }
    }
}