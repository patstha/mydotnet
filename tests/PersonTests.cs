using hellolib;
using System;
using FluentAssertions;
namespace tests;

public class PersonTests
{
    [Theory]
    [InlineData("Pratikchhya Shrestha", "12345678")]
    [InlineData("Pratikchhya Shrestha", "123456789")]
    [InlineData("Pratikchhya Shrestha", "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678")]
    public void CreatePersonWithNameSucceeds(string name, string password)
    {
        Person person = PersonFactory.Create(name, password);
        Assert.Equal("Pratikchhya Shrestha", person.Name);
        //person.Name.Should().Be("Pratikchhya Shrestha");
        //person.CreatedBy.Should().Be("System");
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
            int MINIMUM_PASSWORD_LENGTH = 8;
            int MAXIMUM_PASSWORD_LENGTH = 128;
            e.Message.Should().Be($"The password provided to create user {name} is not valid. A password must have a minimum length no shorter than {MINIMUM_PASSWORD_LENGTH} and no longer than {MAXIMUM_PASSWORD_LENGTH}.");
        }
    }
}
