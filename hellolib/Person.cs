using System;

namespace hellolib
{
    public class Person
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public bool CheckPasswordMeetsRequirements(string password)
        {
            int length = password.Length;
            if (length < 8)
            {
                return false;
            }
            return true;
        }
    }
}
