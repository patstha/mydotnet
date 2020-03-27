using System;

namespace hellolib
{
    public class Person
    {
        private static readonly int MINIMUM_PASSWORD_LENGTH = 8;
        public string Name { get; set; }

        public string Password { get; set; }

        public bool CheckPasswordMeetsRequirements(string password)
        {
            int length = password.Length;
            if (length < MINIMUM_PASSWORD_LENGTH)
            {
                return false;
            }
            return true;
        }
    }
}
