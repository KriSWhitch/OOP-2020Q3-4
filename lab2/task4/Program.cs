using System;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Инициализация Кортежа и его вывод
            (int, string, char, string, ulong) array1 = (5, "Привет", 'b', "Что?", 500);
            Console.WriteLine(array1);
            Console.WriteLine($" Первый элемент кортежа = {array1.Item1} и 3-ий элемент кортежа = {array1.Item3}");

            // Первый способ распаковки кортежей
            var elem1 = array1.Item1;
            var elem2 = array1.Item2;
            // Второй способ распаковки кортежей
            //(var el1, var el2, var el3, var el4, var el5) = array1;
            var ( el1, el2, el3, el4, el5) = array1;

            Console.WriteLine($" Первый элемент кортежа = {el1} и 3-ий элемент кортежа = {el3}");

            // Сравнение кортежей
            (int, string, char, string, ulong) array2 = (11, "Привет", 'b', "Что?", 500);
            Console.WriteLine(array1.Equals(array2));
        }
    }
}
