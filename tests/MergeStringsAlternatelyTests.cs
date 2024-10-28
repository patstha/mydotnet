namespace tests;
public class MergeStringsAlternatelyTests
{
    private readonly ILogger<MergeStringsAlternately> _logger = Substitute.For<ILogger<MergeStringsAlternately>>();

    [Fact]
    public void MergeAlternately_ShouldReturn1()
    {
        // arrange 
        const string word1 = "abcd";
        const string word2 = "pq";
        const string expected = "apbqcd";

        // act 
        MergeStringsAlternately mergeStringsAlternately = new(_logger);
        string actual = mergeStringsAlternately.MergeAlternately(word1, word2);

        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void MergeAlternately_ShouldMergeEqualLengthStrings()
    {
        // arrange 
        const string word1 = "abc";
        const string word2 = "xyz";
        const string expected = "axbycz";

        // act 
        MergeStringsAlternately mergeStringsAlternately = new(_logger);
        string actual = mergeStringsAlternately.MergeAlternately(word1, word2);

        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void MergeAlternately_ShouldMergeWhenFirstStringIsLonger()
    {
        // arrange 
        const string word1 = "abcd";
        const string word2 = "xy";
        const string expected = "axbycd";

        // act 
        MergeStringsAlternately mergeStringsAlternately = new(_logger);
        string actual = mergeStringsAlternately.MergeAlternately(word1, word2);

        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void MergeAlternately_ShouldMergeWhenSecondStringIsLonger()
    {
        // arrange 
        const string word1 = "ab";
        const string word2 = "wxyz";
        const string expected = "awbxyz";

        // act 
        MergeStringsAlternately mergeStringsAlternately = new(_logger);
        string actual = mergeStringsAlternately.MergeAlternately(word1, word2);

        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void MergeAlternately_ShouldHandleEmptyFirstString()
    {
        // arrange 
        const string word1 = "";
        const string word2 = "xyz";
        const string expected = "xyz";

        // act 
        MergeStringsAlternately mergeStringsAlternately = new(_logger);
        string actual = mergeStringsAlternately.MergeAlternately(word1, word2);

        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void MergeAlternately_ShouldHandleEmptySecondString()
    {
        // arrange 
        const string word1 = "abc";
        const string word2 = "";
        const string expected = "abc";

        // act 
        MergeStringsAlternately mergeStringsAlternately = new(_logger);
        string actual = mergeStringsAlternately.MergeAlternately(word1, word2);

        actual.Should().BeEquivalentTo(expected);
    }
    [Fact]
    public void MergeAlternately_ShouldHandleBothStringsEmpty()
    {
        // arrange 
        const string word1 = "";
        const string word2 = "";
        const string expected = "";

        // act 
        MergeStringsAlternately mergeStringsAlternately = new(_logger);
        string actual = mergeStringsAlternately.MergeAlternately(word1, word2);

        actual.Should().BeEquivalentTo(expected);
    }

}

//You are given two strings word1 and word2.Merge the strings by adding letters in alternating order, starting with word1.If a string is longer than the other, append the additional letters onto the end of the merged string.

//Return the merged string.




//Example 1:

//Input: word1 = "abc", word2 = "pqr"
//Output: "apbqcr"
//Explanation: The merged string will be merged as so:
//word1:  a b   c
//word2:    p q   r
//merged: a p b q c r

//Example 2:

//Input: word1 = "ab", word2 = "pqrs"
//Output: "apbqrs"
//Explanation: Notice that as word2 is longer, "rs" is appended to the end.
//word1:  a b
//word2:    p q   r s
//merged: a p b q   r s

//Example 3:

//Input: word1 = "abcd", word2 = "pq"
//Output: "apbqcd"
//Explanation: Notice that as word1 is longer, "cd" is appended to the end.
//word1:  a b   c d
//word2:    p q
//merged: a p b q c d




//Constraints:

//    1 <= word1.length, word2.length <= 100
//    word1 and word2 consist of lowercase English letters.
