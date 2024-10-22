namespace tests;

public class MergeSortedArrayTests
{
    private readonly ILogger<MergeSortedArray> _logger;
    private static readonly int[] expectation = [1, 2, 2, 3, 5, 6];
    private static readonly int[] expectationArray = [1];
    private static readonly int[] expectationArray0 = [10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100];
    private static readonly int[] expectationArray1 = [1, 2, 3, 5, 6, 99999];

    public MergeSortedArrayTests() => _logger = Substitute.For<ILogger<MergeSortedArray>>();
    [Fact]
    public void Merge_ShouldReturn1()
    {
        int[] nums1 = [1, 2, 3, 0, 0, 0]; // Corrected initialization
        int m = 3;
        int[] nums2 = [2, 5, 6]; // Corrected initialization
        int n = 3;
        MergeSortedArray mergeSortedArray = new(_logger);
        mergeSortedArray.Merge(nums1, m, nums2, n);

        nums1.Should().BeEquivalentTo(expectation); // Corrected initialization
    }

    [Fact]
    public void Merge_ShouldReturn2()
    {
        int[] nums1 = [1]; // Corrected initialization
        int m = 1;
        int[] nums2 = []; // Corrected initialization (empty array)
        int n = 0;
        MergeSortedArray mergeSortedArray = new(_logger);
        mergeSortedArray.Merge(nums1, m, nums2, n);

        nums1.Should().BeEquivalentTo(expectationArray); // Corrected initialization
    }

    [Fact]
    public void Merge_ShouldReturn3()
    {
        int[] nums1 = [0]; // Corrected initialization
        int m = 0; // Set m to 0 since there are no valid elements in nums1
        int[] nums2 = [1]; // Corrected initialization
        int n = 1; // n is 1 since nums2 has one element
        MergeSortedArray mergeSortedArray = new(_logger);
        mergeSortedArray.Merge(nums1, m, nums2, n);

        nums1.Should().BeEquivalentTo(expectationArray); // Corrected initialization
    }

    [Fact]
    public void Merge_ShouldReturn_kus()
    {
        int[] nums1 = [10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54, 56, 58, 60, 62, 64, 66, 68, 70, 72, 74, 76, 78, 80, 82, 84, 86, 88, 90, 92, 94, 96, 98, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        int m = 46;
        int[] nums2 = [11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35, 37, 39, 41, 43, 45, 47, 49, 51, 53, 55, 57, 59, 61, 63, 65, 67, 69, 71, 73, 75, 77, 79, 81, 83, 85, 87, 89, 91, 93, 95, 97, 99];
        int n = 45;
        MergeSortedArray mergeSortedArray = new(_logger);
        mergeSortedArray.Merge(nums1, m, nums2, n);

        nums1.Should().BeEquivalentTo(expectationArray0);
    }

    [Fact]
    public void Merge_ShouldReturn_kus1()
    {
        int[] nums1 = [1, 2, 3, 0, 0, 0]; // Corrected initialization
        int m = 3;
        int[] nums2 = [5, 6, 99999]; // Corrected initialization
        int n = 3;
        MergeSortedArray mergeSortedArray = new(_logger);
        mergeSortedArray.Merge(nums1, m, nums2, n);

        nums1.Should().BeEquivalentTo(expectationArray1); // Corrected initialization
    }

}
