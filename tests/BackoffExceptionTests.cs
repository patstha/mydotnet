namespace tests;

public class BackoffExceptionTests
{
    [Fact]
    public async Task DoSomething()
    {
        BackoffException backoffException = new();
        await backoffException.BackoffSelfinflictedException("name");
    }
}
