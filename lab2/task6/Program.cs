using System;
using System.Security.Cryptography.X509Certificates;

namespace task6
{
    class Program
    {
        static void Main(string[] args)
        {
            firstFunc();
            secondFunc();
        }

        static void firstFunc()
        {
            int f = checked(2147483647);
            Console.WriteLine(f);
        }

        static void secondFunc()
        {
            int f = unchecked(2147483647 + 1);
            Console.WriteLine(f);
        }


    }
}
