namespace hellolib;

public class DotnetNineGuid
{
    private DateTimeOffset TimestampUtc { get; } = DateTimeOffset.UtcNow;
    private Guid Guid { get; } = Guid.CreateVersion7();
    public Guid GetGuid() => Guid;
    public DateTimeOffset GetTimestamp() => TimestampUtc;
    public static long ExtractTimestamp(Guid uuid)
    {
        byte[] bytes = uuid.ToByteArray();
        long timestamp = BitConverter.ToInt64(bytes, 0) & 0x0000FFFFFFFFFFFF;
        return timestamp;
    }
}