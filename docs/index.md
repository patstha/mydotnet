# Testing Stryker

Stryker logs are at [stryker.txt](https://raw.githubusercontent.com/patstha/mydotnet/master/docs/StrykerOutput/output.txt). 

Take a look at this mutation report though

[StrykerOutput\2023-05-06.03-53-34\reports\mutation-report.html](/StrykerOutput/2023-05-06.03-53-34/reports/mutation-report.html) 

![and or](/assets/stryker-andor.png)
![less than](/assets/stryker-lessthan.png)

```csharp
namespace hellolib;

public static class PersonFactory
{
    private static readonly int MINIMUM_PASSWORD_LENGTH = 8;
    private static readonly int MAXIMUM_PASSWORD_LENGTH = 128;
    public static Person Create(string name, string password)
    {
        return CheckPasswordMeetsRequirements(password)
            ? new Person(name, password)
            : throw new ArgumentException($"The password provided to create user {name} is not valid. A password must have a minimum length no shorter than {MINIMUM_PASSWORD_LENGTH} and no longer than {MAXIMUM_PASSWORD_LENGTH}.");
    }
    public static bool CheckPasswordMeetsRequirements(string password)
    {
        int length = password.Length;
        return length >= MINIMUM_PASSWORD_LENGTH && length <= MAXIMUM_PASSWORD_LENGTH;
    }
}
```

How would you fix these? 
