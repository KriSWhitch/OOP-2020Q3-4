using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    static class MyReflector
    {
        public static void ClassInformationToFile(object inputClass) // выводит всё содержимое класса в текстовый файл
        {
            using (StreamWriter stream = new StreamWriter(@"log.txt", false))
            {
                var type = inputClass.GetType(); // получаем тип класса
                var name = type.Name; // получаем имя класса
                var fields = type.GetFields(); // получаем массив имён полей класса
                var assembly = type.Assembly; // получаем название сборки
                var constructors = type.GetConstructors(); // получаем список конструкторов
                var properties = type.GetProperties(); // получаем массив публичных свойств класса
                var interfaces = type.GetInterfaces(); // получаем массив реализованных классом интерфейсов

                stream.WriteLine($"Название класса: {name.ToString()}");
                stream.WriteLine($"Имя сборки: {assembly.ToString()}");

                stream.WriteLine($"В классе {constructors.Length} публичных конструкторов");

                stream.WriteLine("Имена публичных свойств: ");
                foreach (var item in properties)
                {
                    stream.WriteLine(item.Name);
                }

                stream.WriteLine("Имена публичных полей: ");
                foreach (var item in fields)
                {
                    stream.WriteLine(item.Name);
                }

                stream.WriteLine("Реализованные интерфейсы: ");
                foreach (var item in interfaces)
                {
                    stream.WriteLine(item.Name);
                }
            }


        }

        public static void GetClassMethods(string className, string typeOfParam) // выводит по имени класса имена методов, которые содержат заданный(пользователем) тип параметра(имя класса передается в качестве аргумента)
        {
            var type = Type.GetType(className); // получаем тип класса
            var param = Type.GetType(typeOfParam); // получаем тип параметра

            if (param != null)
            {
                var request = type.GetMethods().Where(i => i.GetParameters().Any(item => item.ParameterType == param)); // запрос по которому мы получаем необходимые методы

                if (request.Count() > 0)
                {
                    Console.WriteLine($"Найденные методы:");
                    foreach(var item in request)
                    {
                        Console.WriteLine(item.Name);
                    }
                }
                else
                {
                    Console.WriteLine("Методы с заданным парметром не найдены");
                }
            }
            else
            {
                Console.WriteLine("Не найдено");
            }
        }

        public static void CallMethod(object inputClass, string methodName) // вызывает некоторый метод класса, при этом значения для его параметров необходимо прочитать из текстового файла
        {
            var type = inputClass.GetType();
            var method = type.GetMethod(methodName);
            var parameterInformation = method.GetParameters();
            object[] paramFromFile = new object[1];

            using (StreamReader stream = new StreamReader(@"Initialization.txt"))
            {
                paramFromFile[0] = Int32.Parse(stream.ReadLine());
            }

            if (parameterInformation.Length == 1) // если у нас в функция принимает один параметр
            {
                method.Invoke(inputClass, paramFromFile);  // вызывем найденный у inputClass метод и передаем ему значение

            }
        }

    }

}
