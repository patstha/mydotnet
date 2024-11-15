namespace tests;

public class DotnetNineGuidTests
{
    [Fact]
    public async Task GenerateGuidv7_ShouldGenerateGuidv7_sequentially1()
    {
        DateTimeOffset startTime = DateTimeOffset.UtcNow;
        DotnetNineGuid firstObject = new(TimestampProvider(10, startTime));
        Guid first = firstObject.GetGuid();
        long firstLong = DotnetNineGuid.ExtractTimestamp(first);
        DateTimeOffset firstDateTimeOffset = firstObject.GetTimestamp();
        DotnetNineGuid secondObject = new(TimestampProvider(20, startTime));
        Guid second = secondObject.GetGuid();
        long secondLong = DotnetNineGuid.ExtractTimestamp(second);
        DateTimeOffset secondDateTimeOffset = secondObject.GetTimestamp();

        bool actual = secondLong > firstLong;
        firstDateTimeOffset.Should().BeBefore(secondDateTimeOffset);
        actual.Should().BeTrue();
        return;
        Func<DateTimeOffset> TimestampProvider(int delay, DateTimeOffset startTime) => startTime.AddMilliseconds(delay);
    }

    [Fact]
    public void GenerateGuidv7_ShouldGenerateGuidv7_sequentially2()
    {
        List<DotnetNineGuid> objects = [];
        DateTimeOffset startTime = DateTimeOffset.UtcNow;

        for (int i = 0; i < 1_000; i++)
        {
            int i1 = i;
            DotnetNineGuid myObject = new(TimestampProvider);
            objects.Add(myObject);
            continue;
            DateTimeOffset TimestampProvider() => startTime.AddMilliseconds(i1);
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
}