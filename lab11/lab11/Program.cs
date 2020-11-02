using System;
using System.Collections;
using System.Linq;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] mounth = new string[12] {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December",
            };
            Console.WriteLine($"Введите максимальную длину месяца");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Месяцы, длина линии которых меньше, чем {n}:");
            IEnumerable task1 = from m in mounth
                                where m.Length < n
                                select m;
            foreach (string el in task1) {
                Console.Write($"{el} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Сортировка по названию месяца:");
            IEnumerable task2 = from m in mounth
                                orderby m
                                select m;
            foreach (string el in task2)
            {
                Console.Write($"{el} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Сортировка по зимним и летним месяцам:");
            IEnumerable task3 = from m in mounth
                                where m.Equals("December") || m.Equals("January") || m.Equals("February")
                                || m.Equals("June") || m.Equals("July") || m.Equals("August")
                                orderby m
                                select m;
            foreach (string el in task3)
            {
                Console.Write($"{el} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Месяцы, длина линии которых больше 3 и содержащие букву u:");
            IEnumerable task4 = from m in mounth
                                where m.Length >= 4 && m.Contains("u")
                                orderby m
                                select m;
            foreach (string el in task4)
            {
                Console.Write($"{el} ");
            }
            Console.WriteLine();
        }
    }
}
