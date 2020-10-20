using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace lab8
{



    public interface IStr<T>
    where T : struct
    {
        void RemoveFromEnd();
        void AppendToEnd(T value);
        void DisplayListToConsole();
    }

    class List<T> : IStr<T> where T : struct
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
        }
    }
}
