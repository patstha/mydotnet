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
}
