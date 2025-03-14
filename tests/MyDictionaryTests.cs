using System;
using System.Collections.Generic;
using Xunit;

namespace tests
{
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
                       Assert.Equal("value21", dictionary["key21"]);
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
           Key("key1");
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

        [Fact]
        public void Remove_ExistingKey_Should_Remove_Key()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            bool removed = dictionary.Remove("key1");
            Assert.True(removed);
            Assert.False(dictionary.ContainsKey("key1"));
        }

        [Fact]
        public void Remove_NonExistingKey_Should_Return_False()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            bool removed = dictionary.Remove("key21");
            Assert.False(removed);
        }

        [Fact]
        public void TryGetValue_ExistingKey_Should_Return_Value()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            bool found = dictionary.TryGetValue("key1", out string value);
            Assert.True(found);
            Assert.Equal("value1", value);
        }

        [Fact]
        public void TryGetValue_NonExistingKey_Should_Return_False()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            bool found = dictionary.TryGetValue("key21", out string value);
            Assert.False(found);
            Assert.Null(value);
        }

        [Fact]
        public void Clear_Should_Remove_All_Entries()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            dictionary.Clear();
            Assert.Empty(dictionary);
        }

        [Fact]
        public void Count_Should_Return_Correct_Number_Of_Entries()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            Assert.Equal(20, dictionary.Count);
        }

        [Fact]
        public void GetAlternateLookup_ExistingKey_Should_Return_Value()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            ReadOnlySpan<char> keySpan = "key1".AsSpan();
            string value = dictionary.GetAlternateLookup(keySpan);
            Assert.Equal("value1", value);
        }

        [Fact]
        public void GetAlternateLookup_NonExistingKey_Should_Return_Null()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            ReadOnlySpan<char> keySpan = "key21".AsSpan();
            string value = dictionary.GetAlternateLookup(keySpan);
            Assert.Null(value);
        }

        [Fact]
        public void TryGetAlternateLookup_ExistingKey_Should_Return_True_And_Value()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            ReadOnlySpan<char> keySpan = "key1".AsSpan();
            bool found = dictionary.TryGetAlternateLookup(keySpan, out string value);
            Assert.True(found);
            Assert.Equal("value1", value);
        }

        [Fact]
        public void TryGetAlternateLookup_NonExistingKey_Should_Return_False()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            ReadOnlySpan<char> keySpan = "key21".AsSpan();
            bool found = dictionary.TryGetAlternateLookup(keySpan, out string value);
            Assert.False(found);
            Assert.Null(value);
        }
    }
}