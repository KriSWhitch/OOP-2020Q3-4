using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

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

            // Задание 1
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

            // Задание 2
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

            // Задание 3
            Dictionary<int, Flowers> flowers = new Dictionary<int, Flowers>(5);
            Flowers flower1 = new Flowers("Мак");
            Flowers flower2 = new Flowers("Алоэ");
            Flowers flower3 = new Flowers("Роза");
            Flowers flower4 = new Flowers("Ромашка");
            Flowers flower5 = new Flowers("Пион");
            flowers.Add(1, flower1);
            flowers.Add(2, flower2);
            flowers.Add(3, flower3);
            flowers.Add(4, flower4);
            flowers.Add(5, flower5);
            foreach (KeyValuePair<int, Flowers> el in flowers)
            {
                Console.WriteLine(el.Value.name);
            }
            Console.Write($"Введите число элементов, которое вы хотите удалить с конца: ");
            n = Int32.Parse(Console.ReadLine());
            f = flowers.Count - n;
            for (int i = flowers.Count; i > f; i--)
            {
                Console.WriteLine($"{flowers[i].name} удалён");
                flowers.Remove(i);
            }
            Console.WriteLine($"Оставшиеся элементы: ");
            foreach (KeyValuePair<int, Flowers> el in flowers)
            {
                Console.WriteLine(el.Value.name);
            }
            HashSet<Flowers> flowersHash = new HashSet<Flowers>(flowers.Count);
            for (int i = 1; i <= countries.Count; i++)
            {
                flowersHash.Add(flowers[i]);
            }
            if (flowersHash.Contains(flower1)) Console.WriteLine($"flowersHash содержит элемент: \"flower1\"");

            // Задание 4
            ObservableCollection<Flowers> task4 = new ObservableCollection<Flowers>(); 
        }
    }
}
