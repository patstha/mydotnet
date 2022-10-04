namespace hellolib
{
    public static class BubbleSort
    {
        public static int[] SortIntegers(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length - 1; j++)
                {
                    if (input[j] > input[j + 1])
                    {
                        int temp = input[j + 1];
                        input[j + 1] = input[j];
                        input[j] = temp;
                    }
                }
            }
            return input;
        }
    }
}