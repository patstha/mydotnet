namespace tests;

using hellolib;

public class TwoSumTests
{
    private static readonly int[] Array1 = [1, 5, 3, 7, 2, 8];
    private static readonly int[] Array2 = [1, 5, 3, 7, 12, 8];
    private static readonly int[] Array3 = [1, 5, 3, 7, 22, 8];
    private static readonly int[] Array4 = [1, 5, 3, 7, 32, 8];
    private static readonly int[] Array5 = [1, 5, 3, 7, 42, 8];
    private static readonly int[] Array6 = [1, 5, 3, 7, 52, 8];
    private static readonly int[] Array7 = [1, 5, 3, 7, 62, 8];
    private static readonly int[] Array8 = [1, 5, 3, 7, 72, 8];
    private static readonly int[] Array9 = [1, 5, 3, 7, 82, 8];
    private static readonly int[] Array10 = [1, 5, 3, 7, 92, 8];

    private static readonly int[] Array11 = [1, 5, 3, 7, 12, 9];
    private static readonly int[] Array12 = [1, 5, 3, 7, 22, 9];
    private static readonly int[] Array13 = [1, 5, 3, 7, 32, 9];
    private static readonly int[] Array14 = [1, 5, 3, 7, 42, 9];
    private static readonly int[] Array15 = [1, 5, 3, 7, 52, 9];
    private static readonly int[] Array16 = [1, 5, 3, 7, 62, 9];
    private static readonly int[] Array17 = [1, 5, 3, 7, 72, 9];
    private static readonly int[] Array18 = [1, 5, 3, 7, 82, 9];

    private static readonly int[] Array19 = [1, 5, 3, 7, 10, 9];
    private static readonly int[] Array20 = [1, 5, 3, 7, 10, 10, 9];
    private static readonly int[] Array21 = [1, 5, 3, 7, 10, 10, 19];
    private static readonly int[] Array22 = [1, 5, 3, 7, 10, 10, 29];
    private static readonly int[] Array23 = [1, 5, 3, 7, 10, 10, 39];
    private static readonly int[] Array24 = [1, 5, 3, 7, 10, 10, 49];
    private static readonly int[] Array25 = [1, 5, 3, 7, 10, 10, 59];
    private static readonly int[] Array26 = [1, 5, 3, 7, 10, 10, 69];
    private static readonly int[] Array27 = [1, 5, 3, 7, 10, 10, 79];
    private static readonly int[] Array28 = [1, 5, 3, 7, 10, 10, 89];
    private static readonly int[] Array29 = [1, 5, 3, 7, 10, 10, 99];

    private static readonly int[] Array30 = [1, 5, 3, 7, 12, 8];
    private static readonly int[] Array31 = [1, 5, 3, 7, 12, 18];
    private static readonly int[] Array32 = [1, 5, 3, 7, 12, 28];
    private static readonly int[] Array33 = [1, 5, 3, 7, 12, 38];
    private static readonly int[] Array34 = [1, 5, 3, 7, 12, 48];
    private static readonly int[] Array35 = [1, 5, 3, 7, 12, 58];
    private static readonly int[] Array36 = [1, 5, 3, 7, 12, 68];
    private static readonly int[] Array37 = [1, 5, 3, 7, 12, 78];
    private static readonly int[] Array38 = [1, 5, 3, 7, 12, 88];
    private static readonly int[] Array39 = [1, 5, 3, 7, 12, 98];
    private static readonly int[] Array40 = [1, 5, 3, 7, 12, 108];

    private static readonly int[] Array41 = [1, 5, 3, 7, 10, 9];
    private static readonly int[] Array42 = [1, 5, 3, 7, 10, 19];
    private static readonly int[] Array43 = [1, 5, 3, 7, 10, 29];
    private static readonly int[] Array44 = [1, 5, 3, 7, 10, 39];
    private static readonly int[] Array45 = [1, 5, 3, 7, 10, 49];
    private static readonly int[] Array46 = [1, 5, 3, 7, 10, 59];
    private static readonly int[] Array47 = [1, 5, 3, 7, 10, 69];
    private static readonly int[] Array48 = [1, 5, 3, 7, 10, 79];
    private static readonly int[] Array49 = [1, 5, 3, 7, 10, 89];
    private static readonly int[] Array50 = [1, 5, 3, 7, 10, 99];
    private static readonly int[] Array51 = [1, 5, 3, 7, 10, 109];

    private static readonly int[] Array52 = [1, 5, 3, 7, 12, 9];
    private static readonly int[] Array53 = [1, 5, 3, 7, 12, 19];
    private static readonly int[] Array54 = [1, 5, 3, 7, 12, 29];
    private static readonly int[] Array55 = [1, 5, 3, 7, 12, 39];
    private static readonly int[] Array56 = [1, 5, 3, 7, 12, 49];
    private static readonly int[] Array57 = [1, 5, 3, 7, 12, 59];
    private static readonly int[] Array58 = [1, 5, 3, 7, 12, 69];
    private static readonly int[] Array59 = [1, 5, 3, 7, 12, 79];
    private static readonly int[] Array60 = [1, 5, 3, 7, 12, 89];
    private static readonly int[] Array61 = [1, 5, 3, 7, 12, 99];
    private static readonly int[] Array62 = [1, 5, 3, 7, 12, 109];

    public static TheoryData<int[], int> SumExistsData => new()
    {
        { Array1, 10 },
        { Array2, 20 },
        { Array3, 30 },
        { Array4, 40 },
        { Array5, 50 },
        { Array6, 60 },
        { Array7, 70 },
        { Array8, 80 },
        { Array9, 90 },
        { Array10, 100 }
    };

    public static TheoryData<int[], int> SumDoesNotExistData => new()
    {
        { Array11, 20 },
        { Array12, 30 },
        { Array13, 40 },
        { Array14, 50 },
        { Array15, 60 },
        { Array16, 70 },
        { Array17, 80 },
        { Array18, 90 }
    };

    public static TheoryData<int[], int> SumDoesNotExistTenData => new()
    {
        { Array19, 20 },
        { Array19, 30 },
        { Array19, 40 },
        { Array19, 50 },
        { Array19, 60 },
        { Array19, 70 },
        { Array19, 80 },
        { Array19, 90 }
    };

    public static TheoryData<int[], int> SumExistsTenData => new()
    {
        { Array20, 10 },
        { Array21, 20 },
        { Array22, 30 },
        { Array23, 40 },
        { Array24, 50 },
        { Array25, 60 },
        { Array26, 70 },
        { Array27, 80 },
        { Array28, 90 },
        { Array29, 100 }
    };

    public static TheoryData<int[], int> SumExistsHashedData => new()
    {
        { Array30, 20 },
        { Array31, 30 },
        { Array32, 40 },
        { Array33, 50 },
        { Array34, 60 },
        { Array35, 70 },
        { Array36, 80 },
        { Array37, 90 },
        { Array38, 100 },
        { Array39, 110 },
        { Array40, 120 }
    };

    public static TheoryData<int[], int> SumDoesNotExistHashedTenData => new()
    {
        { Array41, 20 },
        { Array42, 30 },
        { Array43, 40 },
        { Array44, 50 },
        { Array45, 60 },
        { Array46, 70 },
        { Array47, 80 },
        { Array48, 90 },
        { Array49, 100 },
        { Array50, 110 },
        { Array51, 120 }
    };

    public static TheoryData<int[], int> SumDoesNotExistHashedData => new()
    {
        { Array52, 20 },
        { Array53, 30 },
        { Array54, 40 },
        { Array55, 50 },
        { Array56, 60 },
        { Array57, 70 },
        { Array58, 80 },
        { Array59, 90 },
        { Array60, 100 },
        { Array61, 110 },
        { Array62, 120 }
    };

    [Fact]
    public void Freebie() => Assert.True(true);

    [Theory]
    [MemberData(nameof(SumExistsData))]
    public void SumExistsInCheckExists(int[] a, int x) => Assert.True(TwoSum.CheckExists(a, x));

    [Theory]
    [MemberData(nameof(SumDoesNotExistData))]
    public void SumDoesNotExistInCheckExists(int[] a, int x) => Assert.False(TwoSum.CheckExists(a, x));

    [Theory]
    [MemberData(nameof(SumDoesNotExistTenData))]
    public void SumDoesNotExistInCheckExistsTen(int[] a, int x) => Assert.False(TwoSum.CheckExists(a, x));

    [Theory]
    [MemberData(nameof(SumExistsTenData))]
    public void SumExistsInCheckExistsTen(int[] a, int x) => Assert.True(TwoSum.CheckExists(a, x));

    [Theory]
    [MemberData(nameof(SumExistsHashedData))]
    public void SumExistsInCheckExistsHashed(int[] a, int x) => Assert.True(TwoSum.CheckExistsHashed(a, x));

    [Theory]
    [MemberData(nameof(SumDoesNotExistHashedTenData))]
    public void SumDoesNotExistInCheckExistsHashedTen(int[] a, int x) => Assert.False(TwoSum.CheckExistsHashed(a, x));

    [Theory]
    [MemberData(nameof(SumDoesNotExistHashedData))]
    public void SumDoesNotExistInCheckExistsHashed(int[] a, int x) => Assert.False(TwoSum.CheckExistsHashed(a, x));
}
