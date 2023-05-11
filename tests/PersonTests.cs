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
    [InlineData("12345678")]
    [InlineData("123456789")]
    [InlineData("12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678")]
    public void CheckPasswordMeetsRequirements_Should_ReturnTrue_When_WeAreWithinLengthLimit(string password)
    {
        bool actual = PersonFactory.CheckPasswordMeetsRequirements(password);
        Assert.True(actual);
    }

    [Theory]
    [InlineData("hunter2")]
    [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz")]
    public void CheckPasswordMeetsRequirements_Should_ReturnFalse_When_WeAreNotWithinLengthLimit(string password)
    {
        bool actual = PersonFactory.CheckPasswordMeetsRequirements(password);
        Assert.False(actual);
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
