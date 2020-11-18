using System;
using System.Diagnostics;
using System.Reflection;

namespace lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1
            Console.WriteLine($"Задание 1");
            foreach (Process proc in Process.GetProcesses())
            {
                Console.WriteLine($"Запущенный процесс имеет {proc.Id} - ID, " +
                    $"{proc.ProcessName} - Имя, {proc.BasePriority} - Приоритет, " +
                    $"{proc.Responding} - текущее состояние"
                );
            }

            // Задание 2
            Console.WriteLine($"Задание 2");
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Имя: {domain.FriendlyName}, Директория: {domain.BaseDirectory}");
            Console.WriteLine($"Все сборки:");
            foreach ( Assembly el in domain.GetAssemblies())
            {
                Console.WriteLine($"Имя сборки: {el.GetName().Name}");
            }
            //создание и настройка домена
            Assembly[] assembly = domain.GetAssemblies();
            AppDomain newDomain = AppDomain.CreateDomain("NewDomain");//создаем новый домен
            newDomain.Load(assembly[1].GetName().Name);//получаем имя сборки
            AppDomain.Unload(newDomain);
        }
    }
}
