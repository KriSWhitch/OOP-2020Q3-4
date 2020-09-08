using System;
using System.Text;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "hello";
            string s2 = "world";
            string s3 = "wow, how it work's?";
            Console.WriteLine(String.Equals(s1, s2));
            Console.WriteLine(s3 + s2); // сцепление ( конкатенация)
            string s4 = s1; // копирование строки

            char ch1 = 'o';
            int indexOfChar = s3.IndexOf(ch1); // выделение подстроки, первая подстрока встречается под индексом 1
            Console.WriteLine(indexOfChar);

            string[] words = s3.Split(" ");
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine($"Элемент строки №{i+1} = {words[i]}"); // разбиение строки на слова
            }

            Console.WriteLine(s4.Insert(1, "!")); // вставка подстроки в строку
            Console.WriteLine(s4.Replace("l", "")); // удаление подстроки в строке
            string nullOrEmpty1 = "";
            string nullOrEmpty2 = null;
            Console.WriteLine(String.IsNullOrEmpty(nullOrEmpty1));
            Console.WriteLine(String.IsNullOrEmpty(nullOrEmpty2));
            Console.WriteLine(("" + 530).GetType());

            StringBuilder sb = new StringBuilder("Привет мир");
            Console.WriteLine($"Длина строки: {sb.Length}");
            Console.WriteLine($"Емкость строки: {sb.Capacity}");
            sb.Remove(0, 1); sb.Remove(4, 5);
            sb.Insert(0, "!"); sb.Insert(sb.Length, "!");
            Console.WriteLine(sb);

        }
    }
}
