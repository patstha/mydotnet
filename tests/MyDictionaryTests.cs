using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

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
        Dictionary<string, string> dictionary = GetTestDictionary();
        dictionary.Add("key21", "value21");
        Assert.True(dictionary.ContainsKey("key21"));
        Assert.Equal("value21", dictionary["key21"]);
    }

    [Fact]
    public void Add_DuplicateKey_Should_Throw()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        Assert.Throws<ArgumentException>(() => dictionary.Add("key1", "value21"));
    }

    [Fact]
    public void Clear_Should_Remove_All_Elements()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        dictionary.Clear();
        Assert.Empty(dictionary);
        Assert.Equal(0, dictionary.Count);
    }

    [Fact]
    public void ContainsKey_ExistingKey_Should_Return_True()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool actual = dictionary.ContainsKey("key1");
        Assert.True(actual);
    }

    [Fact]
    public void ContainsKey_NonExistingKey_Should_Return_False()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool actual = dictionary.ContainsKey("key21");
        Assert.False(actual);
    }

    [Fact]
    public void ContainsValue_ExistingValue_Should_Return_True()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool actual = dictionary.ContainsValue("value1");
        Assert.True(actual);
    }

    [Fact]
    public void ContainsValue_NonExistingValue_Should_Return_False()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool actual = dictionary.ContainsValue("value21");
        Assert.False(actual);
    }

    [Fact]
    public void CopyTo_Should_Copy_Elements_To_Array()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        KeyValuePair<string, string>array = new KeyValuePair<string, string>[dictionary.Count + 5];
        dictionary.CopyTo(array, 5);

        for (int i = 0; i < dictionary.Count; i++)
        {
            Assert.Equal(dictionary.ElementAt(i), array[i + 5]);
        }
    }

    [Fact]
    public void Remove_ExistingKey_Should_Return_True_And_Remove_Element()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool actual = dictionary.Remove("key1");
        Assert.True(actual);
        Assert.False(dictionary.ContainsKey("key1"));
        Assert.Equal(19, dictionary.Count);
    }

    [Fact]
    public void Remove_NonExistingKey_Should_Return_False()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool actual = dictionary.Remove("key21");
        Assert.False(actual);
        Assert.Equal(20, dictionary.Count);
    }

    [Fact]
    public void TryGetValue_ExistingKey_Should_Return_True_And_Output_Value()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool actual = dictionary.TryGetValue("key1", out string? value);
        Assert.True(actual);
        Assert.Equal("value1", value);
    }

    [Fact]
    public void TryGetValue_NonExistingKey_Should_Return_False_And_Output_Null()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool actual = dictionary.TryGetValue("key21", out string? value);
        Assert.False(actual);
        Assert.Null(value);
    }

    [Fact]
    public void IndexerGet_ExistingKey_Should_Return_Value()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        string value = dictionary["key1"];
        Assert.Equal("value1", value);
    }

    [Fact]
    public void IndexerGet_NonExistingKey_Should_Throw_KeyNotFoundException()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        Assert.Throws<KeyNotFoundException>(() => _ = dictionary["key21"]);
    }

    [Fact]
    public void IndexerSet_ExistingKey_Should_Update_Value()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        dictionary["key1"] = "newValue1";
        Assert.Equal("newValue1", dictionary["key1"]);
    }

    [Fact]
    public void IndexerSet_NewKey_Should_Add_Key_Value_Pair()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        dictionary["key21"] = "value21";
        Assert.True(dictionary.ContainsKey("key21"));
        Assert.Equal("value21", dictionary["key21"]);
        Assert.Equal(21, dictionary.Count);
    }

    [Fact]
    public void Keys_Should_Return_Collection_Of_All_Keys()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        ICollection<string> keys = dictionary.Keys;
        Assert.Equal(dictionary.Count, keys.Count);
        foreach (var key in dictionary.Keys)
        {
            Assert.Contains(key, keys);
        }
    }

    [Fact]
    public void Values_Should_Return_Collection_Of_All_Values()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        ICollection<string> values = dictionary.Values;
        Assert.Equal(dictionary.Count, values.Count);
        foreach (var value in dictionary.Values)
        {
            Assert.Contains(value, values);
        }
    }

    [Fact]
    public void Count_Should_Return_Correct_Number_Of_Elements()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        Assert.Equal(20, dictionary.Count);
        dictionary.Add("key21", "value21");
        Assert.Equal(21, dictionary.Count);
        dictionary.Remove("key1");
        Assert.Equal(20, dictionary.Count);
    }

    [Fact]
    public void GetEnumerator_Should_Iterate_Through_All_Elements()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        int count = 0;
        foreach (KeyValuePair<string, string> pair in dictionary)
        {
            Assert.True(dictionary.ContainsKey(pair.Key));
            Assert.Equal(dictionary[pair.Key], pair.Value);
            count++;
        }
        Assert.Equal(dictionary.Count, count);
    }

    [Fact]
    public void GetAlternateLookup_UniqueAlternateKey_Should_Return_ReadOnlyDictionary()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        var alternateLookup = dictionary.GetAlternateLookup(kvp => kvp.Value); // Use value as alternate key

        Assert.NotNull(alternateLookup);
        Assert.IsAssignableFrom<IReadOnlyDictionary<string, string>>(alternateLookup);
        Assert.Equal(dictionary.Count, alternateLookup.Count);

        foreach (var kvp in dictionary)
        {
            Assert.True(alternateLookup.ContainsKey(kvp.Value));
            Assert.Equal(kvp.Key, alternateLookup[kvp.Value]);
        }
    }

    [Fact]
    public void GetAlternateLookup_DuplicateAlternateKey_Should_Throw_ArgumentException()
    {
        Dictionary<string, string> dictionary = new()
        {
            { "key1", "value1" },
            { "key2", "value1" } // Duplicate value
        };

        Assert.Throws<ArgumentException>(() => dictionary.GetAlternateLookup(kvp => kvp.Value));
    }

    [Fact]
    public void TryGetAlternateLookup_UniqueAlternateKey_Should_Return_True_And_ReadOnlyDictionary()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool success = dictionary.TryGetAlternateLookup(kvp => kvp.Value, out var alternateLookup);

        Assert.True(success);
        Assert.NotNull(alternateLookup);
        Assert.IsAssignableFrom<IReadOnlyDictionary<string, string>>(alternateLookup);
        Assert.Equal(dictionary.Count, alternateLookup.Count);

        foreach (var kvp in dictionary)
        {
            Assert.True(alternateLookup.ContainsKey(kvp.Value));
            Assert.Equal(kvp.Key, alternateLookup[kvp.Value]);
        }
    }

    [Fact]
    public void TryGetAlternateLookup_DuplicateAlternateKey_Should_Return_False_And_Null_Dictionary()
    {
        Dictionary<string, string> dictionary = new()
        {
            { "key1", "value1" },
            { "key2", "value1" } // Duplicate value
        };

        bool success = dictionary.TryGetAlternateLookup(kvp => kvp.Value, out var alternateLookup);

        Assert.False(success);
        Assert.Null(alternateLookup);
    }

    [Fact]
    public void TryGetAlternateLookup_EmptyDictionary_Should_Return_True_And_Empty_Dictionary()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        bool success = dictionary.TryGetAlternateLookup(kvp => kvp.Value, out var alternateLookup);

        Assert.True(success);
        Assert.NotNull(alternateLookup);
        Assert.Empty(alternateLookup);
    }

    [Fact]
    public void GetAlternateLookup_EmptyDictionary_Should_Return_Empty_Dictionary()
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        var alternateLookup = dictionary.GetAlternateLookup(kvp => kvp.Value);

        Assert.NotNull(alternateLookup);
        Assert.Empty(alternateLookup);
    }
}