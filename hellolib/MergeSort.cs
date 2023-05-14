namespace hellolib;

public class MergeSort
{
    public static void SortIntegers(int[] input)
    {
        if (input.Length <= 1) return;
        int leftSize = input.Length / 2;
        int rightSize = input.Length - leftSize;
        int[] left = new int[leftSize];
        int[] right = new int[rightSize];

        Array.Copy(input, 0, left, 0, leftSize);
        Array.Copy(input, leftSize, right, 0, rightSize);

        SortIntegers(left);
        SortIntegers(right);

        Merges(input, left, right);
    }

    private static void Merges(int[] input, int[] left, int[] right)
    {
        int leftIndex = 0;
        int rightIndex = 0;
        int targetIndex = 0;
        int remaining = left.Length + right.Length;

        while (remaining > 0)
        {
            if (leftIndex >= left.Length)
            {
                input[targetIndex] = right[rightIndex++];
            }

            else if (rightIndex >= right.Length)
            {
                input[targetIndex] = left[leftIndex++];
            }

            else if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
            {
                input[targetIndex] = left[leftIndex++];
            }

            else
            {
                input[targetIndex] = right[rightIndex++];
            }

            targetIndex++;
            remaining--;
        }
    }
}
