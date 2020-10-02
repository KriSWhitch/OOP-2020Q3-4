using System;
using System.Linq;

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

    class Cake : Pastry {
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

        public override string ToString()
        {
            return $"Тип данного объекта: {GetType()}\n" +
                $"ID: {GetHashCode()}\n" +
                $"Название конфет: {name}";
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
    //

    class Printer
    {
        public void IAmPrinting(object someObj)
        {
            Console.WriteLine($"Тип объекта ( из IAmPrinting): {someObj.GetType()}\n" +
                $"Использование ToString этого объекта: \n{someObj.ToString()}\n");
        }
    }

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
            Clock s2 = new Clock("Rolex");
            Cake s3 = new Cake("Графские развалины");
            object[] testArray = new object[] { s1, s2, s3 };
            Printer p1 = new Printer();
            for (int i = 0; i < testArray.Length; i++)
            {
                p1.IAmPrinting(testArray[i]);
            }
        }
        

        
    }

}
