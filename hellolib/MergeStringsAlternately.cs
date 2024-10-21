using System.Text;

namespace hellolib;

public class MergeStringsAlternately(ILogger<MergeStringsAlternately> logger)
{
    public string MergeAlternately(string word1, string word2)
    {
        StringBuilder result = new();
        int length1 = word1.Length;
        int length2 = word2.Length;
        int minLength = Math.Min(length1, length2);

        // Merge characters from both strings
        for (int i = 0; i < minLength; i++)
        {
            result.Append(word1[i]);
            result.Append(word2[i]);
        }

        // Append remaining characters from the longer string
        if (length1 > minLength)
        {
            result.Append(word1.AsSpan(minLength));
        }
        else if (length2 > minLength)
        {
            result.Append(word2.AsSpan(minLength));
        }
        logger.LogInformation("Executed {method} for inputs of size {m} and {n}", nameof(MergeAlternately), word1.Length, word2.Length);
        return result.ToString();
    }
}
