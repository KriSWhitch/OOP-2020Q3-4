using System;
using System.Diagnostics;

namespace lab7
{

    class Clock : Goods
    {

        private int cost;
        public int Cost
        {
            get { return cost;  }
            set
            {
                if (value < 100 || value > 600)
                {
                    throw new ClockExeption("Стоимость часов должна находится между 100 и 600 у.е." , value);
                } 
                else
                {
                    cost = value;
                }
            }
        }

        public Clock()
        {
            this.name = "Без имени";
        }

        public Clock(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return $"Тип данного объекта: {GetType()}\n" +
                $"ID: {GetHashCode()}\n" +
                $"Название часов: {name}";
        }
    }

    class Cake : Pastry
    {
        private int diameter;
        public int Diameter
        {
            get { return diameter; }
            set
            {
                if (value > 23 || value < 13)
                {
                    throw new CakeExeption("Диаметр торта не может быть меньше 13 см или больше 23 см", value);
                }
                else
                {
                    diameter = value;
                }
            }
        }

        public Cake()
        {
            this.name = "Без имени";
        }

        public Cake(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return $"Тип данного объекта: {GetType()}\n" +
                $"ID: {GetHashCode()}\n" +
                $"Название торта: {name}";
        }
    }

    class Sweets : Goods
    {
        int id;

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length > 18 || value.Length <= 0)
                    throw new SweetsExeption("Название сладостей не может быть меньше 1 или больше 18 символов");
                else
                    name = value;
            }
        }
        public Sweets()
        {
            this.name = "Без имени";
            this.id = GetHashCode();
        }

        public Sweets(string name)
        {
            this.name = name;
            this.id = GetHashCode();
        }
        public virtual void GetInfo()
        {
            Console.WriteLine($"Название конфет: {name}");
        }

        public string GetType()
        {
            return $"Конфеты";
        }

        public override bool Equals(object obj)
        {
            var item = obj as Sweets;

            if (item == null)
            {
                return false;
            }

            return this.id.Equals(item.id);

        }

        public override int GetHashCode()
        {
            return id.GetHashCode() + 17;
        }

        public override string ToString()
        {
            return $"Тип данного объекта: {GetType()}\n" +
                $"ID: {GetHashCode()}\n" +
                $"Название конфет: {name}";
        }
    }


    public class SweetsExeption : Exception
    {
        public SweetsExeption(string message)
            : base(message)
        { }
    }

    public class CakeExeption : Exception
    {
        public CakeExeption(string message, int diameter)
            : base(message)
        {
            Console.WriteLine($"Вы указали диаметр в {diameter} см");
        }
    }

    public class ClockExeption : Exception
    {
        public ClockExeption(string message, int cost)
            : base(message)
        {
            Console.WriteLine($"Вы указали цену в {cost} у.е.");
        }
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            // Проверка первого конструктора исключений
            Console.WriteLine($"\nПервый конструктор\n");
            try { Sweets p = new Sweets {Name="wkdgsad,mv1389i19rvkovsdfm194"}; } 
            catch (SweetsExeption ex) { Console.WriteLine("Ошибка: " + ex.Message); }
            // Проверка второго конструктора исключений
            Console.WriteLine($"\nВторой конструктор\n");
            try { Cake p = new Cake { name = "Графские развалины", Diameter = 40 }; }
            catch (CakeExeption ex) { Console.WriteLine("Ошибка: " + ex.Message); }
            // Проверка третьего конструктора исключений
            Console.WriteLine($"\nТретий конструктор\n");
            try { Clock p = new Clock { name = "Графские развалины", Cost = 810 }; }
            catch (ClockExeption ex) { Console.WriteLine("Ошибка: " + ex.Message); }
            // Проверка второго конструктора исключений (2)
            Console.WriteLine($"\nВторой конструктор (2)\n");
            try { Cake p = new Cake { name = "Графские развалины", Diameter = -5 }; }
            catch (CakeExeption ex) { Console.WriteLine("Ошибка: " + ex.Message); }
            // Проверка третьего конструктора исключений (2)
            Console.WriteLine($"\nТретий конструктор (2)\n");
            try { Clock p = new Clock { name = "Графские развалины", Cost = 21 }; }
            catch (ClockExeption ex) { Console.WriteLine("Ошибка: " + ex.Message); }
        }
    }
}
