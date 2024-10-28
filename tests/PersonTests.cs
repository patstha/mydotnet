namespace tests;

public class PersonTests : IDisposable
{
    public PersonTests()
    {
        // Ensure the factory is initialized before each test
        ResetPersonFactory();
    }

    public void Dispose()
    {
        // Reset the factory state after each test
        ResetPersonFactory();
    }

    private static void ResetPersonFactory()
    {
        typeof(PersonFactory).GetField("_isInitialized", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic)?.SetValue(null, false);
        typeof(PersonFactory).GetField("MinimumPasswordLength", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic)?.SetValue(null, 0);
        typeof(PersonFactory).GetField("MaximumPasswordLength", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic)?.SetValue(null, 0);
    }

    [Fact]
    public void UpdatePassword_ShouldSucceed_WhenPasswordMeetsRequirements()
    {
        // Arrange
        InitializePersonFactory(8, 128);
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
        InitializePersonFactory(8, 128);
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
        InitializePersonFactory(8, 128);
        Person person = PersonFactory.Create("John Doe", "initialPassword");
        string longPassword = new string('a', 129);

        // Act
        Action act = () => person.UpdatePassword(longPassword);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("The new password is not valid. A password must have a minimum length no shorter than 8 and no longer than 128.");
    }

    [Fact]
    public void Initialize_ShouldThrowException_WhenAlreadyInitialized()
    {
        // Arrange
        IOptions<PasswordSettings> passwordSettings = Options.Create(new PasswordSettings
        {
            MinimumPasswordLength = 8,
            MaximumPasswordLength = 128
        });
        PersonFactory.Initialize(passwordSettings);

        // Act
        Action act = () => PersonFactory.Initialize(passwordSettings);

        // Assert
        act.Should().Throw<InvalidOperationException>().WithMessage("PersonFactory is already initialized.");
    }

    [Fact]
    public void Create_ShouldThrowException_WhenNotInitialized()
    {
        // Act
        Action act = () => PersonFactory.Create("John Doe", "validPassword");

        // Assert
        act.Should().Throw<InvalidOperationException>().WithMessage("PersonFactory is not initialized.");
    }

    [Fact]
    public void Create_ShouldSucceed_WhenPasswordMeetsRequirements()
    {
        // Arrange
        InitializePersonFactory(8, 128);
        const string name = "John Doe";
        const string password = "validPassword";

        // Act
        Person person = PersonFactory.Create(name, password);

        // Assert
        person.Name.Should().Be(name);
        person.Password.Should().Be(password);
    }

    [Fact]
    public void Create_ShouldThrowException_WhenPasswordIsTooShort()
    {
        // Arrange
        InitializePersonFactory(8, 128);
        const string name = "John Doe";
        const string password = "short";

        // Act
        Action act = () => PersonFactory.Create(name, password);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage($"The password provided to create user {name} is not valid. A password must have a minimum length no shorter than 8 and no longer than 128.");
    }

    [Fact]
    public void Create_ShouldThrowException_WhenPasswordIsTooLong()
    {
        // Arrange
        InitializePersonFactory(8, 128);
        const string name = "John Doe";
        string password = new string('a', 129);

        // Act
        Action act = () => PersonFactory.Create(name, password);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage($"The password provided to create user {name} is not valid. A password must have a minimum length no shorter than 8 and no longer than 128.");
    }

    [Fact]
    public void CheckPasswordMeetsRequirements_ShouldReturnTrue_WhenPasswordIsValid()
    {
        // Arrange
        InitializePersonFactory(8, 128);
        const string password = "validPassword";

        // Act
        bool result = PersonFactory.CheckPasswordMeetsRequirements(password);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void CheckPasswordMeetsRequirements_ShouldReturnFalse_WhenPasswordIsTooShort()
    {
        // Arrange
        InitializePersonFactory(8, 128);
        const string password = "short";

        // Act
        bool result = PersonFactory.CheckPasswordMeetsRequirements(password);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void CheckPasswordMeetsRequirements_ShouldReturnFalse_WhenPasswordIsTooLong()
    {
        // Arrange
        InitializePersonFactory(8, 128);
        string password = new string('a', 129);

        // Act
        bool result = PersonFactory.CheckPasswordMeetsRequirements(password);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Initialize_ShouldSetMinimumAndMaximumPasswordLength()
    {
        // Arrange
        IOptions<PasswordSettings> passwordSettings = Options.Create(new PasswordSettings
        {
            MinimumPasswordLength = 10,
            MaximumPasswordLength = 20
        });

        // Act
        PersonFactory.Initialize(passwordSettings);

        // Assert
        PersonFactory.MinimumPasswordLength.Should().Be(10);
        PersonFactory.MaximumPasswordLength.Should().Be(20);
    }

    [Fact]
    public void Create_ShouldSucceed_WhenPasswordIsExactlyMinimumLength()
    {
        // Arrange
        InitializePersonFactory(8, 128);
        const string name = "John Doe";
        string password = new string('a', 8);

        // Act
        Person person = PersonFactory.Create(name, password);

        // Assert
        person.Name.Should().Be(name);
        person.Password.Should().Be(password);
    }

    [Fact]
    public void Create_ShouldSucceed_WhenPasswordIsExactlyMaximumLength()
    {
        // Arrange
        InitializePersonFactory(8, 128);
        const string name = "John Doe";
        string password = new string('a', 128);

        // Act
        Person person = PersonFactory.Create(name, password);

        // Assert
        person.Name.Should().Be(name);
        person.Password.Should().Be(password);
    }

    private void InitializePersonFactory(int minLength, int maxLength)
    {
        IOptions<PasswordSettings> passwordSettings = Options.Create(new PasswordSettings
        {
            MinimumPasswordLength = minLength,
            MaximumPasswordLength = maxLength
        });
        PersonFactory.Initialize(passwordSettings);
    }
}