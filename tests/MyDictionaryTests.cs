using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace tests;

public class MyDictionaryTests
{
    private static Dictionary<string, string> GetTestDictionary()
    {
        return new Dictionary<string, string>()
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
    }

    [Fact]
    public void Add_NewKey_Should_Add_Key()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        dictionary.Add("key21", "value21");
        Assert.True(dictionary.ContainsKey("key21"));
        Assert.Equal("value21", dictionary["key21"]);
    }

    [Fact]
    public void Add_DuplicateKey_Should_Throw()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        Assert.Throws<ArgumentException>(() => dictionary.Add("key1", "differentValue"));
    }

    [Fact]
    public void ContainsKey_ExistingKey_Should_Return_True()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        Assert.True(dictionary.ContainsKey("key1"));
    }

    [Fact]
    public void ContainsKey_NonExistingKey_Should_Return_False()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        Assert.False(dictionary.ContainsKey("key21"));
    }

    [Fact]
    public void ContainsValue_ExistingValue_Should_Return_True()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        Assert.True(dictionary.ContainsValue("value1"));
    }

    [Fact]
    public void ContainsValue_NonExistingValue_Should_Return_False()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        Assert.False(dictionary.ContainsValue("value21"));
    }

    // Additional tests will be added below
}