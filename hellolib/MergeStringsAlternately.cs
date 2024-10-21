using System.Text;

namespace hellolib;

public class MergeStringsAlternately
{
    public string MergeAlternately(string word1, string word2)
    {
        StringBuilder result = new StringBuilder();
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
            result.Append(word1.Substring(minLength));
        }
        else if (length2 > minLength)
        {
            result.Append(word2.Substring(minLength));
        }

        return result.ToString();
    }
}
