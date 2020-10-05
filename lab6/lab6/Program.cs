using System;
using System.Linq;

namespace lab6
{

    abstract class Product
    {
        public string name;
        public object[] elList;

        public virtual void GetInfo()
        {
            Console.WriteLine($"Название продукта: {name}");
        }


        public Product()
        {
            this.name = "Без имени";
        }

        public Product(string name)
        {
            this.name = name;
        }


        public enum Days
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6,
            Sunday = 7
        }

        public struct User
        {
            public string name;
            public int age;

            public void DisplayInfo()
            {
                Console.WriteLine($"Name: {name}  Age: {age}");
            }
        }

        public void DisplayListToConsole()
        {
            if (elList.Length == 0)
            {
                Console.WriteLine($"Список пуст!");
                return;
            }

            string result = "(";
            for (int i = 0; i < elList.Length; i++)
            {
                if (i == elList.Length - 1) result += $"{elList[i]}";
                else result += $"{elList[i]}, ";

            }
            result += ")";
            Console.WriteLine($"Список: {result}");
        }
        public override string ToString()
        {
            return $"Тип данного объекта: {GetType()}\n" +
                $"ID: {GetHashCode()}\n" +
                $"";
        }
    }

    class Pastry : Product
    {

        public override string ToString()
        {
            return $"Тип данного объекта: {GetType()}\n" +
                $"ID: {GetHashCode()}\n" +
                $"";
        }
    }

    class Goods : Product
    {

        public override string ToString()
        {
            return $"Тип данного объекта: {GetType()}\n" +
                $"ID: {GetHashCode()}\n" +
                $"";
        }
    }

    class Flowers : Goods
    {
        public Flowers()
        {
            this.name = "Без имени";
        }

        public Flowers(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return $"Тип данного объекта: {GetType()}\n" +
                $"ID: {GetHashCode()}\n" +
                $"Название цветов: {name}";
        }
    }

    class Cake : Pastry
    {
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

    class Clock : Goods
    {
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

    class Sweets : Goods
    {
        int id;

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


    interface IMovable
    {
        public void GetInfo()
        {
            Console.WriteLine("Hi!");
        }
    }

    abstract class Move
    {
        public abstract void GetInfo();

        public override string ToString()
        {
            return $"Тип данного объекта: {GetType()}\n" +
                $"ID: {GetHashCode()}\n" +
                $"";
        }
    }

    class Run : Move, IMovable
    {

        void IMovable.GetInfo()
        {
            Console.WriteLine("Oh, hi Mark! from Interface");
        }

        public override void GetInfo()
        {
            Console.WriteLine("Oh, hi Mark! from Abstract Class");
        }

        public override string ToString()
        {
            return $"Тип данного объекта: {GetType()}\n" +
                $"ID: {GetHashCode()}\n" +
                $"";
        }
    }

    class Printer
    {
        public void IAmPrinting(object someObj)
        {
            Console.WriteLine($"Тип объекта ( из IAmPrinting): {someObj.GetType()}\n" +
                $"Использование ToString этого объекта: \n{someObj.ToString()}\n");
        }
    }

    sealed class Root  // от этого класса нельзя наследовать
    {

    }

    class Program
    {
        //Продукт, Кондитерское изделие, Товар, Цветы, Торт, Часы, Конфеты;

        static void Main(string[] args)
        {
            // Задание 1
            Console.WriteLine($"Задание 1");
            Product.User user1;
            user1.name = "Tom";
            user1.age = 16;
            user1.DisplayInfo();
            Product.Days day1;
            day1 = Product.Days.Monday;
            Console.WriteLine($"day1 = {day1}");
            // Задание 2
            Console.WriteLine($"Задание 2");

            // Задание 3
            Console.WriteLine($"Задание 3");

            // Задание 4
            Console.WriteLine($"Задание 4");

        }



    }

}
