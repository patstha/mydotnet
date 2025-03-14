using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

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

    // Add method tests
    [Fact]
    public void Add_NewKey_Should_Add_Key()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        dictionary.Add("key21", "value21");
        
        Assert.Equal("value21", dictionary["key21"]);
    }

    [Fact]
    public void Add_DuplicateKey_Should_Throw()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        Assert.Throws<ArgumentException>(() => dictionary.Add("key1", "value21"));    
    }

    // Add KeyValuePair tests
    [Fact]
    public void Add_KeyValuePair_Should_Add_Entry()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        KeyValuePair<string, string> kvp = new("key21", "value21");
        
        ((ICollection<KeyValuePair<string, string>>)dictionary).Add(kvp);
        
        Assert.Equal("value21", dictionary["key21"]);
    }

    // ContainsKey tests
    [Fact]
    public void ContainsKey_Should_Return_True()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool actual = dictionary.ContainsKey("key1");
        
        Assert.True(actual);
    }

    [Fact]
    public void ContainsKey_Should_Return_False()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool actual = dictionary.ContainsKey("key21");
        
        Assert.False(actual);
    }

    // ContainsValue tests
    [Fact]
    public void ContainsValue_Should_Return_True()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool actual = dictionary.ContainsValue("value1");
        
        Assert.True(actual);
    }

    [Fact]
    public void ContainsValue_Should_Return_False()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool actual = dictionary.ContainsValue("value21");
        
        Assert.False(actual);
    }

    // Contains KeyValuePair tests
    [Fact]
    public void Contains_KeyValuePair_Should_Return_True()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        KeyValuePair<string, string> kvp = new("key1", "value1");
        
        bool actual = ((ICollection<KeyValuePair<string, string>>)dictionary).Contains(kvp);
        
        Assert.True(actual);
    }

    [Fact]
    public void Contains_KeyValuePair_Should_Return_False_Wrong_Key()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        KeyValuePair<string, string> kvp = new("key21", "value1");
        
        bool actual = ((ICollection<KeyValuePair<string, string>>)dictionary).Contains(kvp);
        
        Assert.False(actual);
    }

    [Fact]
    public void Contains_KeyValuePair_Should_Return_False_Wrong_Value()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        KeyValuePair<string, string> kvp = new("key1", "value21");
        
        bool actual = ((ICollection<KeyValuePair<string, string>>)dictionary).Contains(kvp);
        
        Assert.False(actual);
    }

    // Indexer tests
    [Fact]
    public void Indexer_Get_Should_Return_Value()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        string value = dictionary["key1"];
        
        Assert.Equal("value1", value);
    }

    [Fact]
    public void Indexer_Get_NonExistingKey_Should_Throw()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        
        Assert.Throws<KeyNotFoundException>(() => _ = dictionary["key21"]);
    }

    [Fact]
    public void Indexer_Set_Should_Update_Value()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        dictionary["key1"] = "newValue";
        
        Assert.Equal("newValue", dictionary["key1"]);
    }

    [Fact]
    public void Indexer_Set_NonExistingKey_Should_Add_Key()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        dictionary["key21"] = "value21";
        
        Assert.Equal("value21", dictionary["key21"]);
    }

    // TryGetValue tests
    [Fact]
    public void TryGetValue_ExistingKey_Should_Return_True_And_Value()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool success = dictionary.TryGetValue("key1", out string value);
        
        Assert.True(success);
        Assert.Equal("value1", value);
    }

    [Fact]
    public void TryGetValue_NonExistingKey_Should_Return_False()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool success = dictionary.TryGetValue("key21", out string value);
        
        Assert.False(success);
        Assert.Null(value);
    }

    // Remove key tests
    [Fact]
    public void Remove_ExistingKey_Should_Return_True()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool result = dictionary.Remove("key1");
        
        Assert.True(result);
        Assert.False(dictionary.ContainsKey("key1"));
    }

    [Fact]
    public void Remove_NonExistingKey_Should_Return_False()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool result = dictionary.Remove("key21");
        
        Assert.False(result);
    }

    // Remove KeyValuePair tests
    [Fact]
    public void Remove_KeyValuePair_Should_Return_True()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        KeyValuePair<string, string> kvp = new("key1", "value1");
        
        bool result = ((ICollection<KeyValuePair<string, string>>)dictionary).Remove(kvp);
        
        Assert.True(result);
        Assert.False(dictionary.ContainsKey("key1"));
    }

    [Fact]
    public void Remove_KeyValuePair_WrongValue_Should_Return_False()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        KeyValuePair<string, string> kvp = new("key1", "wrongValue");
        
        bool result = ((ICollection<KeyValuePair<string, string>>)dictionary).Remove(kvp);
        
        Assert.False(result);
        Assert.True(dictionary.ContainsKey("key1"));
    }

    // Clear tests
    [Fact]
    public void Clear_Should_Remove_All_Items()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        dictionary.Clear();
        
        Assert.Empty(dictionary);
    }

    // Count tests
    [Fact]
    public void Count_Should_Return_Number_Of_Items()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        
        Assert.Equal(20, dictionary.Count);
        
        dictionary.Add("key21", "value21");
        Assert.Equal(21, dictionary.Count);
        
        dictionary.Remove("key1");
        Assert.Equal(20, dictionary.Count);
    }

    // Keys tests
    [Fact]
    public void Keys_Should_Return_All_Keys()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        ICollection<string> keys = dictionary.Keys;
        
        Assert.Equal(20, keys.Count);
        Assert.Contains("key1", keys);
        Assert.Contains("key20", keys);
        Assert.DoesNotContain("key21", keys);
    }

    // Values tests
    [Fact]
    public void Values_Should_Return_All_Values()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        ICollection<string> values = dictionary.Values;
        
        Assert.Equal(20, values.Count);
        Assert.Contains("value1", values);
        Assert.Contains("value20", values);
        Assert.DoesNotContain("value21", values);
    }

    // Enumeration tests
    [Fact]
    public void Enumeration_Should_Return_All_Items()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        int count = 0;
        
        foreach (KeyValuePair<string, string> kvp in dictionary)
        {
            Assert.Equal($"value{kvp.Key.Substring(3)}", kvp.Value);
            count++;
        }
        
        Assert.Equal(20, count);
    }
    
    // CopyTo tests
    [Fact]
    public void CopyTo_Should_Copy_All_Items()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        KeyValuePair<string, string>[] array = new KeyValuePair<string, string>[20];
        
        ((ICollection<KeyValuePair<string, string>>)dictionary).CopyTo(array, 0);
        
        foreach (KeyValuePair<string, string> kvp in array)
        {
            Assert.Equal($"value{kvp.Key.Substring(3)}", kvp.Value);
        }
    }

    // EnsureCapacity tests
    [Fact]
    public void EnsureCapacity_Should_Return_New_Capacity()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        int capacity = dictionary.EnsureCapacity(100);
        
        Assert.True(capacity >= 100);
    }

    // TrimExcess tests
    [Fact]
    public void TrimExcess_Should_Not_Throw()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        
        dictionary.TrimExcess();
        
        Assert.Equal(20, dictionary.Count);
    }

    [Fact]
    public void TrimExcess_WithParameter_Should_Not_Throw()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        
        dictionary.TrimExcess(15);
        
        Assert.Equal(20, dictionary.Count);
    }

    // GetAlternateLookup tests (.NET 9 feature)
    [Fact]
    public void GetAlternateLookup_CaseInsensitive_Should_Return_Value()
    {
        Dictionary<string, string> dictionary = new(StringComparer.Ordinal)
        {
            { "TestKey", "TestValue" }
        };
        
        string result = dictionary.GetAlternateLookup("testkey", StringComparer.OrdinalIgnoreCase);
        
        Assert.Equal("TestValue", result);
    }

    [Fact]
    public void GetAlternateLookup_NonExistingKey_Should_Throw()
    {
        Dictionary<string, string> dictionary = new(StringComparer.Ordinal)
        {
            { "TestKey", "TestValue" }
        };
        
        Assert.Throws<KeyNotFoundException>(() => 
            dictionary.GetAlternateLookup("NotExistingKey", StringComparer.OrdinalIgnoreCase));
    }

    // TryGetAlternateLookup tests (.NET 9 feature)
    [Fact]
    public void TryGetAlternateLookup_CaseInsensitive_Should_Return_True_And_Value()
    {
        Dictionary<string, string> dictionary = new(StringComparer.Ordinal)
        {
            { "TestKey", "TestValue" }
        };
        
        bool success = dictionary.TryGetAlternateLookup("testkey", StringComparer.OrdinalIgnoreCase, out string value);
        
        Assert.True(success);
        Assert.Equal("TestValue", value);
    }

    [Fact]
    public void TryGetAlternateLookup_NonExistingKey_Should_Return_False()
    {
        Dictionary<string, string> dictionary = new(StringComparer.Ordinal)
        {
            { "TestKey", "TestValue" }
        };
        
        bool success = dictionary.TryGetAlternateLookup("NotExistingKey", StringComparer.OrdinalIgnoreCase, out string value);
        
        Assert.False(success);
        Assert.Null(value);
    }

    [Fact]
    public void TryGetAlternateLookup_DifferentComparerNoMatch_Should_Return_False()
    {
        Dictionary<string, string> dictionary = new(StringComparer.OrdinalIgnoreCase)
        {
            { "TestKey", "TestValue" }
        };
        
        // Using a different comparer that wouldn't match
        bool success = dictionary.TryGetAlternateLookup("TESTKEY", new CustomStringComparer(), out string value);
        
        Assert.False(success);
        Assert.Null(value);
    }

    // IsReadOnly tests
    [Fact]
    public void IsReadOnly_Should_Return_False()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool isReadOnly = ((ICollection<KeyValuePair<string, string>>)dictionary).IsReadOnly;
        
        Assert.False(isReadOnly);
    }
}

// Helper class for TryGetAlternateLookup with custom comparer test
public class CustomStringComparer : IEqualityComparer<string>
{
    public bool Equals(string x, string y)
    {
        // Only match if strings are exactly the same (case-sensitive) and start with 'X'
        return x != null && y != null && x == y && x.StartsWith("X");
    }

    public int GetHashCode(string obj)
    {
        return obj?.GetHashCode() ?? 0;
    }
}