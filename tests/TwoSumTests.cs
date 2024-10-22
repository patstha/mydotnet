namespace tests
{
    public class TwoSumTests
    {
        public static readonly int[][] SumExistsData = new int[][]
        {
            new int[] { 1, 5, 3, 7, 02, 8 },
            new int[] { 1, 5, 3, 7, 12, 8 },
            new int[] { 1, 5, 3, 7, 22, 8 },
            new int[] { 1, 5, 3, 7, 32, 8 },
            new int[] { 1, 5, 3, 7, 42, 8 },
            new int[] { 1, 5, 3, 7, 52, 8 },
            new int[] { 1, 5, 3, 7, 62, 8 },
            new int[] { 1, 5, 3, 7, 72, 8 },
            new int[] { 1, 5, 3, 7, 82, 8 },
            new int[] { 1, 5, 3, 7, 92, 8 }
        };

        public static readonly int[] SumExistsValues = new int[]
        {
            10, 20, 30, 40, 50, 60, 70, 80, 90, 100
        };

        public static readonly int[][] SumDoesNotExistData = new int[][]
        {
            new int[] { 1, 5, 3, 7, 12, 9 },
            new int[] { 1, 5, 3, 7, 22, 9 },
            new int[] { 1, 5, 3, 7, 32, 9 },
            new int[] { 1, 5, 3, 7, 42, 9 },
            new int[] { 1, 5, 3, 7, 52, 9 },
            new int[] { 1, 5, 3, 7, 62, 9 },
            new int[] { 1, 5, 3, 7, 72, 9 },
            new int[] { 1, 5, 3, 7, 82, 9 }
        };

        public static readonly int[] SumDoesNotExistValues = new int[]
        {
            20, 30, 40, 50, 60, 70, 80, 90
        };

        public static readonly int[][] SumDoesNotExistTenData = new int[][]
        {
            new int[] { 1, 5, 3, 7, 10, 9 },
            new int[] { 1, 5, 3, 7, 10, 9 },
            new int[] { 1, 5, 3, 7, 10, 9 },
            new int[] { 1, 5, 3, 7, 10, 9 },
            new int[] { 1, 5, 3, 7, 10, 9 },
            new int[] { 1, 5, 3, 7, 10, 9 },
            new int[] { 1, 5, 3, 7, 10, 9 },
            new int[] { 1, 5, 3, 7, 10, 9 }
        };

        public static readonly int[] SumDoesNotExistTenValues = new int[]
        {
            20, 30, 40, 50, 60, 70, 80, 90
        };

        public static readonly int[][] SumExistsTenData = new int[][]
        {
            new int[] { 1, 5, 3, 7, 10, 10, 09 },
            new int[] { 1, 5, 3, 7, 10, 10, 19 },
            new int[] { 1, 5, 3, 7, 10, 10, 29 },
            new int[] { 1, 5, 3, 7, 10, 10, 39 },
            new int[] { 1, 5, 3, 7, 10, 10, 49 },
            new int[] { 1, 5, 3, 7, 10, 10, 59 },
            new int[] { 1, 5, 3, 7, 10, 10, 69 },
            new int[] { 1, 5, 3, 7, 10, 10, 79 },
            new int[] { 1, 5, 3, 7, 10, 10, 89 },
            new int[] { 1, 5, 3, 7, 10, 10, 99 }
        };

        public static readonly int[] SumExistsTenValues = new int[]
        {
            10, 20, 30, 40, 50, 60, 70, 80, 90, 100
        };

        public static readonly int[][] SumExistsHashedData = new int[][]
        {
            new int[] { 1, 5, 3, 7, 12, 08 },
            new int[] { 1, 5, 3, 7, 12, 18 },
            new int[] { 1, 5, 3, 7, 12, 28 },
            new int[] { 1, 5, 3, 7, 12, 38 },
            new int[] { 1, 5, 3, 7, 12, 48 },
            new int[] { 1, 5, 3, 7, 12, 58 },
            new int[] { 1, 5, 3, 7, 12, 68 },
            new int[] { 1, 5, 3, 7, 12, 78 },
            new int[] { 1, 5, 3, 7, 12, 88 },
            new int[] { 1, 5, 3, 7, 12, 98 },
            new int[] { 1, 5, 3, 7, 12, 108 }
        };

        public static readonly int[] SumExistsHashedValues = new int[]
        {
            20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120
        };

        public static readonly int[][] SumDoesNotExistHashedTenData = new int[][]
        {
            new int[] { 1, 5, 3, 7, 10, 09 },
            new int[] { 1, 5, 3, 7, 10, 19 },
            new int[] { 1, 5, 3, 7, 10, 29 },
            new int[] { 1, 5, 3, 7, 10, 39 },
            new int[] { 1, 5, 3, 7, 10, 49 },
            new int[] { 1, 5, 3, 7, 10, 59 },
            new int[] { 1, 5, 3, 7, 10, 69 },
            new int[] { 1, 5, 3, 7, 10, 79 },
            new int[] { 1, 5, 3, 7, 10, 89 },
            new int[] { 1, 5, 3, 7, 10, 99 },
            new int[] { 1, 5, 3, 7, 10, 109 }
        };

        public static readonly int[] SumDoesNotExistHashedTenValues = new int[]
        {
            20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120
        };

        public static readonly int[][] SumDoesNotExistHashedData = new int[][]
        {
            new int[] { 1, 5, 3, 7, 12, 09 },
            new int[] { 1, 5, 3, 7, 12, 19 },
            new int[] { 1, 5, 3, 7, 12, 29 },
            new int[] { 1, 5, 3, 7, 12, 39 },
            new int[] { 1, 5, 3, 7, 12, 49 },
            new int[] { 1, 5, 3, 7, 12, 59 },
            new int[] { 1, 5, 3, 7, 12, 69 },
            new int[] { 1, 5, 3, 7, 12, 79 },
            new int[] { 1, 5, 3, 7, 12, 89 },
            new int[] { 1, 5, 3, 7, 12, 99 },
            new int[] { 1, 5, 3, 7, 12, 109 }
        };

        public static readonly int[] SumDoesNotExistHashedValues = new int[]
        {
            20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120
        };

        [Fact]
        public void Freebie() => Assert.True(true);

        [Theory]
        [MemberData(nameof(SumExistsData), nameof(SumExistsValues))]
        public void SumExistsInCheckExists(int[] a, int X) => Assert.True(TwoSum.CheckExists(a, X));

        [Theory]
        [MemberData(nameof(SumDoesNotExistData), nameof(SumDoesNotExistValues))]
        public void SumDoesNotExistInCheckExists(int[] a, int X) => Assert.False(TwoSum.CheckExists(a, X));

        [Theory]
        [MemberData(nameof(SumDoesNotExistTenData), nameof(SumDoesNotExistTenValues))]
        public void SumDoesNotExistInCheckExistsTen(int[] a, int X) => Assert.False(TwoSum.CheckExists(a, X));

        [Theory]
        [MemberData(nameof(SumExistsTenData), nameof(SumExistsTenValues))]
        public void SumExistsInCheckExistsTen(int[] a, int X) => Assert.True(TwoSum.CheckExists(a, X));

        [Theory]
        [MemberData(nameof(SumExistsHashedData), nameof(SumExistsHashedValues))]
        public void SumExistsInCheckExistsHashed(int[] a, int X) => Assert.True(TwoSum.CheckExistsHashed(a, X));

        [Theory]
        [MemberData(nameof(SumDoesNotExistHashedTenData), nameof(SumDoesNotExistHashedTenValues))]
        public void SumDoesNotExistInCheckExistsHashedTen(int[] a, int X) => Assert.False(TwoSum.CheckExistsHashed(a, X));

        [Theory]
        [MemberData(nameof(SumDoesNotExistHashedData), nameof(SumDoesNotExistHashedValues))]
        public void SumDoesNotExistInCheckExistsHashed(int[] a, int X) => Assert.False(TwoSum.CheckExistsHashed(a, X));
    }
}
