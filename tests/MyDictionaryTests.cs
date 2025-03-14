using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace tests
{
    // Extension methods to add alternate lookup behavior.
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Retrieves the value for the given key if present. If not, attempts to retrieve a value using an alternate key
        /// computed as "alt_" + key. Throws if neither is found.
        /// </summary>
        public static string GetAlternateLookup(this Dictionary<string, string> dictionary, string key)
        {
            if (dictionary is null)
                throw new ArgumentNullException(nameof(dictionary));

            if (dictionary.TryGetValue(key, out string value))
            {
                return value;
            }

            string altKey = "alt_" + key;
            if (dictionary.TryGetValue(altKey, out value))
            {
                return value;
            }

            throw new KeyNotFoundException($"Key '{key}' or its alternate '{altKey}' not found.");
        }

        /// <summary>
        /// Attempts to retrieve the value for the given key. If not found, tries the alternate key "alt_" + key.
        /// Returns true if either lookup succeeds; otherwise, false.
        /// </summary>
        public static bool TryGetAlternateLookup(this Dictionary<string, string> dictionary, string key, out string value)
        {
            if (dictionary is null)
                throw new ArgumentNullException(nameof(dictionary));

            if (dictionary.TryGetValue(key, out value))
            {
                return true;
            }

            string altKey = "alt_" + key;
            if (dictionary.TryGetValue(altKey, out value))
            {
                return true;
            }

            value = default;
            return false;
        }
    }

    public class MyDictionaryTests
    {
        // Returns a test dictionary with keys "key1" to "key20".
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

        // Returns a test dictionary that also includes some alternate keys.
        private static Dictionary<string, string> GetTestDictionaryWithAlternate()
        {
            var dictionary = GetTestDictionary();
            dictionary.Add("alt_key21", "alternate_value21");
            dictionary.Add("alt_key22", "alternate_value22");
            return dictionary;
        }

        // --- Standard Dictionary Tests ---

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
        public void Contains_Key_Should_Return_True()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            Assert.True(dictionary.ContainsKey("key1"));
        }

        [Fact]
        public void Contains_Key_Should_Return_False()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            Assert.False(dictionary.ContainsKey("key21"));
        }

        [Fact]
        public void Contains_Value_Should_Return_True()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            Assert.True(dictionary.ContainsValue("value1"));
        }

        [Fact]
        public void Contains_Value_Should_Return_False()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            Assert.False(dictionary.ContainsValue("value21"));
        }

        [Fact]
        public void Indexer_Get_Should_Return_Correct_Value()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            Assert.Equal("value1", dictionary["key1"]);
        }

        [Fact]
        public void Indexer_Set_Should_Update_Value()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            dictionary["key1"] = "new_value1";
            Assert.Equal("new_value1", dictionary["key1"]);
        }

        [Fact]
        public void Remove_Key_Should_Remove_Key()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            bool removed = dictionary.Remove("key1");
            Assert.True(removed);
            Assert.False(dictionary.ContainsKey("key1"));
        }

        [Fact]
        public void Remove_NonExisting_Key_Should_Return_False()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            bool removed = dictionary.Remove("non_existing_key");
            Assert.False(removed);
        }

        [Fact]
        public void Clear_Should_Remove_All_Keys()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            dictionary.Clear();
            Assert.Empty(dictionary);
        }

        [Fact]
        public void Count_Should_Return_Correct_Number_Of_Elements()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            int countBefore = dictionary.Count;
            dictionary.Add("key21", "value21");
            Assert.Equal(countBefore + 1, dictionary.Count);
        }

        [Fact]
        public void Keys_And_Values_Should_Be_Correct()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            var keys = dictionary.Keys;
            var values = dictionary.Values;
            Assert.Contains("key1", keys);
            Assert.Contains("value1", values);
        }

        [Fact]
        public void TryGetValue_Should_Return_True_And_Correct_Value()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            bool result = dictionary.TryGetValue("key1", out string value);
            Assert.True(result);
            Assert.Equal("value1", value);
        }

        [Fact]
        public void TryGetValue_Should_Return_False_For_NonExisting_Key()
        {
            Dictionary<string, string> dictionary = GetTestDictionary();
            bool result = dictionary.TryGetValue("non_existing", out string value);
            Assert.False(result);
            Assert.Null(value);
        }

        // --- Tests for Alternate Lookup Methods ---

        [Fact]
        public void GetAlternateLookup_Should_Return_Original_Value_If_Key_Exists()
        {
            Dictionary<string, string> dictionary = GetTestDictionaryWithAlternate();
            // key exists in dictionary
            string value = dictionary.GetAlternateLookup("key1");
            Assert.Equal("value1", value);
        }

        [Fact]
        public void GetAlternateLookup_Should_Return_Alternate_Value_If_Original_Key_Does_Not_Exist_But_Alternate_Does()
        {
            Dictionary<string, string> dictionary = GetTestDictionaryWithAlternate();
            // "key21" doesn't exist but "alt_key21" does
            string value = dictionary.GetAlternateLookup("key21");
            Assert.Equal("alternate_value21", value);
        }

        [Fact]
        public void GetAlternateLookup_Should_Throw_When_Neither_Key_Nor_Alternate_Exists()
        {
            Dictionary<string, string> dictionary = GetTestDictionaryWithAlternate();
            Assert.Throws<KeyNotFoundException>(() => dictionary.GetAlternateLookup("non_existing"));
        }

        [Fact]
        public void TryGetAlternateLookup_Should_Return_True_And_Original_Value_If_Key_Exists()
        {
            Dictionary<string, string> dictionary = GetTestDictionaryWithAlternate();
            bool result = dictionary.TryGetAlternateLookup("key1", out string value);
            Assert.True(result);
            Assert.Equal("value1", value);
        }

        [Fact]
        public void TryGetAlternateLookup_Should_Return_True_And_Alternate_Value_If_Original_Key_Does_Not_Exist_But_Alternate_Does()
        {
            Dictionary<string, string> dictionary = GetTestDictionaryWithAlternate();
            bool result = dictionary.TryGetAlternateLookup("key22", out string value);
            // key22 doesn't exist but alt_key22 does
            Assert.True(result);
            Assert.Equal("alternate_value22", value);
        }

        [Fact]
        public void TryGetAlternateLookup_Should_Return_False_If_Neither_Key_Nor_Alternate_Exists()
        {
            Dictionary<string, string> dictionary = GetTestDictionaryWithAlternate();
            bool result = dictionary.TryGetAlternateLookup("non_existing", out string value);
            Assert.False(result);
            Assert.Null(value);
        }

        [Fact]
        public void GetAlternateLookup_Null_Dictionary_Should_Throw_ArgumentNullException()
        {
            Dictionary<string, string> dictionary = null;
            Assert.Throws<ArgumentNullException>(() => dictionary.GetAlternateLookup("key1"));
        }

        [Fact]
        public void TryGetAlternateLookup_Null_Dictionary_Should_Throw_ArgumentNullException()
        {
            Dictionary<string, string> dictionary = null;
            Assert.Throws<ArgumentNullException>(() => dictionary.TryGetAlternateLookup("key1", out _));
        }
    }
}