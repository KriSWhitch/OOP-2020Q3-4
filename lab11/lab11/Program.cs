using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание №1
            Console.WriteLine($"Задание №1");
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
            // Задание №2,3
            Console.WriteLine($"Задание №2,3");
            List <Product> productList = new List<Product>();
            Product pr1 = new Product("Молоко", "Lesha", 100);
            Product pr2 = new Product("Кефир", "Lesha", 200);
            Product pr3 = new Product("Сыр", "Vanya", 300);
            Product pr4 = new Product("Сыр", "Lesha", 250);
            productList.Add(pr1); productList.Add(pr2); productList.Add(pr3); productList.Add(pr4);
            IEnumerable task2_1 = from pr in productList
                                  where pr.ProductName == "Сыр"
                                  select pr;
            Console.WriteLine($"Список товаров для заданного наименования;"); 
            foreach (Product el in task2_1)
            {
                el.GetInfo();
            }
            Console.WriteLine();
            IEnumerable task2_2 = from pr in productList
                                  where pr.ProductName == "Сыр" 
                                  && pr.Cost <= 275
                                  select pr;
            Console.WriteLine($"Список товаров для заданного наименования, цена которых не превосходит заданную:");
            foreach (Product el in task2_2)
            {
                el.GetInfo();
            }
            Console.WriteLine();
            IEnumerable task2_3 = from pr in productList
                                  where pr.Cost > 100
                                  select pr;
            Console.WriteLine($"Количество наименований цена которых больше 100:");
            int count = 0;
            foreach (Product el in task2_3)
            {
                count++;
            }
            Console.WriteLine($"Число товаров с ценой больше 100: {count}");
            Console.WriteLine();
            Product task2_4 = productList.OrderBy(pr => pr.Cost).Last();
            Console.WriteLine($"Товар с максимальной ценой:");
            task2_4.GetInfo();
            Console.WriteLine();
            IEnumerable task2_5 = from pr in productList
                                  orderby pr.ProductProducer
                                  orderby pr.Amount
                                  select pr;
            Console.WriteLine($"Упорядоченный набор товаров по производителю, а потом по количеству: ");
            foreach (Product el in task2_5)
            {
                el.GetInfo();
            }
            Console.WriteLine();
        }
    }
}
