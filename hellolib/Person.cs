namespace hellolib;

public class Person : Entity
{
    public string Name { get; }
    public string Password { get; private set; }

    internal Person(string name, string password)
    {
        Name = name;
        Password = password;
    }

    public void UpdatePassword(string newPassword)
    {
        if (PersonFactory.CheckPasswordMeetsRequirements(newPassword))
        {
            Password = newPassword;
            ModifiedBy = Name;
            ModifiedDate = DateTime.UtcNow;
        }
        else
        {
            throw new ArgumentException($"The new password is not valid. A password must have a minimum length no shorter than {PersonFactory.MinimumPasswordLength} and no longer than {PersonFactory.MaximumPasswordLength}.");
        }
    }
}