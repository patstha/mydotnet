using Microsoft.Extensions.Logging;
using NSubstitute;
using hellolib;

namespace tests;

public class MyCleanerTests
{
    private readonly ILogger<MyCleaner> _logger;
    private readonly MyCleaner _myCleaner;

    public MyCleanerTests()
    {
        _logger = Substitute.For<ILogger<MyCleaner>>();
        _myCleaner = new MyCleaner(_logger);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("           ", "")]
    public void CleanUrl_ShouldReturnEmptyStringForEmptyInput(string input, string expectedOutput)
    {
        // Act 
        string actual = _myCleaner.CleanUrl(input);
        actual.Should().Be(expectedOutput);
    }

    [Theory]
    [InlineData("https://www.ojrq.net/p/?return=https%3A%2F%2Felgato.sjv.io%2Fc%2F1378764%2F1064223%2F13666%3Fu%3Dhttps%253A%252F%252Fwww.elgato.com%252Fus%252Fen%252Fp%252Ffacecam-neo%26svlink%3D10538211%26level%3D1&cid=13666&tpsync=yes&auth=5781a01fa17f6b33", "https://www.elgato.com/us/en/p/facecam-neo")]
    [InlineData("https://www.tkqlhce.com/click-4485850-13112209?sid=e4e977b23d4c11ef8314763100633dd80INT&url=https%3A%2F%2Fcomputers.woot.com%2Foffers%2Flogitech-g920-driving-force-racing-wheel-and-floor-pedals-3", "https://computers.woot.com/offers/logitech-g920-driving-force-racing-wheel-and-floor-pedals-3")]
    public void CleanUrl_ShouldReturnValidOutput(string input, string expectedOutput)
    {
        // Act 
        string actual = _myCleaner.CleanUrl(input);
        actual.Should().Be(expectedOutput);
    }
}
