namespace tests
{
    public class DotnetNineGuidTests
    {
        private Func<DateTimeOffset> TimestampProvider(int delay, DateTimeOffset startTime) => () => startTime.AddMilliseconds(delay);

        [Fact]
        public Task GenerateGuidv7_ShouldGenerateGuidv7_sequentially1()
        {
            DateTimeOffset startTime = DateTimeOffset.UtcNow;
            DotnetNineGuid firstObject = new(TimestampProvider(10, startTime));
            Guid first = firstObject.GetGuid();
            long firstLong = DotnetNineGuid.ExtractTimestamp(first);
            DateTimeOffset firstDateTimeOffset = firstObject.GetTimestamp();
            DotnetNineGuid secondObject = new(TimestampProvider(11, startTime));
            Guid second = secondObject.GetGuid();
            long secondLong = DotnetNineGuid.ExtractTimestamp(second);
            DateTimeOffset secondDateTimeOffset = secondObject.GetTimestamp();

            bool actual = secondLong > firstLong;
            firstDateTimeOffset.Should().BeBefore(secondDateTimeOffset);
            actual.Should().BeTrue();
            return Task.CompletedTask;
        }

        [Fact]
        public void GenerateGuidv7_ShouldGenerateGuidv7_sequentially2()
        {
            List<DotnetNineGuid> objects = new List<DotnetNineGuid>();
            DateTimeOffset startTime = DateTimeOffset.UtcNow;

            for (int i = 0; i < 1_000; i++)
            {
                DotnetNineGuid myObject = new(TimestampProvider(i * 10, startTime));
                objects.Add(myObject);
            }

            for (int i = 0; i < objects.Count; i++)
            {
                for (int j = i + 1; j < objects.Count; j++)
                {
                    long firstLong = DotnetNineGuid.ExtractTimestamp(objects[i].GetGuid());
                    long secondLong = DotnetNineGuid.ExtractTimestamp(objects[j].GetGuid());
                    firstLong.Should().BeLessThan(secondLong);
                }
            }
        }

        [Fact]
        public void GenerateGuidv7_ShouldGenerateGuidv7_sequentially3()
        {
            List<DotnetNineGuid> objects = new List<DotnetNineGuid>();
            DateTimeOffset startTime = DateTimeOffset.UtcNow;

            for (int i = 0; i < 1_000_000; i++)
            {
                DotnetNineGuid myObject = new(TimestampProvider(i * 10, startTime));
                objects.Add(myObject);
            }

            // Sort objects by timestamp
            objects.Sort((a, b) => DotnetNineGuid.ExtractTimestamp(a.GetGuid()).CompareTo(DotnetNineGuid.ExtractTimestamp(b.GetGuid())));

            // Verify the order
            for (int i = 0; i < objects.Count - 1; i++)
            {
                long firstLong = DotnetNineGuid.ExtractTimestamp(objects[i].GetGuid());
                long secondLong = DotnetNineGuid.ExtractTimestamp(objects[i + 1].GetGuid());
                firstLong.Should().BeLessThan(secondLong);
            }
        }
    }
}
