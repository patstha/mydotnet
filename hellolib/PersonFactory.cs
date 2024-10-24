namespace hellolib;

public static class PersonFactory
{
    private static readonly int MinimumPasswordLength = 8;
    private static readonly int MaximumPasswordLength = 128;
    public static Person Create(string name, string password)
    {
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
