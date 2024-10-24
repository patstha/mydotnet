namespace tests;

public class PersonTests
{
    [Fact]
    public void CreatePersonWithName_ShouldSucceed_WhenPasswordMatchesMinimumLength()
    {
        const int minimumPasswordLength = 8;
        Person person = PersonFactory.Create("", new string('X', minimumPasswordLength));
        person.Name.Should().Be("");
        person.CreatedBy.Should().Be("System");
    }


    [Fact]
    public void CreatePersonWithName_ShouldSucceed_WhenPasswordIsBetweenMinimumAndMaximumLength()
    {
        // Arrange
        const int minimumPasswordLength = 8;
        const int maximumPasswordLength = 128;
        for (int i = 0; i is > minimumPasswordLength and < maximumPasswordLength; i++) 
        {
            Person person = PersonFactory.Create("", new string('X', i));
            person.Name.Should().Be("");
            person.CreatedBy.Should().Be("System");
        }
    }

    [Fact]
    public void CreatePersonWithName_ShouldSucceed_WhenPasswordMatchesMaximumLength()
    {
        const int maximumPasswordLength = 128;
        Person person = PersonFactory.Create("", new string('X', maximumPasswordLength));
        person.Name.Should().Be("");
        person.CreatedBy.Should().Be("System");
    }

    [Theory]
    [InlineData("12345678")]
    [InlineData("123456789")]
    [InlineData("12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678")]
    public void CheckPasswordMeetsRequirements_Should_ReturnTrue_When_WeAreWithinLengthLimit(string password)
    {
        bool actual = PersonFactory.CheckPasswordMeetsRequirements(password);
        actual.Should().BeTrue();
    }

    [Theory]
    [InlineData("hunter2")]
    [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz")]
    public void CheckPasswordMeetsRequirements_Should_ReturnFalse_When_WeAreNotWithinLengthLimit(string password)
    {
        bool actual = PersonFactory.CheckPasswordMeetsRequirements(password);
        actual.Should().BeFalse();
    }

    [Theory]
    [InlineData("Pratikchhya Shrestha", "hunter2")]
    [InlineData("Pratikchhya Shrestha", "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz")]
    public void ShortOrLongPasswordsFail(string name, string password)
    {
        // Arrange
        const int minimumPasswordLength = 8;
        const int maximumPasswordLength = 128;

        // Act
        Action act = () => PersonFactory.Create(name, password);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage($"The password provided to create user {name} is not valid. A password must have a minimum length no shorter than {minimumPasswordLength} and no longer than {maximumPasswordLength}.");
    }
}
