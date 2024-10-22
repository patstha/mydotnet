using HelloLib;

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
    public void RomanToInt_ShouldReturn_kus0()
    {
        // arrange 
        string s = "I";
        int expected = 1;

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
    [Fact]
    public void RomanToInt_ShouldReturn_kus2()
    {
        // arrange 
        string s = "IV";
        int expected = 4;

        // act 
        int actual = RomanToInteger.RomanToInt(s);

        // assert 
        actual.Should().Be(expected);
    }
    [Fact]
    public void RomanToInt_ShouldReturn_kus3()
    {
        // arrange 
        string s = "XIV";
        int expected = 14;

        // act 
        int actual = RomanToInteger.RomanToInt(s);

        // assert 
        actual.Should().Be(expected);
    }
    [Fact]
    public void RomanToInt_ShouldReturn_kus4()
    {
        // arrange 
        string s = "XCIX";
        int expected = 99;

        // act 
        int actual = RomanToInteger.RomanToInt(s);

        // assert 
        actual.Should().Be(expected);
    }
    [Fact]
    public void RomanToInt_ShouldReturn_kus5()
    {
        // arrange 
        string s = "XCIII";
        int expected = 93;

        // act 
        int actual = RomanToInteger.RomanToInt(s);

        // assert 
        actual.Should().Be(expected);
    }
    [Fact]
    public void RomanToInt_ShouldReturn_kus6()
    {
        // arrange 
        string s = "XCVI";
        int expected = 96;

        // act 
        int actual = RomanToInteger.RomanToInt(s);

        // assert 
        actual.Should().Be(expected);
    }
    [Fact]
    public void RomanToInt_ShouldReturn_kus7()
    {
        // arrange 
        string s = "LXIX";
        int expected = 69;

        // act 
        int actual = RomanToInteger.RomanToInt(s);

        // assert 
        actual.Should().Be(expected);
    }
}
