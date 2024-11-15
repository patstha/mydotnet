namespace hellolib;

public class DotnetNineGuid
{
    private readonly DateTimeOffset _timestampUtc;
    private readonly Guid _guid;

    public DotnetNineGuid(Func<DateTimeOffset> timestampProvider)
    {
        _timestampUtc = timestampProvider();
        _guid = Guid.CreateVersion7(_timestampUtc);
    }

    public Guid GetGuid() => _guid;
    public DateTimeOffset GetTimestamp() => _timestampUtc;

    public static long ExtractTimestamp(Guid uuid)
    {
        byte[] bytes = uuid.ToByteArray();
        long timestamp = BitConverter.ToInt64(bytes, 0) & 0x0000FFFFFFFFFFFF;
        return timestamp;
    }
}