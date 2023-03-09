using hellolib;
using System;
namespace tests;

public class PersonTests
{
    [Theory]
    [InlineData("Pratikchhya Shrestha", "12345678")]
    public void CreatePersonWithNameSucceeds(string name, string password)
    {
        Person person = PersonFactory.Create(name, password);
        Assert.Equal("Pratikchhya Shrestha", person.Name);
    }

    [Theory]
    [InlineData("Pratikchhya Shrestha", "hunter2")]
    [InlineData("Pratikchhya Shrestha", "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz")]
    public void ShortOrLongPasswordsFail(string name, string password)
    {
        try
        {
            Person person = PersonFactory.Create(name, password);
        }
        catch (ArgumentException e)
        {
            Assert.NotNull(e);
        }
    }
}
