using System.Net;

namespace tests;

public class MyCleanerTests
{
    private readonly MyCleaner _myCleaner;

    public MyCleanerTests()
    {
        ILogger<MyCleaner> logger = Substitute.For<ILogger<MyCleaner>>();
        HttpClient httpClient = new(new HttpClientHandler { AllowAutoRedirect = true });
        _myCleaner = new MyCleaner(logger, httpClient);
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
    [InlineData(
        "https://www.ojrq.net/p/?return=https%3A%2F%2Felgato.sjv.io%2Fc%2F1378764%2F1064223%2F13666%3Fu%3Dhttps%253A%252F%252Fwww.elgato.com%252Fus%252Fen%252Fp%252Ffacecam-neo%26svlink%3D10538211%26level%3D1&cid=13666&tpsync=yes&auth=5781a01fa17f6b33",
        "https://www.elgato.com/us/en/p/facecam-neo")]
    [InlineData(
        "https://www.tkqlhce.com/click-4485850-13112209?sid=e4e977b23d4c11ef8314763100633dd80INT&url=https%3A%2F%2Fcomputers.woot.com%2Foffers%2Flogitech-g920-driving-force-racing-wheel-and-floor-pedals-3",
        "https://computers.woot.com/offers/logitech-g920-driving-force-racing-wheel-and-floor-pedals-3")]
    [InlineData(
        "https://goto.walmart.com/c/2189989/612734/9383?subid1=def01ed63d4e11efb8829a5345c674ba0INT&sourceid=imp_000011112222333344&u=https%3A%2F%2Fwww.walmart.com%2Fplus",
        "https://www.walmart.com/plus")]
    [InlineData(
        "https://goto.walmart.com/c/2189989/612734/9383?subid1=39da70663d5011ef85e9ea7718e137e00INT&sourceid=imp_000011112222333344&u=https%3A%2F%2Fwww.walmart.com%2Fip%2FSwiss-Tech-Drop-Bottom-Travel-Weekender-Duffel-Olive-Black%2F948430794",
        "https://www.walmart.com/ip/Swiss-Tech-Drop-Bottom-Travel-Weekender-Duffel-Olive-Black/948430794")]
    [InlineData(
        "https://costway.pxf.io/c/10451/1450865/17220?subid1=04bb92ca3d5011ef91bd7a43b62703820INT&u=https%3A%2F%2Fwww.costway.com%2F12000-btu-22-seer2-208-230v-wifi-enabled-mini-split-air-conditioner-and-heater-white.html",
        "https://www.costway.com/12000-btu-22-seer2-208-230v-wifi-enabled-mini-split-air-conditioner-and-heater-white.html")]
    [InlineData(
        "https://goto.target.com/c/10451/1216445/2092?subid1=afb43d763d5011efacb87ae1da200b850INT&u=https%3A%2F%2Fwww.target.com%2Fp%2Ffae-farm-nintendo-switch-digital%2F-%2FA-89638075",
        "https://www.target.com/p/fae-farm-nintendo-switch-digital/-/A-89638075")]
    [InlineData(
        "https://slickdeals.net/?adobeRef=d92c693a3d5011efb40f5e3ace1557e10001&sdtrk=frontpage_recombee&prop=diavail-false%7Cdincp-0%7Cdinpd-0%7Cdipgavail-false%7Crcmid=4d911dbd885c9d4514957dfd7e40cdbf&afsrc=1&trd=Get%20Deal%20at%20Amazon&sdtid=17605128&tid=17605128&pno=972987&pv=d934885e3d5011efb40f5e3ace1557e1&au=880a0f2cfe1c4f9cab597d823947a3de",
        "https://www.amazon.com/gp/product/B0B5M5YB9G/")]
    [InlineData(
        "https://slickdeals.net/?adobeRef=3600a9663d6311efbcdebafcfc5720790000&sdtrk=jfy&prop=diavail-false%7Cdincp-0%7Cdinpd-0%7Cdipgavail-false%7Crcmid-b410546529081f06acf4f98ecd492c65&afsrc=1&trd=Get%20Deal%20at%20Steam&sdtid=17602899&tid=17602899&pv=36090a2a3d6311efbcdebafcfc572079&au=880a0f2cfe1c4f9cab597d823947a3de&attr_track=JFYCarousel%3APosition%3A4%7CJFYCarousel%3AType%3Athread",
        "https://www.xbox.com/en-us/games/store/forza-horizon-4-1979-talbot-sunbeam-lotus/9nnm9m4t5j5q")]
    public async Task CleanUrl_ShouldReturnValidOutput(string input, string expectedOutput)
    {
        // Act 
        string actual = await _myCleaner.CleanUrlAsync(input);
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrl_ShouldReturnNullAndLogErrorOnException()
    {
        // Arrange
        const string input = "https://www.invalid-url.com";
        HttpClientHandlerStub handler = new((request, cancellationToken) =>
        {
            request.Should().NotBeNull();
            cancellationToken.IsCancellationRequested.Should().BeFalse();
            throw new HttpRequestException("Invalid URL");
        });
        HttpClient httpClient = new(handler);
        ILogger<MyCleaner> logger = Substitute.For<ILogger<MyCleaner>>();
        MyCleaner myCleaner = new(logger, httpClient);

        // Act
        string actual = await myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().BeNull();
        logger.Received().Log(
            LogLevel.Error,
            Arg.Any<EventId>(),
            Arg.Is<object>(v => v.ToString().Contains("Error processing URL: https://www.invalid-url.com")),
            Arg.Is<HttpRequestException>(ex => ex.Message == "Invalid URL"),
            Arg.Any<Func<object, Exception, string>>()
        );
    }

    [Fact]
    public async Task CleanUrl_ShouldReturnEmptyStringForNullInput()
    {
        // Act
        string actual = await _myCleaner.CleanUrlAsync(null);

        // Assert
        actual.Should().Be("");
    }

    [Fact]
    public async Task CleanUrl_ShouldReturnSameUrlIfNoExtractionNeeded()
    {
        // Arrange
        const string input = "https://www.example.com/path";
        const string expectedOutput = "https://www.example.com/path";

        // Act
        string actual = await _myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrl_ShouldRemoveAmazonExtraPathSegments()
    {
        // Arrange
        const string input =
            "https://www.amazon.com/gp/product/B08N5WRWNW/ref=ox_sc_saved_image_1?smid=ATVPDKIKX0DER&psc=1";
        const string expectedOutput = "https://www.amazon.com/gp/product/B08N5WRWNW/";

        // Act
        string actual = await _myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrl_ShouldFollowRedirects()
    {
        // Arrange
        const string input = "https://httpbin.org/redirect/1";
        const string expectedOutput = "https://httpbin.org/get";

        HttpClientHandlerStub handler = new((request, cancellationToken) =>
        {
            cancellationToken.IsCancellationRequested.Should().BeFalse();
            if (request.RequestUri?.ToString() == input)
            {
                return new HttpResponseMessage(HttpStatusCode.Redirect)
                {
                    Headers = { Location = new Uri("https://httpbin.org/get") }
                };
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                RequestMessage = request
            };
        });

        HttpClient httpClient = new(handler);
        ILogger<MyCleaner> logger = Substitute.For<ILogger<MyCleaner>>();
        MyCleaner myCleaner = new(logger, httpClient);

        // Act
        string actual = await myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrl_ShouldRemoveQueryParameters()
    {
        // Arrange
        const string input = "https://www.example.com/path?query=param";
        const string expectedOutput = "https://www.example.com/path";

        // Act
        string actual = await _myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrl_ShouldHandleUrlsWithNoQueryParameters()
    {
        // Arrange
        const string input = "https://www.example.com/path";
        const string expectedOutput = "https://www.example.com/path";

        // Act
        string actual = await _myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrl_ShouldExtractFromAddress()
    {
        // Arrange
        const string input =
            "https://www.example.com/path?u=https%3A%2F%2Fwww.target.com%2Fp%2Ffae-farm-nintendo-switch-digital%2F-%2FA-89638075";
        const string expectedOutput = "https://www.target.com/p/fae-farm-nintendo-switch-digital/-/A-89638075";

        // Act
        string actual = await _myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrl_ShouldExtractFromReturnAddress()
    {
        // Arrange
        const string input =
            "https://www.example.com/path?return=https%3A%2F%2Fwww.example.com%2Fpath%3Fu%3Dhttps%253A%252F%252Fwww.target.com%252Fp%252Ffae-farm-nintendo-switch-digital%252F-%252FA-89638075";
        const string expectedOutput = "https://www.target.com/p/fae-farm-nintendo-switch-digital/-/A-89638075";

        // Act
        string actual = await _myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrl_ShouldHandleRelativeRedirectUrl()
    {
        // Arrange
        const string input = "https://www.example.com/initial";
        const string relativeRedirect = "/redirected";
        const string expectedOutput = "https://www.example.com/redirected";

        HttpClientHandlerStub handler = new((request, cancellationToken) =>
        {
            cancellationToken.Should().NotBeNull();
            cancellationToken.IsCancellationRequested.Should().BeFalse();
            if (request.RequestUri?.ToString() == input)
            {
                return new HttpResponseMessage(HttpStatusCode.Redirect)
                {
                    Headers = { Location = new Uri(relativeRedirect, UriKind.Relative) }
                };
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                RequestMessage = request
            };
        });

        HttpClient httpClient = new(handler);
        ILogger<MyCleaner> logger = Substitute.For<ILogger<MyCleaner>>();
        MyCleaner myCleaner = new(logger, httpClient);

        // Act
        string actual = await myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrl_ShouldExtractAndRemoveQueryParameters()
    {
        // Arrange
        const string input = "https://www.example.com/path?u=https%3A%2F%2Fwww.example.com%2Ffinal%3Fquery%3Dparam";
        const string expectedOutput = "https://www.example.com/final";

        // Act
        string actual = await _myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrl_ShouldFollowRedirectsAndRemoveQueryParameters()
    {
        // Arrange
        const string input = "https://www.example.com/initial";
        const string redirectUrl = "https://www.example.com/redirected?query=param";
        const string expectedOutput = "https://www.example.com/redirected";

        HttpClientHandlerStub handler = new((request, cancellationToken) =>
        {
            cancellationToken.Should().NotBeNull();
            cancellationToken.IsCancellationRequested.Should().BeFalse();
            if (request.RequestUri?.ToString() == input)
            {
                return new HttpResponseMessage(HttpStatusCode.Redirect)
                {
                    Headers = { Location = new Uri(redirectUrl) }
                };
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                RequestMessage = request
            };
        });

        HttpClient httpClient = new(handler);
        ILogger<MyCleaner> logger = Substitute.For<ILogger<MyCleaner>>();
        MyCleaner myCleaner = new(logger, httpClient);

        // Act
        string actual = await myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrl_ShouldReturnLeftPartOfPath_ForAmazonUrlWithoutSpecificSegments()
    {
        // Arrange
        const string input = "https://www.amazon.com/some/other/path";
        const string expectedOutput = "https://www.amazon.com/some/other/path";

        // Act
        string actual = await _myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrl_ShouldReturnLeftPartOfPath_ForNonAmazonUrl()
    {
        // Arrange
        const string input = "https://www.example.com/path/to/resource";
        const string expectedOutput = "https://www.example.com/path/to/resource";

        // Act
        string actual = await _myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrl_ShouldReturnOriginalUrl_WhenFinalUrlIsNull()
    {
        // Arrange
        const string input =
            "https://www.example.com/path?return=https%3A%2F%2Fwww.example.com%2Fpath%3Fotherparam%3Dvalue";
        const string expectedOutput = "https://www.example.com/path";

        // Act
        string actual = await _myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrl_ShouldReturnOriginalUrl_WhenReturnParameterDoesNotContainU()
    {
        // Arrange
        const string input =
            "https://www.example.com/path?return=https%3A%2F%2Fwww.example.com%2Fpath%3Fotherparam%3Dvalue";
        const string expectedOutput = "https://www.example.com/path";

        // Act
        string actual = await _myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrl_ShouldHandleRedirect_WhenLocationHeaderIsNotNull()
    {
        // Arrange
        const string input = "https://www.example.com/initial";
        const string redirectUrl = "https://www.example.com/redirected";
        const string expectedOutput = "https://www.example.com/redirected";

        HttpClientHandlerStub handler = new((request, cancellationToken) =>
        {
            cancellationToken.Should().NotBeNull();
            cancellationToken.IsCancellationRequested.Should().BeFalse();
            if (request.RequestUri?.ToString() == input)
            {
                return new HttpResponseMessage(HttpStatusCode.Redirect)
                {
                    Headers = { Location = new Uri(redirectUrl) }
                };
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                RequestMessage = request
            };
        });

        HttpClient httpClient = new(handler);
        ILogger<MyCleaner> logger = Substitute.For<ILogger<MyCleaner>>();
        MyCleaner myCleaner = new(logger, httpClient);

        // Act
        string actual = await myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrl_ShouldHandleRedirect_WhenLocationHeaderIsNull_WithRedirectLimit()
    {
        // Arrange
        const string input = "https://www.example.com/initial";
        const string expectedOutput = "https://www.example.com/initial";
        int redirectCount = 0;

        HttpClientHandlerStub handler = new((request, cancellationToken) =>
        {
            cancellationToken.Should().NotBeNull();
            cancellationToken.IsCancellationRequested.Should().BeFalse();
            if (request.RequestUri?.ToString() == input && redirectCount < 1)
            {
                redirectCount++;
                return new HttpResponseMessage(HttpStatusCode.Redirect)
                {
                    Headers = { Location = null }
                };
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                RequestMessage = request
            };
        });

        HttpClient httpClient = new(handler);
        ILogger<MyCleaner> logger = Substitute.For<ILogger<MyCleaner>>();
        MyCleaner myCleaner = new(logger, httpClient);

        // Act
        string actual = await myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrl_ShouldReturnRequestUri_WhenRequestMessageAndRequestUriAreNotNull()
    {
        // Arrange
        const string input = "https://www.example.com/initial";
        const string expectedOutput = "https://www.example.com/final";

        HttpClientHandlerStub handler = new((request, cancellationToken) =>
        {
            cancellationToken.Should().NotBeNull();
            cancellationToken.IsCancellationRequested.Should().BeFalse();
            if (request.RequestUri?.ToString() == input)
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://www.example.com/final")
                };
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                RequestMessage = request
            };
        });

        HttpClient httpClient = new(handler);
        ILogger<MyCleaner> logger = Substitute.For<ILogger<MyCleaner>>();
        MyCleaner myCleaner = new(logger, httpClient);

        // Act
        string actual = await myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrl_ShouldReturnNull_WhenRequestMessageIsNull()
    {
        // Arrange
        const string input = "https://www.example.com/initial";
        const string expectedOutput = null;

        HttpClientHandlerStub handler = new((request, cancellationToken) =>
        {
            cancellationToken.Should().NotBeNull();
            cancellationToken.IsCancellationRequested.Should().BeFalse();
            if (request.RequestUri?.ToString() == input)
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = null
                };
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                RequestMessage = request
            };
        });

        HttpClient httpClient = new(handler);
        ILogger<MyCleaner> logger = Substitute.For<ILogger<MyCleaner>>();
        MyCleaner myCleaner = new(logger, httpClient);

        // Act
        string actual = await myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrl_ShouldReturnNull_WhenRequestUriIsNull()
    {
        // Arrange
        const string input = "https://www.example.com/initial";
        const string expectedOutput = null;

        HttpClientHandlerStub handler = new((request, cancellationToken) =>
        {
            cancellationToken.Should().NotBeNull();
            cancellationToken.IsCancellationRequested.Should().BeFalse();
            if (request.RequestUri?.ToString() == input)
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = new HttpRequestMessage(HttpMethod.Get, (Uri)null)
                };
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                RequestMessage = request
            };
        });

        HttpClient httpClient = new(handler);
        ILogger<MyCleaner> logger = Substitute.For<ILogger<MyCleaner>>();
        MyCleaner myCleaner = new(logger, httpClient);

        // Act
        string actual = await myCleaner.CleanUrlAsync(input);

        // Assert
        actual.Should().Be(expectedOutput);
    }

    [Fact]
    public async Task CleanUrlAsync_ShouldLogErrorAndReturnExtractedUrl_OnExceptionInFollowRedirectsAsync()
    {
        // Arrange
        const string inputUrl = "https://www.example.com/initial";
        const string redirectUrl = "https://www.example.com/redirected";
        const string expectedOutput = "https://www.example.com/extracted";

        HttpClientHandlerStub handler = new((request, cancellationToken) =>
        {
            cancellationToken.Should().NotBeNull();
            cancellationToken.IsCancellationRequested.Should().BeFalse();
            if (request.RequestUri?.ToString() == inputUrl)
            {
                return new HttpResponseMessage(HttpStatusCode.Redirect)
                {
                    Headers = { Location = new Uri(redirectUrl) }
                };
            }

            throw new HttpRequestException("Test exception");
        });

        HttpClient httpClient = new(handler);
        ILogger<MyCleaner> logger = Substitute.For<ILogger<MyCleaner>>();
        MyCleaner myCleaner = new(logger, httpClient);

        // Act
        string actual = await myCleaner.CleanUrlAsync(inputUrl);

        // Assert
        actual.Should().Be(expectedOutput);
        logger.Received().LogError(
            Arg.Is<HttpRequestException>(ex => ex.Message == "Test exception"),
            "Error processing URL: {Url}",
            inputUrl
        );
    }

    [Fact]
    public async Task CleanUrlAsync_ShouldReturnExtractedUrl_WhenRedirectUrlIsInvalid()
    {
        // Arrange
        const string inputUrl = "https://www.example.com/initial";
        const string invalidRedirectUrl = "invalid-url";
        const string expectedOutput = "https://www.example.com/invalid-url";

        HttpClientHandlerStub handler = new((request, cancellationToken) =>
        {
            cancellationToken.Should().NotBeNull();
            cancellationToken.IsCancellationRequested.Should().BeFalse();
            if (request.RequestUri?.ToString() == inputUrl)
            {
                return new HttpResponseMessage(HttpStatusCode.Redirect)
                {
                    Headers = { Location = new Uri(invalidRedirectUrl, UriKind.RelativeOrAbsolute) }
                };
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                RequestMessage = request
            };
        });

        HttpClient httpClient = new(handler);
        ILogger<MyCleaner> logger = Substitute.For<ILogger<MyCleaner>>();
        MyCleaner myCleaner = new(logger, httpClient);

        // Act
        string actual = await myCleaner.CleanUrlAsync(inputUrl);

        // Assert
        actual.Should().Be(expectedOutput);
        logger.Received().LogError(
            Arg.Any<Exception>(),
            "Error processing URL: {Url}",
            inputUrl
        );
    }

}