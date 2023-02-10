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
        dynamic? input = JsonConvert.DeserializeObject(json);
        return "";
    }
}