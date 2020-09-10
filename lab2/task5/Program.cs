using System;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива");
            int x = int.Parse(Console.ReadLine());
            int[] mass = new int[x];


            for (int j = 0; j < mass.GetLength(0); j++)
            {
                Console.Write($"Введите элемент массива - ");
                mass[j] = int.Parse(Console.ReadLine());
            }

            Console.Write(strangeFunc( mass, "Hi, Mark!" ));
        }

        public static (int, int, int, char) strangeFunc(int[] array, string str)
        {
            int smallest = array[0];
            for (int i = 0; i < array.GetLength(0); i++) {
                if (array[i] < smallest) {
                    smallest = array[i];
                }
            }
            int largest = array[0];
            for (int i = 0; i < array.GetLength(0); i++) {

                if (array[i] > largest) {
                    largest = array[i];
                }
            }
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++) {
                sum += array[i];
            }
            char[] letters = str.ToCharArray();
            return (largest, smallest, sum, letters[0]);
        }
    }
}
