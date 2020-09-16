using System;

namespace lab3
{

    class Product
    {

        static Product()
        {
            Console.WriteLine($"Был создан объект класса Product!");
            Console.WriteLine($"Наша компания - {ourCompany}!");
            Product Zero = new Product("private");
        }

        private Product(string title)
        {
            Console.WriteLine($"Вызван закрытый конструктор класса, название - {title}");
        }

        private const string ourCompany = "Lesha Inc.";

        private readonly int id;

        private string productName;
        public string ProductName
        {
            get //через свойство set мы инициализируем поля класса, которые пользователь должен вводить, но может пропустить
            {//т.е. в конструкторе мы инициализируем основные поля класса, основу для нашего класса
                return productName; //
            }

            set
            {
                productName = value;//параметр вэлью через него мы передаем объект и сохраняем в массив по индексу             
            }
        }
        private string productProducer;
        public string ProductProducer
        {
            get //через свойство set мы инициализируем поля класса, которые пользователь должен вводить, но может пропустить
            {//т.е. в конструкторе мы инициализируем основные поля класса, основу для нашего класса
                return productProducer; //
            }

            set
            {
                productProducer = value;//параметр вэлью через него мы передаем объект и сохраняем в массив по индексу             
            }
        }
        private float cost;
        public float Cost
        {
            get //через свойство set мы инициализируем поля класса, которые пользователь должен вводить, но может пропустить
            {//т.е. в конструкторе мы инициализируем основные поля класса, основу для нашего класса
                return amount; //
            }

            set
            {
                if (value >= 0)
                {
                    cost = value;//параметр вэлью через него мы передаем объект и сохраняем в массив по индексу
                }
                else
                {
                    Console.WriteLine($"Цена товара \"{productName}\" не может быть меньше нуля!");
                }


            }
        }
        private int upc;
        public int Upc
        {
            get //через свойство set мы инициализируем поля класса, которые пользователь должен вводить, но может пропустить
            {//т.е. в конструкторе мы инициализируем основные поля класса, основу для нашего класса
                return upc; //
            }

            set
            {
                upc = value;//параметр вэлью через него мы передаем объект и сохраняем в массив по индексу             
            }
        }
        private DateTime expirationDate;
        public DateTime ExpirationDate
        {
            get //через свойство set мы инициализируем поля класса, которые пользователь должен вводить, но может пропустить
            {//т.е. в конструкторе мы инициализируем основные поля класса, основу для нашего класса
                return expirationDate; //
            }

            protected set // ограниченный доступ к set
            {
                expirationDate = value;//параметр вэлью через него мы передаем объект и сохраняем в массив по индексу             
            }
        }
        private int amount;

        public int Amount
        {
            get //через свойство set мы инициализируем поля класса, которые пользователь должен вводить, но может пропустить
            {//т.е. в конструкторе мы инициализируем основные поля класса, основу для нашего класса
                return amount; //
            }

            set
            {
                if (value >= 0)
                {
                    amount = value;//параметр вэлью через него мы передаем объект и сохраняем в массив по индексу
                } else
                {
                    Console.WriteLine($"Количество товара \"{productName}\" на складе не может быть меньше нуля!");
                }
                

            }
        }

        public Product()
        { // 1 конструктор (без параметров)
            id = GetHashCode(); 
            productName = "Неизвестно";
            productProducer = "Неизвестно";
            cost = 0;
            upc = 000000;
            expirationDate = new DateTime(2020, 01, 01);
            amount = 0;
        }      

        public Product(string productName = "Неизвестно", string productProducer = "Неизвестно", float cost = 0)
        { // 2 конструктор
            id = GetHashCode();
            this.productName = productName;
            this.productProducer = productProducer;
            this.cost = cost;
            upc = 000000;
            expirationDate = new DateTime(2020, 01, 01);
            amount = 0;
        }         

        public Product(string productName, string productProducer, float cost, int upc, DateTime expirationDate, int amount)
        { // 3 конструктор (с параметрами)
            id = GetHashCode();
            this.productName = productName;
            this.productProducer = productProducer;
            this.cost = cost;
            this.upc = upc;
            this.expirationDate = expirationDate;
            this.amount = amount;
        }


        public void GetInfo()
        {
            Console.WriteLine(
                $"ID продукта: {id}" +
                $"\nUPC: {upc}" +
                $"\nНазвание продукта: {productName}" +
                $"\nПроизводитель продукта: {productProducer}" +
                $"\nЦена продукта: {cost}" +
                $"\nСрок хранения: до {expirationDate}" +
                $"\nКоличество продуктов на складе: {amount}");
        }
        public void testMethod1(int param)
        {
            param++;
            Console.WriteLine($"Значение переменной param в методе testMethod1 = {param}");
        }

        public void testMethod2(ref int param)
        {
            param++;
            Console.WriteLine($"Значение переменной param в методе testMethod2 = {param}");
        }
        public void testMethod3(out int param)
        {
            param = 10;
            Console.WriteLine($"Значение переменной param в методе testMethod2 = {param}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product pr1 = new Product(); // конструктор по умолчанию
            pr1.GetInfo();
            Product pr2 = new Product("Молоко", "Савушкин", 500); // конструктор с параметрами
            pr2.GetInfo();
            DateTime date1 = new DateTime(2001, 12, 27);
            Product pr3 = new Product("Молоко", "Савушкин", 500, 111403, date1, 100); // конструктор c параметрами
            pr3.GetInfo();
            Product pr4 = new Product("Молоко", "Савушкин", 500, 431413, date1, 0); // конструктор c параметрами
            pr4.Amount = -1; //set
            int pr4Amount = pr4.Amount; //get
            Console.WriteLine(pr4Amount);
            int param = 10;
            pr4.testMethod1(param); // передаём значение, функция работает с копией этого значения
            Console.WriteLine($"Переменная param = {param}");
            pr4.testMethod2(ref param); // передаём значение по ссылке
            Console.WriteLine($"Переменная param = {param}");
            int param1;
            pr4.testMethod3(out param1); // инициализируем переменную в функции, передаём неинициализированную переменную
            Console.WriteLine($"Переменная param1 = {param1}");
        }
    }
}
