using System;

namespace lab5
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


        public void AppendToEnd(object value)
        {
            object[] result = new object[elList.Length + 1];
            result[result.Length - 1] = value;
            for (int i = elList.Length - 1; i >= 0; i--)
            {
                result[i] = elList[i];
            }
            this.elList = result;
        }

        public void RemoveFromEnd()
        {
            object[] result = new object[elList.Length - 1];
            for (int i = 0; i < elList.Length - 1; i++)
                result[i] = elList[i];
            this.elList = result;
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
    }

    class Pastry : Product
    {
        
    }

    class Goods : Product
    {
        
    }

    class Flowers : Goods
    {
        
    }

    class Cake : Pastry {
        
    }

    class Clock : Goods
    {

    }

    class Sweets : Goods
    {
        public Sweets()
        {
            this.name = "Без имени";
        }

        public Sweets(string name)
        {
            this.name = name;
        }
        public virtual void GetInfo()
        {
            Console.WriteLine($"Название конфет: {name}");
        }
    }


    //Задание 4
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
    }
    //


    class Program
    {
        //Продукт, Кондитерское изделие, Товар, Цветы, Торт, Часы, Конфеты;

        static void Main(string[] args)
        {
            Sweets s1 = new Sweets("Алёнка");
            s1.GetInfo();
            // Задание 4
            Run m1 = new Run();
            m1.GetInfo();
            IMovable m2 = new Run();
            m2.GetInfo();
        }
        

        
    }

}
