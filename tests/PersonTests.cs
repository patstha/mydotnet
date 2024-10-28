namespace tests;
public class PersonTests : IClassFixture<PersonFactoryFixture>
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
        const int minimumPasswordLength = 8;
        const int maximumPasswordLength = 128;
        for (int i = minimumPasswordLength + 1; i < maximumPasswordLength; i++) 
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
        string expectedPassword = new('X', maximumPasswordLength);
        Person person = PersonFactory.Create("", expectedPassword);
        person.Name.Should().Be("");
        person.CreatedBy.Should().Be("System");
        person.Password.Should().Be(expectedPassword);
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
        const int minimumPasswordLength = 8;
        const int maximumPasswordLength = 128;

        Action act = () => PersonFactory.Create(name, password);

        act.Should().Throw<ArgumentException>().WithMessage($"The password provided to create user {name} is not valid. A password must have a minimum length no shorter than {minimumPasswordLength} and no longer than {maximumPasswordLength}.");
    }
}

internal class PersonFactoryFixture : IDisposable
{
    public PersonFactoryFixture()
    {
        IOptions<PasswordSettings> passwordSettings = Options.Create(new PasswordSettings
        {
            MinimumPasswordLength = 8,
            MaximumPasswordLength = 128
        });
        PersonFactory.Initialize(passwordSettings);
    }

    public void Dispose()
    {
        // Cleanup if needed
    }
}
