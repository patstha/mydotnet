namespace tests;

public class RomanToIntegerTests
{
    [Fact]
    public void RomanToInt_ShouldReturn1()
    {
        // arrange 
        string s = "III";
        int expected = 3;

        // act 
        int actual = RomanToInteger.RomanToInt(s);

        // assert 
        actual.Should().Be(expected);
    }
    [Fact]
    public void RomanToInt_ShouldReturn2()
    {
        // arrange 
        string s = "LVIII";
        int expected = 58;

        // act 
        int actual = RomanToInteger.RomanToInt(s);

        // assert 
        actual.Should().Be(expected);
    }
    [Fact]
    public void RomanToInt_ShouldReturn3()
    {
        // arrange 
        string s = "MCMXCIV";
        int expected = 1994;

        // act 
        int actual = RomanToInteger.RomanToInt(s);

        // assert 
        actual.Should().Be(expected);
    }
    [Fact]
    public void RomanToInt_ShouldReturn_kus1()
    {
        // arrange 
        string s = "XXX";
        int expected = 30;

        // act 
        int actual = RomanToInteger.RomanToInt(s);

        // assert 
        actual.Should().Be(expected);
    }
}
