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

    // Additional tests for IsValidRomanNumeral method
    [Fact]
    public void IsValidRomanNumeral_ShouldReturnTrue_ForValidNumeral()
    {
        // arrange 
        string s = "MCMXCIV";

        // act 
        bool actual = RomanToInteger.IsValidRomanNumeral(s);

        // assert 
        actual.Should().BeTrue();
    }

    [Fact]
    public void IsValidRomanNumeral_ShouldReturnFalse_ForInvalidNumeral()
    {
        // arrange 
        string s = "IIII";

        // act 
        bool actual = RomanToInteger.IsValidRomanNumeral(s);

        // assert 
        actual.Should().BeFalse();
    }

    [Fact]
    public void IsValidRomanNumeral_ShouldReturnFalse_ForInvalidCharacters()
    {
        // arrange 
        string s = "ABCD";

        // act 
        bool actual = RomanToInteger.IsValidRomanNumeral(s);

        // assert 
        actual.Should().BeFalse();
    }

    [Fact]
    public void IsValidRomanNumeral_ShouldReturnFalse_ForInvalidSubtraction()
    {
        // arrange 
        string s = "IC";

        // act 
        bool actual = RomanToInteger.IsValidRomanNumeral(s);

        // assert 
        actual.Should().BeFalse();
    }

    [Fact]
    public void IsValidRomanNumeral_ShouldReturnTrue_ForSingleCharacter()
    {
        // arrange 
        string s = "V";

        // act 
        bool actual = RomanToInteger.IsValidRomanNumeral(s);

        // assert 
        actual.Should().BeTrue();
    }

    [Fact]
    public void IsValidRomanNumeral_ShouldReturnTrue_ForCombination()
    {
        // arrange 
        string s = "CDXLIV";

        // act 
        bool actual = RomanToInteger.IsValidRomanNumeral(s);

        // assert 
        actual.Should().BeTrue();
    }

    [Fact]
    public void IsValidRomanNumeral_ShouldReturnTrue_ForCombinationVI()
    {
        // arrange 
        string s = "VI";

        // act 
        bool actual = RomanToInteger.IsValidRomanNumeral(s);

        // assert 
        actual.Should().BeTrue();
    }

    [Fact]
    public void IsValidRomanNumeral_ShouldReturnFalse_ForCombination()
    {
        // arrange 
        string s = "XD";

        // act 
        bool actual = RomanToInteger.IsValidRomanNumeral(s);

        // assert 
        actual.Should().BeFalse();
    }
}
