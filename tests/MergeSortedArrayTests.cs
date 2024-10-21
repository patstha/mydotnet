namespace tests;

public class MergeSortedArrayTests
{
    [Fact]
    public void Merge_ShouldReturn1()
    {
        int[] nums1 = [1, 2, 3, 0, 0, 0];
        int m = 3;
        int[] nums2 = [2, 5, 6];
        int n = 3;
        MergeSortedArray mergeSortedArray = new();
        mergeSortedArray.Merge(nums1, m, nums2, n);

        nums1.Should().BeEquivalentTo([1, 2, 2, 3, 5, 6]);
    }

    [Fact]
    public void Merge_ShouldReturn2()
    {
        int[] nums1 = [1];
        int m = 1;
        int[] nums2 = [];
        int n = 0;
        MergeSortedArray mergeSortedArray = new();
        mergeSortedArray.Merge(nums1, m, nums2, n);

        nums1.Should().BeEquivalentTo([1]);
    }

    [Fact]
    public void Merge_ShouldReturn3()
    {
        int[] nums1 = [0];
        int m = 1;
        int[] nums2 = [1];
        int n = 1;
        MergeSortedArray mergeSortedArray = new();
        mergeSortedArray.Merge(nums1, m, nums2, n);

        nums1.Should().BeEquivalentTo([1]);
    }
}
