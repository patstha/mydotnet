using Newtonsoft.Json;

namespace SalesforceMapper;

public static class Mapper
{
    public static int AddTwoIntegers(int first, int second)
    {
        return first + second;
    }

    public static string ManipulateJsonString(string json)
    {
        if (string.IsNullOrWhiteSpace(json)) { return "";  }
        MinimalInput.MinimalInput? input = JsonConvert.DeserializeObject<MinimalInput.MinimalInput>(json);
        string test = JsonConvert.SerializeObject(input);

        MinimalOutput.MinimalOutput output = new()
        {
            Preferences =
            {
                new()
                {
                    PrefCode = nameof(input.ContactEmailC),

                }
            }
        };

        return test;
    }
}