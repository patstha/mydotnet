namespace tests;

public class MyCleanerTests
{
    private readonly ILogger<MyCleaner> _logger;
    private readonly HttpClient _httpClient;
    private readonly MyCleaner _myCleaner;

    public MyCleanerTests()
    {
        _logger = Substitute.For<ILogger<MyCleaner>>();
        _httpClient = new HttpClient(new HttpClientHandler { AllowAutoRedirect = true });
        _myCleaner = new MyCleaner(_logger, _httpClient);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("           ", "")]
    public async Task CleanUrl_ShouldReturnEmptyStringForEmptyInput(string input, string expectedOutput)
    {
        // Act 
        string actual = await _myCleaner.CleanUrlAsync(input);
        actual.Should().Be(expectedOutput);
    }

    [Theory]
    [InlineData("https://www.ojrq.net/p/?return=https%3A%2F%2Felgato.sjv.io%2Fc%2F1378764%2F1064223%2F13666%3Fu%3Dhttps%253A%252F%252Fwww.elgato.com%252Fus%252Fen%252Fp%252Ffacecam-neo%26svlink%3D10538211%26level%3D1&cid=13666&tpsync=yes&auth=5781a01fa17f6b33", "https://www.elgato.com/us/en/p/facecam-neo")]
    [InlineData("https://www.tkqlhce.com/click-4485850-13112209?sid=e4e977b23d4c11ef8314763100633dd80INT&url=https%3A%2F%2Fcomputers.woot.com%2Foffers%2Flogitech-g920-driving-force-racing-wheel-and-floor-pedals-3", "https://computers.woot.com/offers/logitech-g920-driving-force-racing-wheel-and-floor-pedals-3")]
    [InlineData("https://goto.walmart.com/c/2189989/612734/9383?subid1=def01ed63d4e11efb8829a5345c674ba0INT&sourceid=imp_000011112222333344&u=https%3A%2F%2Fwww.walmart.com%2Fplus", "https://www.walmart.com/plus")]
    [InlineData("https://goto.walmart.com/c/2189989/612734/9383?subid1=39da70663d5011ef85e9ea7718e137e00INT&sourceid=imp_000011112222333344&u=https%3A%2F%2Fwww.walmart.com%2Fip%2FSwiss-Tech-Drop-Bottom-Travel-Weekender-Duffel-Olive-Black%2F948430794", "https://www.walmart.com/ip/Swiss-Tech-Drop-Bottom-Travel-Weekender-Duffel-Olive-Black/948430794")]
    [InlineData("https://costway.pxf.io/c/10451/1450865/17220?subid1=04bb92ca3d5011ef91bd7a43b62703820INT&u=https%3A%2F%2Fwww.costway.com%2F12000-btu-22-seer2-208-230v-wifi-enabled-mini-split-air-conditioner-and-heater-white.html", "https://www.costway.com/12000-btu-22-seer2-208-230v-wifi-enabled-mini-split-air-conditioner-and-heater-white.html")]
    [InlineData("https://goto.target.com/c/10451/1216445/2092?subid1=afb43d763d5011efacb87ae1da200b850INT&u=https%3A%2F%2Fwww.target.com%2Fp%2Ffae-farm-nintendo-switch-digital%2F-%2FA-89638075", "https://www.target.com/p/fae-farm-nintendo-switch-digital/-/A-89638075")]
    [InlineData("https://slickdeals.net/?adobeRef=d92c693a3d5011efb40f5e3ace1557e10001&sdtrk=frontpage_recombee&prop=diavail-false%7Cdincp-0%7Cdinpd-0%7Cdipgavail-false%7Crcmid=4d911dbd885c9d4514957dfd7e40cdbf&afsrc=1&trd=Get%20Deal%20at%20Amazon&sdtid=17605128&tid=17605128&pno=972987&pv=d934885e3d5011efb40f5e3ace1557e1&au=880a0f2cfe1c4f9cab597d823947a3de", "https://www.amazon.com/gp/product/B0B5M5YB9G/")]
    [InlineData("https://slickdeals.net/?adobeRef=3600a9663d6311efbcdebafcfc5720790000&sdtrk=jfy&prop=diavail-false%7Cdincp-0%7Cdinpd-0%7Cdipgavail-false%7Crcmid-b410546529081f06acf4f98ecd492c65&afsrc=1&trd=Get%20Deal%20at%20Steam&sdtid=17602899&tid=17602899&pv=36090a2a3d6311efbcdebafcfc572079&au=880a0f2cfe1c4f9cab597d823947a3de&attr_track=JFYCarousel%3APosition%3A4%7CJFYCarousel%3AType%3Athread", "https://www.xbox.com/en-us/games/store/forza-horizon-4-1979-talbot-sunbeam-lotus/9nnm9m4t5j5q")]
    [InlineData("https://kus.runasp.net/", "https://kus.runasp.net/")]
    [InlineData("https://goto.walmart.com/c/10451/567111/9383?subid1=bf60adae3df511efb3c85a85c909964f0INT&veh=aff&sourceid=imp_000011112222333344&u=https%3A%2F%2Fwww.walmart.com%2Fip%2FHisense-75-Class-U7-Series-Mini-LED-ULED-4K-UHD-Google-Smart-TV-75U7K-QLED-Native-144Hz-1000-Nit-Dolby-Vision-IQ-Full-Array-Local-Dimming-Game-Mode-P%2F1300394852", "https://www.walmart.com/ip/Hisense-75-Class-U7-Series-Mini-LED-ULED-4K-UHD-Google-Smart-TV-75U7K-QLED-Native-144Hz-1000-Nit-Dolby-Vision-IQ-Full-Array-Local-Dimming-Game-Mode-P/1300394852")]
    public async Task CleanUrl_ShouldReturnValidOutput(string input, string expectedOutput)
    {
        // Act 
        string actual = await _myCleaner.CleanUrlAsync(input);
        actual.Should().Be(expectedOutput);
    }
}
