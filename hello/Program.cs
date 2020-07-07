using System;

namespace hello
{
    class main
    {
        public static void Main()
        {
            Console.WriteLine(DoSomething());
            Console.Read();
        }

        public static string DoSomething()
        {
            try
            {
                return "A";
            }
            catch
            {
                return "B";
            }
            finally
            {
                Console.WriteLine("C");
            }
        }
    }
}
