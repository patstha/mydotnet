using System;

namespace hellolib
{
    public class Person
    {
        public string Name { get; }
        public string Password { get; }
        internal Person(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
