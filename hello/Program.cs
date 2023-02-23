using hellolib;
using System;
namespace hello;
public static class Solution
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
