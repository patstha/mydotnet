using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using hellolib;

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
