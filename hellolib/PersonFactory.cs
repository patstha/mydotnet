using Microsoft.Extensions.Options;

namespace hellolib;

public static class PersonFactory
{
    private static bool _isInitialized;

    public static int MinimumPasswordLength { get; private set; }

    public static int MaximumPasswordLength { get; private set; }

    public static void Initialize(IOptions<PasswordSettings> passwordSettings)
    {
        if (_isInitialized)
        {
            throw new InvalidOperationException("PersonFactory is already initialized.");
        }

        MinimumPasswordLength = passwordSettings.Value.MinimumPasswordLength;
        MaximumPasswordLength = passwordSettings.Value.MaximumPasswordLength;
        _isInitialized = true;
    }

    public static Person Create(string name, string password)
    {
        if (!_isInitialized)
        {
            throw new InvalidOperationException("PersonFactory is not initialized.");
        }

        return CheckPasswordMeetsRequirements(password)
            ? new Person(name, password)
            : throw new ArgumentException($"The password provided to create user {name} is not valid. A password must have a minimum length no shorter than {MinimumPasswordLength} and no longer than {MaximumPasswordLength}.");
    }

    public static bool CheckPasswordMeetsRequirements(string password)
    {
        int length = password.Length;
        return length >= MinimumPasswordLength && length <= MaximumPasswordLength;
    }
}


public class PasswordSettings
{
    public int MinimumPasswordLength { get; set; }
    public int MaximumPasswordLength { get; set; }
}
