using System;
using hellolib;
namespace hello;
class Solution
{
    public static void Main(string[] args)
    {
        if (args.Length > 1)
        {
            Person person = PersonFactory.Create(args[0], args[1]);
            Console.WriteLine($"{person.CreatedBy} created Person with name {person.Name} at {person.CreatedDate}");
        }
    }
}
