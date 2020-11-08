using System;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Cake p2 = new Cake { name = "Графские развалины", Diameter = 40 };
            MyReflector.ClassInformationToFile(p2);
            MyReflector.GetClassMethods("lab12.Cake", "System.Int32");
            MyReflector.CallMethod(p2, "TestTask");
        }
    }
}
