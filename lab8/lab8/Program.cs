using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace lab8
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
            return $"\nТип данного объекта: {GetType()}\n" +
                $"ID: {GetHashCode()}\n" +
                $"Название торта: {name}\n";
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
        public override void GetInfo()
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
            return base.GetHashCode() + 17;
        }

        public override string ToString()
        {
            return $"Тип данного объекта: {GetType()}\n" +
                $"ID: {GetHashCode()}\n" +
                $"Название конфет: {name}";
        }
    }



    // обобщённый интерфейс для задание 1,2 
    public interface IStr<T> 
    {
        void RemoveFromEnd();
        void AppendToEnd(T value);
        void DisplayListToConsole();
    }
    // обобщённый класс для задания 2
    class List<T> : IStr<T>
    {

        public class Owner
        {
            int id;
            string ownerName;
            string ownerOrganization;


            public Owner()
            {
                this.id = GetHashCode();
                this.ownerName = $"Имя неизвестно";
                this.ownerOrganization = $"Название организации неизвестно";
            }

            public Owner(string ownerName, string ownerOrganization)
            {
                this.id = GetHashCode();
                this.ownerName = ownerName;
                this.ownerOrganization = ownerOrganization;
            }

            public void DisplayToConsole()
            {
                Console.WriteLine($"ID: {id}\n" +
                    $"Имя создателя: {ownerName}\n" +
                    $"Название организации: {ownerOrganization}");
            }

        }


        public class Date
        {
            DateTime creationDate = DateTime.Now;

            public void DisplayCreationDateToConsole()
            {
                Console.WriteLine($"Дата создания: {creationDate}");
            }
        }


        public T[] array;

        public List()
        {
            this.array = new T[] { };
        }

        public List(T[] array)
        {
            this.array = array;
        }


        public static bool operator ==(List<T> c1, List<T> c2)
        {
            return c1.array.SequenceEqual(c2.array);
        }

        public static bool operator !=(List<T> c1, List<T> c2)
        {
            return !(c1.array.SequenceEqual(c2.array));
        }

        public static List<T> operator +(List<T> c1, T value)
        {
            c1.AppendToStart(value);
            return c1;
        }

        public static List<T> operator --(List<T> c1)
        {
            c1.RemoveFromStart();
            return c1;
        }

        public static List<T> operator *(List<T> c1, List<T> c2)
        {
            for (int i = 0; i < c2.array.Length; i++) c1.AppendToEnd(c2.array[i]);
            return c1;
        }


        public void DisplayListToConsole()
        {
            if (array.Length == 0)
            {
                Console.WriteLine($"Список пуст!");
                return;
            }

            string result = "(";
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1) result += $"{array[i]}";
                else result += $"{array[i]}, ";

            }
            result += ")";
            Console.WriteLine($"Список: {result}");
        }

        public void IsEmpty()
        {
            if (array.Length == 0)
            {
                Console.WriteLine($"Список пуст!");
            }
            else
            {
                Console.WriteLine($"Список содержит элементы!");
            }
        }

        private void AppendToStart(T value)
        {
            T[] result = new T[array.Length + 1];
            result[0] = value;
            for (int i = 0; i < array.Length; i++)
                result[i + 1] = array[i];

            this.array = result;
        }

        private void RemoveFromStart()
        {
            T[] result = new T[array.Length - 1];
            for (int i = 1; i < array.Length; i++)
                result[i - 1] = array[i];
            this.array = result;
        }

        public void AppendToEnd(T value)
        {
            T[] result = new T[array.Length + 1];
            result[result.Length - 1] = value;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                result[i] = array[i];
            }
            this.array = result;
            if (array.Length > 10) throw new ListException("Вы не можете добавить новые элементы если длина текущего списка превышает или равна 10-ти элементам!");
        }

        public void RemoveFromEnd()
        {
            T[] result = new T[array.Length - 1];
            for (int i = 0; i < array.Length - 1; i++)
                result[i] = array[i];
            this.array = result;
        }


    }

    public class ListException : Exception
    {
        public ListException(string message)
            : base(message)
        { }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Задание 1, 2
            Console.WriteLine($"Задание №1,2");
            try
            {
                int[] MyArrInt = new int[9] { 4, 5, 18, 56, 8, 9, 11, 12, 30 };
                List<int> list1 = new List<int>(MyArrInt);
                list1.DisplayListToConsole();
                list1.AppendToEnd(10); list1.DisplayListToConsole();
                list1.AppendToEnd(17); list1.DisplayListToConsole();
                list1.AppendToEnd(31); list1.DisplayListToConsole();
            } 
            catch (ListException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            finally
            {
                Console.WriteLine($"Задание 1,2 завершено");
            }
            //Задание 3
            Console.WriteLine($"Задание №3");
            List<int> list2 = new List<int>(new int[9] { 4, 1, 11, 56, 81, 9, 411, 12, 308 });
            List<double> list3 = new List<double>(new double[9] { 51, 51, 118, 536, 8, 95, 411, 912, 30 });
            List<int> list4 = new List<int>(new int[9] { 4, 5, 18, 36, 8, 9, 111, 112, 30 });
            List<byte> list5 = new List<byte>(new byte[9] { 4, 5, 184, 56, 81, 9, 114, 41, 30 });
            List<Cake> list6 = new List<Cake>(new Cake[3] { new Cake("Графские развалины"), new Cake("Муравейник"), new Cake("Тортик")});
            list2.DisplayListToConsole();
            list3.DisplayListToConsole();
            list4.DisplayListToConsole();
            list5.DisplayListToConsole();
            list6.DisplayListToConsole();

        }
    }
}
