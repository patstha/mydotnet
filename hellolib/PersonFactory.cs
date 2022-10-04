namespace hellolib
{
    public static class PersonFactory
    {
        private static readonly int MINIMUM_PASSWORD_LENGTH = 8;
        private static readonly int MAXIMUM_PASSWORD_LENGTH = 128;
        public static Person Create(string name, string password)
        {
            if (CheckPasswordMeetsRequirements(password))
            {
                return new Person(name, password);
            }
            else
            {
                throw new ArgumentException($"The password provided to create user {name} is not valid. A password must have a minimum length no shorter than {MINIMUM_PASSWORD_LENGTH} and no longer than {MAXIMUM_PASSWORD_LENGTH}.");
            }
        }
        public static bool CheckPasswordMeetsRequirements(string password)
        {
            int length = password.Length;
            if (length < MINIMUM_PASSWORD_LENGTH)
            {
                return false;
            }
            if (length > MAXIMUM_PASSWORD_LENGTH)
            {
                return false;
            }
            return true;
        }
    }
}
