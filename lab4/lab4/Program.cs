using System;

namespace lab4
{

    class List
    {
        public int[] array;

        public List()
        {
            this.array = new int[] { };
        }

        public List(int[] array)
        {
            this.array = array;
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

        public void AppendToStart(int value)
        {
            int[] result = new int[array.Length + 1];
            result[0] = value;
            for (int i = 0; i < array.Length; i++)
                result[i + 1] = array[i];

            this.array = result;
        }

        public void RemoveFromStart()
        {
            int[] result = new int[array.Length - 1];
            for (int i = 1; i < array.Length; i++)
                result[i-1] = array[i];
            this.array = result;
        }

        public void AppendToEnd(int value)
        {
            int[] result = new int[array.Length + 1];
            result[result.Length - 1] = value;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                result[i] = array[i];
            }
            this.array = result;
        }

        public void RemoveFromEnd()
        {
            int[] result = new int[array.Length - 1];
            for (int i = 0; i < array.Length - 1; i++)
                result[i] = array[i];
            this.array = result;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] {1};
            List fList = new List(array);
            fList.DisplayListToConsole();
            List sList = new List(new int[] {5, 8, 9 });
            sList.DisplayListToConsole();
            List tList = new List();
            tList.DisplayListToConsole();
            tList.AppendToEnd(5);
            tList.DisplayListToConsole();
            tList.AppendToStart(6);
            tList.DisplayListToConsole();
            tList.AppendToEnd(7);
            tList.DisplayListToConsole();
            tList.AppendToStart(7);
            tList.DisplayListToConsole();
            tList.RemoveFromStart();
            tList.DisplayListToConsole();
            tList.RemoveFromEnd();
            tList.DisplayListToConsole();
            tList.RemoveFromEnd();
            tList.DisplayListToConsole();
        }
    }
}
