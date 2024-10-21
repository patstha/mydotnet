namespace hellolib;

public class MergeStringsAlternately
{
    public string MergeAlternately(string word1, string word2)
    {
        int length1 = word1.Length;
        int length2 = word2.Length;
        if (length1 > length2)
        {
            //string result = "";
            //for (int i = 0; i < length2; i++)
            //{
            //    result += word1[i] + word2[i];
            //}
            //for (int i = length2; i < length1; i++)
            //{
            //    result += word1[i];
            //}
            return concatanate(word1, word2);
        } else
        {
            return concatanate(word2, word1);
        }
    }

    private string concatanate(string word1, string word2)
    {
        string result = "";
        for (int i = 0; i < word2.Length; i++)
        {
            result += word1[i] + word2[i];
        }
        for (int i = word2.Length; i < word1.Length; i++)
        {
            result += word1[i];
        }
        return result;
    }
}
