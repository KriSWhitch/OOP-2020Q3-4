using System;
using System.Collections;
using System.Collections.Generic;

namespace lab10
{

    public class Student
    {
        private int age;
        public Student()
        {
            age = 0;
        }
        public Student(int age)
        {
            this.age = age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add(5); list.Add(6); list.Add(3); list.Add(6); list.Add(3);
            list.Add("string"); list.Add(new Student(18));
            list.RemoveAt(3); list.Remove(5);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine($"Всего в колекции {list.Count} элементов");
            if (list.Contains("string")) Console.WriteLine($"list содержит \"string\" под индексом { list.IndexOf("string") }");
            Dictionary<int, string> countries = new Dictionary<int, string>(5);
            countries.Add(1, "Belarus"); countries.Add(2, "Russia"); countries.Add(3, "Ukraine");
            countries.Add(4, "USA"); countries.Add(5, "France");
            for (int i = 1; i <= countries.Count; i++)
            {
                Console.WriteLine(countries[i]);
            }
            Console.Write($"Введите число элементов, которое вы хотите удалить с конца: ");
            int n = Int32.Parse(Console.ReadLine());
            int f = countries.Count - n;
            for (int i = countries.Count; i > f ; i--)
            {
                Console.WriteLine($"{countries[i]} удалён");
                countries.Remove(i);
            }
            Console.WriteLine($"Оставшиеся элементы: ");
            for (int i = 1; i <= countries.Count; i++)
            {
                Console.WriteLine(countries[i]);
            }
            HashSet<string> countriesHash = new HashSet<string>(countries.Count);
            for (int i = 1; i <= countries.Count; i++)
            {
                countriesHash.Add(countries[i]);
            }
            if (countriesHash.Contains("Belarus")) Console.WriteLine($"countriesHash содержит элемент: \"Belarus\"");


        }
    }
}
