using System;
using System.Diagnostics;

namespace lab7
{




    public class SweetsException : Exception
    {
        public SweetsException(string message)
            : base(message)
        { }
    }

    public class CakeException : Exception
    {
        public CakeException(string message, int diameter)
            : base(message)
        {
            Console.WriteLine($"Вы указали диаметр в {diameter} см");
        }
    }

    public class ClockException : Exception
    {
        public ClockException(string message, double cost)
            : base(message)
        {
            Console.WriteLine($"Вы указали цену в {cost} у.е.");
        }
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Проверка первого конструктора исключений
                Console.WriteLine($"\nПервый конструктор\n");
                try { Sweets p1 = new Sweets { Name = "wkdgsad,mv1389i19rvkovsdfm194" }; }
                catch (SweetsException ex) { Console.WriteLine("Ошибка: " + ex.Message); }
                // Проверка второго конструктора исключений
                Console.WriteLine($"\nВторой конструктор\n");
                try { Cake p2 = new Cake { name = "Графские развалины", Diameter = 40 }; }
                catch (CakeException ex) { Console.WriteLine("Ошибка: " + ex.Message); }
                // Проверка третьего конструктора исключений
                Console.WriteLine($"\nТретий конструктор\n");
                try { Clock p3 = new Clock { name = "Графские развалины", Cost = 810 }; }
                catch (ClockException ex) { Console.WriteLine("Ошибка: " + ex.Message); }
                // Проверка второго конструктора исключений (2)
                Console.WriteLine($"\nВторой конструктор (2)\n");
                try { Cake p4 = new Cake { name = "Графские развалины", Diameter = -5 }; }
                catch (CakeException ex) { Console.WriteLine("Ошибка: " + ex.Message); }
                // Проверка третьего конструктора исключений (2)
                Console.WriteLine($"\nТретий конструктор (2)\n");
                try { Clock p5 = new Clock { name = "Графские развалины", Cost = 21.234 }; }
                catch (ClockException ex) { Console.WriteLine("Ошибка: " + ex.Message); }
                Console.WriteLine();

                Cake p = new Cake { name = "Графские развалины", Diameter = 40 };

            }
            catch (Exception ex)
            {
                Console.WriteLine("Исключение: " + ex.Message);
                Console.WriteLine($"Исключение было вызвано в следующем месте: {ex.InnerException}");
                Console.WriteLine($"{ex.StackTrace}");
            }
            catch
            {
                Console.WriteLine($"Универсальный обработчик\n");
            }
            finally
            {
                // Create an index for an array.
                int index;
                // Perform some action that sets the index.
                index = -40;
                // Test that the index value is valid.
                Debug.Assert(index > -1, "Индекс массива должен быть больше или равен нулю!");
                Console.WriteLine($"Выполнение программы завершено!");
            }


        }
    }
}
