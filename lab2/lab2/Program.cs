using System;
using System.Collections.Generic;
using System.Linq;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {

            // инициализация примитивных типов данных

            Console.Write("bool check = ");
            bool check = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine($"bool check = {check}");

            Console.Write("int a = ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"int a = {a}");

            Console.Write("sbyte b = ");
            sbyte b = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine($"sbyte b = {b}");

            Console.Write("char c = ");
            char c = Convert.ToChar(Console.ReadLine());
            Console.WriteLine($"char c = {c}");

            Console.Write("decimal d = ");
            decimal d = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine($"decimal d = {d}");

            Console.Write("double e = ");
            double e = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"double e = {e}");

            Console.Write("float f = ");
            float f = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine($"float f = {f}");

            Console.Write("uint g = ");
            uint g = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine($"uint g = {g}");

            Console.Write("long h = ");
            long h = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine($"long h = {h}");

            Console.Write("ulong i = ");
            ulong i = Convert.ToUInt64(Console.ReadLine());
            Console.WriteLine($"ulong i = {i}");

            Console.Write("short j = ");
            short j = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine($"short j = {j}");

            Console.Write("ushort k = ");
            ushort k = Convert.ToUInt16(Console.ReadLine());
            Console.WriteLine($"ushort k = {k}");


            // неявное приведение
            a = j;
            a = k;
            h = a;
            f = a;
            g = k;
            // явное приведение 
            g = (uint)a;
            h = (long)a;
            f = (float)a;
            e = (double)a;
            d = (decimal)a;


            //упаковка и распаковка 

            int x = 123; 
            object o = x; // упаковка является неявным преобразованием. 
            // Упаковка представляет собой процесс преобразования типа значения в тип object или в любой другой тип интерфейса

            o = 123;
            x = (int)o;  // распаковка является явным преобразованием


            // Эти переменные типизированы неявно. Они отнесены
            // к типу double,  поскольку инициализирующие их
            // выражения сами относятся к типу double,
            var s1 = 4.0;
            var s2 = 5.0;

            // Итак, переменная hypot типизирована неявно и
            // относится к типу double, поскольку результат,
            // возвращаемый методом Sqrt(),  имеет тип double,
            var hypot = Math.Sqrt((s1 * s1) + (s2 * s2));

            Console.Write("Гипотенуза треугольника со сторонами " +
            s1 + " by " + s2 + " равна ");

            Console.WriteLine("{0:#.###}.", hypot);

            int? l2 = null; // Nullable<T> свойство объекта показывающее имеет он значение или нет
            Console.WriteLine($"{l2}");
            l2 = 5;
            Console.WriteLine($"{l2}");
            l2 = null;
            Console.WriteLine($"{l2}");

            int l1 = null;


            var i1 = 42; // переменная объявленная через var является строготипизированой
            i1 = "hello"; //ошибка
        }
    }
}
