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
    }
}
