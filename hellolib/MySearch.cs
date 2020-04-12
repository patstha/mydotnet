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

        public static int BinarySearchIntegers(int[] arrayToSearch, int queryItem)
        {
            int[] inputArray = arrayToSearch;
            Array.Sort(inputArray);
            int lowerBound = 0;
            int upperBound = inputArray.Length - 1;
            int midPoint;
            while (lowerBound <= upperBound)
            {
                midPoint = (upperBound + lowerBound) / 2;
                if (inputArray[midPoint] == queryItem)
                {
                    return midPoint;
                } 
                else if (inputArray[midPoint] < queryItem)
                {
                    lowerBound = midPoint + 1;
                } 
                else if (inputArray[midPoint] > queryItem)
                {
                    upperBound = midPoint - 1;
                }
            }
            return -1;
        }
    }
}