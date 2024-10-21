namespace hellolib;

public class MergeStringsAlternately
{
    public string MergeAlternately(string word1, string word2)
    {
        return Concatenate(word1, word2);
    }

    private string Concatenate(string word1, string word2)
    {
        string result = "";
        int length1 = word1.Length;
        int length2 = word2.Length;
        int minLength = Math.Min(length1, length2);

        for (int i = 0; i < minLength; i++)
        {
            result += word1[i].ToString() + word2[i].ToString();
        }
        for (int i = minLength; i < length1; i++)
        {
            result += word1[i];
        }
        for (int i = minLength; i < length2; i++)
        {
            result += word2[i];
        }
        return result;
    }
}
