namespace tests;

public class DotnetNineGuidTests
{
    [Fact]
    public async Task GenerateGuidv7_ShouldGenerateGuidv7_sequentially1()
    {
        DotnetNineGuid firstObject = new();
        Guid first = firstObject.GetGuid();
        long firstLong = DotnetNineGuid.ExtractTimestamp(first);
        DateTimeOffset firstDateTimeOffset = firstObject.GetTimestamp();
        await Task.Delay(1);
        DotnetNineGuid secondObject = new();
        Guid second = secondObject.GetGuid();
        long secondLong = DotnetNineGuid.ExtractTimestamp(second);
        DateTimeOffset secondDateTimeOffset = secondObject.GetTimestamp();

        bool actual = secondLong > firstLong;
        firstDateTimeOffset.Should().BeBefore(secondDateTimeOffset);
        actual.Should().BeTrue();
    }

    [Fact]
    public void GenerateGuidv7_ShouldGenerateGuidv7_sequentially2()
    {
        List<DotnetNineGuid> objects = new List<DotnetNineGuid>();
        DateTimeOffset startTime = DateTimeOffset.UtcNow;

        for (int i = 0; i < 1000; i++)
        {
            Func<DateTimeOffset> timestampProvider = () => startTime.AddMilliseconds(i);
            DotnetNineGuid myObject = new DotnetNineGuid(timestampProvider);
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
}