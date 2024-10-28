namespace tests;
public class PersonTests : IClassFixture<PersonFactoryFixture>
{
    [Fact]
    public void UpdatePassword_ShouldSucceed_WhenPasswordMeetsRequirements()
    {
        // Arrange
        Person person = PersonFactory.Create("John Doe", "initialPassword");

        // Act
        person.UpdatePassword("newValidPassword");

        // Assert
        person.Password.Should().Be("newValidPassword");
        person.ModifiedDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        person.ModifiedBy.Should().Be("John Doe");
    }

    [Fact]
    public void UpdatePassword_ShouldFail_WhenPasswordIsTooShort()
    {
        // Arrange
        Person person = PersonFactory.Create("John Doe", "initialPassword");

        // Act
        Action act = () => person.UpdatePassword("short");

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("The new password is not valid. A password must have a minimum length no shorter than 8 and no longer than 128.");
    }

    [Fact]
    public void UpdatePassword_ShouldFail_WhenPasswordIsTooLong()
    {
        // Arrange
        Person person = PersonFactory.Create("John Doe", "initialPassword");
        string longPassword = new string('a', 129);

        // Act
        Action act = () => person.UpdatePassword(longPassword);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("The new password is not valid. A password must have a minimum length no shorter than 8 and no longer than 128.");
    }
}

public class PersonFactoryFixture : IDisposable
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

