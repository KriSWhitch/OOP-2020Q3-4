using System;

namespace task3
{
    class Program
    {
        static void Main()
        {

            // Вывод двумерного массива
            //Console.WriteLine("Введите размерность массива");
            //int n = int.Parse(Console.ReadLine());
            //int m = int.Parse(Console.ReadLine());

            //int[,] mass = new int[n, m];

            //for (int i = 0; i < mass.GetLength(0); i++)
            //{
            //    for (int j = 0; j < mass.GetLength(1); j++)
            //    {
            //        Console.Write($"Введите элемент массива - ");
            //        mass[i, j] = int.Parse(Console.ReadLine());
            //    }
            //}

            //for (int i = 0; i < mass.GetLength(0); i++)
            //{
            //    for (int j = 0; j < mass.GetLength(1); j++)
            //    {
            //        Console.Write($" {mass[i, j]}");
            //    }
            //    Console.WriteLine();
            //}



            // Вывод одномерного массива строк
            //Console.WriteLine("Введите размерность массива");
            //int x = int.Parse(Console.ReadLine());
            //string[] mass1 = new string[x];

            //for (int j = 0; j < mass1.GetLength(0); j++)
            //{
            //    Console.Write($"Введите элемент массива - ");
            //    mass1[j] = Console.ReadLine();
            //}

            //for (int i = 0; i < mass1.GetLength(0); i++)
            //{
            //    Console.WriteLine($"Элемент массива №{i} - {mass1[i]}");

            //}

            //Console.WriteLine($"Массив состоит из {mass1.GetLength(0)} элементов");
            //Console.Write($"Введите позицию элемента который вы хотите поменять - ");
            //int x1 = int.Parse(Console.ReadLine());
            //Console.Write($"Введите новое значение этого элемента - ");
            //string x2 = Console.ReadLine();
            //mass1[x1] = x2;
            //for (int i = 0; i < mass1.GetLength(0); i++)
            //{
            //    Console.WriteLine($"Элемент массива №{i} - {mass1[i]}");

            //}



            int i = 0;
            // Объявляем ступенчатый массив
            int[][] myArr = new int[3][];
            myArr[0] = new int[2];
            myArr[1] = new int[3];
            myArr[2] = new int[4];

            // Инициализируем ступенчатый массив
            for (; i < 2; i++)
            {

                myArr[0][i] = i;
                Console.Write("{0}\t", myArr[0][i]);
            }

            Console.WriteLine();
            for (i = 0; i < 3; i++)
            {
                myArr[1][i] = i;
                Console.Write("{0}\t", myArr[1][i]);
            }

            Console.WriteLine();
            for (i = 0; i < 4; i++)
            {
                myArr[2][i] = i;
                Console.Write("{0}\t", myArr[2][i]);
            }



            // Создайте неявно типизированные переменные для хранения массива и строки.

            var array = new object[0];
            var str = "";

        }
    }
}
