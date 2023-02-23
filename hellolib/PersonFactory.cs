namespace hellolib
{
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
}
