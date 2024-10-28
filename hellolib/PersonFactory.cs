using Microsoft.Extensions.Options;

namespace hellolib;

public static class PersonFactory
{
    private static int _minimumPasswordLength;
    private static int _maximumPasswordLength;
    private static bool _isInitialized;

    public static int MinimumPasswordLength => _minimumPasswordLength;
    public static int MaximumPasswordLength => _maximumPasswordLength;

    public static void Initialize(IOptions<PasswordSettings> passwordSettings)
    {
        if (_isInitialized)
        {
            throw new InvalidOperationException("PersonFactory is already initialized.");
        }

        _minimumPasswordLength = passwordSettings.Value.MinimumPasswordLength;
        _maximumPasswordLength = passwordSettings.Value.MaximumPasswordLength;
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
            : throw new ArgumentException($"The password provided to create user {name} is not valid. A password must have a minimum length no shorter than {_minimumPasswordLength} and no longer than {_maximumPasswordLength}.");
    }

    public static bool CheckPasswordMeetsRequirements(string password)
    {
        int length = password.Length;
        return length >= _minimumPasswordLength && length <= _maximumPasswordLength;
    }
}


public class PasswordSettings
{
    public int MinimumPasswordLength { get; set; }
    public int MaximumPasswordLength { get; set; }
}
