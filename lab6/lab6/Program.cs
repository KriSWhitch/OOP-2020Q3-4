using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace lab6
{

    partial class User
    {
        public string name;
        public int age;
    }

    public class Product
    {
        public string name;
        public int cost;
        public object[] elList;

        public virtual void GetInfo()
        {
            Console.WriteLine($"Название продукта: {name}");
        }


        public Product()
        {
            this.name = "Без имени";
            cost = 0;
        }

        public Product(string name, int cost)
        {
            this.name = name;
            this.cost = cost;
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
                $"Название товара: {name}\n" +
                $"Стоимость товара: {cost}\n";
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

    public class Bookkeeping : Product // 6.3 Класс-контейнер
    {
        

        public Bookkeeping() // Конструктор без параметров
        {

        }



        internal List<Product> _list = new List<Product>(); //созд объект коллекции 



        public Product this[int index] //индексатор
        {
            get //возвращаем значение элемента списка
            {
                return _list[index];
            }
            set //устананавливаем значение для элемента списка с определенным индексом
            {
                _list[index] = value;
            }
        }

        public void Add(Product obj) //добавление элемента
        {
            if (obj == null)//проверка валидности принимаемых значений
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _list.Add(obj);
        }

        public void Remove(Product obj)//удаление элемента
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _list.Remove(obj);
        }

        public void Information()//вывод инфы о объектах коллекции
        {
            Console.WriteLine("Object in collection");
            foreach (var items in _list)
            {
                Console.WriteLine(items.ToString() + " ");
            }
        }





    }

    public static class TestController
    {
        public static void Sum(Bookkeeping obj)
        {
            int sum = 0;
            Console.Write($"Введите название товара для подсчёты суммарной стоимости данных продуктов: ");
            string name = Console.ReadLine();
            foreach (var items in obj._list)
            {
                if (items.name == name) sum += items.cost;
            }
            Console.WriteLine($"Суммарная стоимость продуктов: {sum}\n");
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            // Задание 1

            Console.WriteLine($"\nЗадание 1\n");
            Product.User user1;
            user1.name = "Tom";
            user1.age = 16;
            user1.DisplayInfo();
            Product.Days day1;
            day1 = Product.Days.Monday;
            Console.WriteLine($"day1 = {day1}");

            // Задание 2

            Console.WriteLine($"\nЗадание 2\n");
            User user = new User();
            user.name = "Иван";
            user.age = 16;
            user.weight = 70;
            user.height = 178;
            user.DisplayToScreen();

            // Задание 3

            Console.WriteLine($"\nЗадание 3\n");
            Product pr1 = new Product("Молоко", 500);
            Product pr2 = new Product("Молоко", 1500);
            Product pr3 = new Product("Молоко", 800);
            Bookkeeping bk1 = new Bookkeeping();
            bk1.Add(pr1); bk1.Add(pr2); bk1.Add(pr3);
            bk1.Information();
     
            // Задание 4

            Console.WriteLine($"\nЗадание 4\n");
            TestController.Sum(bk1);



        }



    }

}
