using System;
using Xunit;
using hellolib;
namespace tests
{
    public class PersonTests
    {
        [Fact]
        public void CreatePersonWithNameSucceeds()
        {
            Person person = new Person();
            person.Name = "Pratikchhya Shrestha";
            Assert.Equal("Pratikchhya Shrestha", person.Name);
        }

        [Fact]
        public void ShortPasswordsFail()
        {
            Person person = new Person();
            bool actual = person.CheckPasswordMeetsRequirements("hunter2");
            Assert.False(actual);
        }
        [Fact]
        public void LongPasswordsFail()
        {
            Person person = new Person();
            bool actual = person.CheckPasswordMeetsRequirements("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz");
            Assert.False(actual);
        }
    }
}
