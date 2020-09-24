using System;
using System.Linq;

namespace lab4
{

    class List
    {
        public string[] array;

        public List()
        {
            this.array = new string[] { };
        }

        public List(string[] array)
        {
            this.array = array;
        }


        public static bool operator ==(List c1, List c2)
        {
            return c1.array.SequenceEqual(c2.array);
        }

        public static bool operator !=(List c1, List c2)
        {
            return !(c1.array.SequenceEqual(c2.array));
        }

        public static List operator +(List c1, string value)
        {
            c1.AppendToStart(value);
            return c1;
        }

        public static List operator --(List c1)
        {
            c1.RemoveFromStart();
            return c1;
        }

        public static List operator *(List c1, List c2)
        {
            for (int i = 0; i < c2.array.Length; i++) c1.AppendToEnd(c2.array[i]);
            return c1;
        }


        public void DisplayListToConsole()
        {
            if (array.Length == 0) {
                Console.WriteLine($"Список пуст!");
                return ;
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
            } else
            {
                Console.WriteLine($"Список содержит элементы!");
            }
        }

        public void RepeatingElements()
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i+1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        Console.WriteLine($"Элемент №{i + 1} совпадает с элементом №{j + 1}");
                    }
                }
                
            }
        }

        public void CapitalizedWords()
        {
            int result = 0;
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i].ToCharArray()[0].ToString() == array[i].ToCharArray()[0].ToString().ToUpper()) result++;
            }
            Console.WriteLine($"{result} слов начинается с большой буквы");
        }

        public void AppendToStart(string value)
        {
            string[] result = new string[array.Length + 1];
            result[0] = value;
            for (int i = 0; i < array.Length; i++)
                result[i + 1] = array[i];

            this.array = result;
        }

        public void RemoveFromStart()
        {
            string[] result = new string[array.Length - 1];
            for (int i = 1; i < array.Length; i++)
                result[i-1] = array[i];
            this.array = result;
        }

        public void AppendToEnd(string value)
        {
            string[] result = new string[array.Length + 1];
            result[result.Length - 1] = value;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                result[i] = array[i];
            }
            this.array = result;
        }

        public void RemoveFromEnd()
        {
            string[] result = new string[array.Length - 1];
            for (int i = 0; i < array.Length - 1; i++)
                result[i] = array[i];
            this.array = result;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] array = new string[] { "1" };
            List fList = new List(array);
            fList.DisplayListToConsole();
            List sList = new List(new string[] { "5", "8", "9" });
            sList.DisplayListToConsole();
            List tList = new List();
            Console.WriteLine(tList != sList); // перегружена операция неравенства
            tList.AppendToEnd("5"); tList.AppendToEnd("8"); tList.AppendToEnd("9");
            Console.WriteLine(tList != sList);
            Console.Write($"Список до использования перегруженной операции \"--\" : ");
            tList.DisplayListToConsole();
            tList--;
            tList.DisplayListToConsole();
            Console.Write($"Список до использования перегруженной операции \"+\" : ");
            tList.DisplayListToConsole();
            List result = tList + "el1";
            result.DisplayListToConsole();
            Console.WriteLine($"Списки до объединения: ");
            sList.DisplayListToConsole();
            tList.DisplayListToConsole();
            Console.WriteLine($"Список после объединения: ");
            result = tList * sList;
            result.DisplayListToConsole();
        }
    }
}
