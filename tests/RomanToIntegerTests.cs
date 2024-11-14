namespace tests;

public class RomanToIntegerTests
{
    [Fact]
    public void RomanToInt_ShouldReturn1()
    {
        // arrange 
        const string s = "III";
        const int expected = 3;

        // act 
        int actual = RomanToInteger.RomanToInt(s);

        // assert 
        actual.Should().Be(expected);
    }

    [Fact]
    public void RomanToInt_ShouldReturn2()
    {
        // arrange 
        const string s = "LVIII";
        const int expected = 58;

        // act 
        int actual = RomanToInteger.RomanToInt(s);

        // assert 
        actual.Should().Be(expected);
    }

    [Fact]
    public void RomanToInt_ShouldReturn3()
    {
        // arrange 
        const string s = "MCMXCIV";
        const int expected = 1994;

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
        const string s = "MCMXCIV";

        // act 
        bool actual = RomanToInteger.IsValidRomanNumeral(s);

        // assert 
        actual.Should().BeTrue();
    }

    [Fact]
    public void IsValidRomanNumeral_ShouldReturnFalse_ForInvalidNumeral()
    {
        // arrange 
        const string s = "IIII";

        // act 
        bool actual = RomanToInteger.IsValidRomanNumeral(s);

        // assert 
        actual.Should().BeFalse();
    }

    [Fact]
    public void IsValidRomanNumeral_ShouldReturnFalse_ForInvalidCharacters()
    {
        // arrange 
        const string s = "ABCD";

        // act 
        bool actual = RomanToInteger.IsValidRomanNumeral(s);

        // assert 
        actual.Should().BeFalse();
    }

    [Fact]
    public void IsValidRomanNumeral_ShouldReturnFalse_ForInvalidSubtraction()
    {
        // arrange 
        const string s = "IC";

        // act 
        bool actual = RomanToInteger.IsValidRomanNumeral(s);

        // assert 
        actual.Should().BeFalse();
    }

    [Fact]
    public void IsValidRomanNumeral_ShouldReturnTrue_ForSingleCharacter()
    {
        // arrange 
        const string s = "V";

        // act 
        bool actual = RomanToInteger.IsValidRomanNumeral(s);

        // assert 
        actual.Should().BeTrue();
    }

    [Fact]
    public void IsValidRomanNumeral_ShouldReturnTrue_ForCombination()
    {
        // arrange 
        const string s = "CDXLIV";

        // act 
        bool actual = RomanToInteger.IsValidRomanNumeral(s);

        // assert 
        actual.Should().BeTrue();
    }

    [Fact]
    public void IsValidRomanNumeral_ShouldReturnTrue_ForCombinationVI()
    {
        // arrange 
        const string s = "VI";

        // act 
        bool actual = RomanToInteger.IsValidRomanNumeral(s);

        // assert 
        actual.Should().BeTrue();
    }

    [Fact]
    public void IsValidRomanNumeral_ShouldReturnFalse_ForCombination()
    {
        // arrange 
        const string s = "XD";

        // act 
        bool actual = RomanToInteger.IsValidRomanNumeral(s);

        // assert 
        actual.Should().BeFalse();
    }
    [Fact]
    public void IsValidRomanNumeral_ShouldReturnFalse_ForNullInput()
    {
        // arrange 

        // act 
        bool actual = RomanToInteger.IsValidRomanNumeral(null);

        // assert 
        actual.Should().BeFalse();
    }
    [Fact]
    public void IsValidRomanNumeral_ShouldReturnFalse_ForEmptyString()
    {
        // arrange 
        const string s = "";

        // act 
        bool actual = RomanToInteger.IsValidRomanNumeral(s);

        // assert 
        actual.Should().BeFalse();
    }

    
}
