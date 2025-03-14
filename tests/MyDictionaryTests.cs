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

    [Fact]
    public void AddKeyValuePair_NewKey_Should_Add_Key()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        KeyValuePair<string, string> kvp = new("key21", "value21");
        dictionary.Add(kvp);

        Assert.Equal("value21", dictionary["key21"]);
    }

    [Fact]
    public void AddKeyValuePair_DuplicateKey_Should_Throw()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        KeyValuePair<string, string> kvp = new("key1", "value21");
        Assert.Throws<ArgumentException>(() => dictionary.Add(kvp));
    }

    [Fact]
    public void Clear_Should_Remove_All_Elements()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        dictionary.Clear();
        
        Assert.Empty(dictionary);
    }

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

    [Fact]
    public void Contains_Should_Return_True_For_Existing_KeyValuePair()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        KeyValuePair<string, string> kvp = new("key1", "value1");
        bool actual = dictionary.Contains(kvp);
        Assert.True(actual);
    }

    [Fact]
    public void Contains_Should_Return_False_For_NonExisting_KeyValuePair()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        KeyValuePair<string, string> kvp = new("key1", "wrong-value");
        bool actual = dictionary.Contains(kvp);
        Assert.False(actual);
    }

    [Fact]
    public void CopyTo_Should_Copy_Elements_To_Array()
    {
        Dictionary<string, string> dictionary = new()
        {
            { "key1", "value1" },
            { "key2", "value2" }
        };
        
        KeyValuePair<string, string>[] array = new KeyValuePair<string, string>[3];
        dictionary.CopyTo(array, 1);
        
        Assert.Equal(default, array[0]);
        Assert.Contains(new KeyValuePair<string, string>("key1", "value1"), array);
        Assert.Contains(new KeyValuePair<string, string>("key2", "value2"), array);
    }

    [Fact]
    public void Count_Should_Return_Number_Of_Elements()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        Assert.Equal(20, dictionary.Count);
    }

    [Fact]
    public void GetEnumerator_Should_Enumerate_All_Elements()
    {
        Dictionary<string, string> dictionary = new()
        {
            { "key1", "value1" },
            { "key2", "value2" }
        };
        
        int count = 0;
        foreach (var kvp in dictionary)
        {
            count++;
            Assert.Equal($"value{kvp.Key[3]}", kvp.Value);
        }
        
        Assert.Equal(2, count);
    }

    [Fact]
    public void Indexer_Get_Should_Return_Value()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        Assert.Equal("value1", dictionary["key1"]);
    }

    [Fact]
    public void Indexer_Get_Should_Throw_When_Key_Not_Found()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        Assert.Throws<KeyNotFoundException>(() => _ = dictionary["key21"]);
    }

    [Fact]
    public void Indexer_Set_Should_Add_New_Key()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        dictionary["key21"] = "value21";
        Assert.Equal("value21", dictionary["key21"]);
    }

    [Fact]
    public void Indexer_Set_Should_Update_Existing_Key()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        dictionary["key1"] = "updated-value";
        Assert.Equal("updated-value", dictionary["key1"]);
    }

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

    [Fact]
    public void Remove_Should_Return_True_And_Remove_Element()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool result = dictionary.Remove("key1");
        
        Assert.True(result);
        Assert.Equal(19, dictionary.Count);
        Assert.False(dictionary.ContainsKey("key1"));
    }

    [Fact]
    public void Remove_Should_Return_False_When_Key_Not_Found()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool result = dictionary.Remove("key21");
        
        Assert.False(result);
        Assert.Equal(20, dictionary.Count);
    }

    [Fact]
    public void Remove_With_KeyValuePair_Should_Return_True_And_Remove_Element()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        KeyValuePair<string, string> kvp = new("key1", "value1");
        bool result = dictionary.Remove(kvp);
        
        Assert.True(result);
        Assert.Equal(19, dictionary.Count);
        Assert.False(dictionary.ContainsKey("key1"));
    }

    [Fact]
    public void Remove_With_KeyValuePair_Should_Return_False_When_KeyValuePair_Not_Found()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        KeyValuePair<string, string> kvp = new("key1", "wrong-value");
        bool result = dictionary.Remove(kvp);
        
        Assert.False(result);
        Assert.Equal(20, dictionary.Count);
    }

    [Fact]
    public void TryAdd_Should_Return_True_And_Add_Element_When_Key_Not_Exists()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool result = dictionary.TryAdd("key21", "value21");
        
        Assert.True(result);
        Assert.Equal(21, dictionary.Count);
        Assert.Equal("value21", dictionary["key21"]);
    }

    [Fact]
    public void TryAdd_Should_Return_False_When_Key_Already_Exists()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool result = dictionary.TryAdd("key1", "new-value");
        
        Assert.False(result);
        Assert.Equal(20, dictionary.Count);
        Assert.Equal("value1", dictionary["key1"]);
    }

    [Fact]
    public void TryGetValue_Should_Return_True_And_Get_Value_When_Key_Exists()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool result = dictionary.TryGetValue("key1", out string value);
        
        Assert.True(result);
        Assert.Equal("value1", value);
    }

    [Fact]
    public void TryGetValue_Should_Return_False_When_Key_Not_Found()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        bool result = dictionary.TryGetValue("key21", out string value);
        
        Assert.False(result);
        Assert.Equal(default, value);
    }

    [Fact]
    public void EnsureCapacity_Should_Return_New_Capacity()
    {
        Dictionary<string, string> dictionary = new();
        int newCapacity = dictionary.EnsureCapacity(100);
        
        Assert.True(newCapacity >= 100);
    }

    [Fact]
    public void GetAlternateLookup_Should_Return_Value_With_Case_Insensitive_StringComparer()
    {
        var dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "KEY1", "value1" }
        };

        // Get value using different case
        string result = dictionary.GetAlternateLookup("key1", key => key.ToUpper());
        
        Assert.Equal("value1", result);
    }

    [Fact]
    public void GetAlternateLookup_Should_Throw_When_Key_Not_Found_After_Transform()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        
        Assert.Throws<KeyNotFoundException>(() => 
            dictionary.GetAlternateLookup("KEY1", key => key.ToUpper()));
    }

    [Fact]
    public void GetAlternateLookup_Should_Use_Transform_Function()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        
        // Add a key that will match after transformation
        dictionary.Add("KEY21", "special-value");
        
        string result = dictionary.GetAlternateLookup("key21", key => key.ToUpper());
        
        Assert.Equal("special-value", result);
    }

    [Fact]
    public void TryGetAlternateLookup_Should_Return_True_And_Value_When_Key_Found_After_Transform()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        
        // Add a key that will match after transformation
        dictionary.Add("KEY21", "special-value");
        
        bool success = dictionary.TryGetAlternateLookup("key21", out string value, key => key.ToUpper());
        
        Assert.True(success);
        Assert.Equal("special-value", value);
    }

    [Fact]
    public void TryGetAlternateLookup_Should_Return_False_When_Key_Not_Found_After_Transform()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        
        bool success = dictionary.TryGetAlternateLookup("notpresent", out string value, key => key.ToUpper());
        
        Assert.False(success);
        Assert.Equal(default, value);
    }

    [Fact]
    public void TrimExcess_Should_Not_Throw()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        
        // This doesn't have a return value, so we just confirm it doesn't throw
        dictionary.TrimExcess();
        
        Assert.Equal(20, dictionary.Count);
    }

    [Fact]
    public void TrimExcess_With_Capacity_Should_Not_Throw()
    {
        Dictionary<string, string> dictionary = GetTestDictionary();
        
        // This doesn't have a return value, so we just confirm it doesn't throw
        dictionary.TrimExcess(25);
        
        Assert.Equal(20, dictionary.Count);
    }
}