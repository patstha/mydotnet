namespace tests;

public class MyDictionaryTests
{
    private static Dictionary<string, string> GetTestDictionary()
    {
        Dictionary<string, string> dictionary = new()
        {
            { "key1", "value1" },
            { "key2", "value2" },
            { "key3", "value3" },
            { "key4", "value4" },
            { "key5", "value5" },
            { "key6", "value6" },
            { "key7", "value7" },
            { "key8", "value8" },
            { "key9", "value9" },
            { "key10", "value10" },
            { "key11", "value11" },
            { "key12", "value12" },
            { "key13", "value13" },
            { "key14", "value14" },
            { "key15", "value15" },
            { "key16", "value16" },
            { "key17", "value17" },
            { "key18", "value18" },
            { "key19", "value19" },
            { "key20", "value20" }
        };
        return dictionary;
    }

    [Fact]
    public void Add_NewKey_Should_Add_Key()
    {
        // Arrange
        Dictionary<string, string> dictionary = GetTestDictionary();
        int initialCount = dictionary.Count;
    
        // Act
        dictionary.Add("key21", "value21");
    
        // Assert
        Assert.Equal("value21", dictionary["key21"]);
        Assert.Equal(initialCount + 1, dictionary.Count);
        Assert.True(dictionary.ContainsKey("key21"));
    }

    [Fact]
    public void Add_DuplicateKey_Should_Throw()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        Assert.Throws<ArgumentException>(() => dictionary.Add("key1", "value21"));    
    }

    [Fact]
    public void Contains_Key_Should_Return_True()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool actual = dictionary.ContainsKey("key1");
        Assert.True(actual);
    }

    [Fact]
    public void Contains_Key_Should_Return_False()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool actual = dictionary.ContainsKey("key21");
        Assert.False(actual);
    }

    [Fact]
    public void Contains_Value_Should_Return_True()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool actual = dictionary.ContainsValue("value1");
        Assert.True(actual);
    }

    [Fact]
    public void Contains_Value_Should_Return_False()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool actual = dictionary.ContainsValue("value21");
        Assert.False(actual);
    }

}