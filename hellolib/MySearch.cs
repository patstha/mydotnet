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

        public static bool BinarySearchIntegers(int[] arrayToSearch, int queryItem)
        {
            int[] inputArray = arrayToSearch;
            Array.Sort(inputArray);
            int length = inputArray.Length;
            int lowerBound = 0;
            int upperBound = length;
            int midpoint = inputArray.Length / 2;
            int midpointValue = inputArray[midpoint];
            if (CheckIfQueryIsTheCentralTerm(inputArray, lowerBound, upperBound, queryItem)) 
            {
                return true;
            }
            else if (midpointValue < queryItem)
            {
                // search the lower half
                lowerBound = 0;
                upperBound = midpoint - 1;
            }
            else if (midpointValue > queryItem)
            {
                // search the upper half 
                lowerBound = midpoint + 1; 
                upperBound = length;
            }
            return false;
        }

        private static bool CheckIfQueryIsTheCentralTerm(int[] inputArray, int lowerBound, int upperBound, int queryItem)
        {
            int midpoint = (upperBound - lowerBound) / 2;
            int midpointValue = inputArray[midpoint];
            if (midpointValue == queryItem) 
            {
                return true;
            }
            return false;
        }
    }
}