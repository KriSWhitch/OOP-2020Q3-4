using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    partial class User
    {
        public int height;
        public int weight;

        public User()
        {
            name = "Неизвестно";
            age = 0;
            height = 0;
            weight = 0;
        }

        public void DisplayToScreen() {
            Console.WriteLine($"Имя: {name}\n" +
                $"Возраст: {age}\n" +
                $"Рост: {height} см\n" +
                $"Вес: {weight} кг");
        }
        
    }
}
