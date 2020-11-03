using System;
using System.Collections.Generic;
using System.Dynamic;

namespace lab11
{


    class Product
    {
        public partial class Prod
        {
            public int sos = 5;
        }

        public Product product;

        private const string ourCompany = "Lesha Inc.";

        private readonly int id;

        static int countW = 0;

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
                return cost; //
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
                }
                else
                {
                    Console.WriteLine($"Количество товара \"{productName}\" на складе не может быть меньше нуля!");
                }


            }
        }

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
        public Product()
        { // 1 конструктор (без параметров)
            countW++;
            productName = "Неизвестно";
            productProducer = "Неизвестно";
            cost = 0;
            upc = 000000;
            expirationDate = new DateTime(2020, 01, 01);
            amount = 0;
            id = GetHashCode();
        }

        public Product(string productName = "Неизвестно", string productProducer = "Неизвестно", float cost = 0)
        { // 2 конструктор
            countW++;

            this.productName = productName;
            this.productProducer = productProducer;
            this.cost = cost;
            upc = 000000;
            expirationDate = new DateTime(2020, 01, 01);
            amount = 0;
            id = GetHashCode();
        }

        public Product(string productName, string productProducer, float cost, int upc, DateTime expirationDate, int amount)
        { // 3 конструктор (с параметрами)
            countW++;
            this.productName = productName;
            this.productProducer = productProducer;
            this.cost = cost;
            this.upc = upc;
            this.expirationDate = expirationDate;
            this.amount = amount;
            id = GetHashCode();
        }
        override public string ToString()
        {
            return $"ID продукта: {id}" +
                $"\nUPC: {upc}" +
                $"\nНазвание продукта: {productName}" +
                $"\nПроизводитель продукта: {productProducer}" +
                $"\nЦена продукта: {cost}" +
                $"\nСрок хранения: до {expirationDate}" +
                $"\nКоличество продуктов на складе: {amount}";
        }

        public override int GetHashCode()
        {
            return Math.Abs(upc.GetHashCode() + productName.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Product m = obj as Product; // возвращает null если объект нельзя привести к типу Money
            if (m as Product == null)
                return false;

            return m.id == this.id && m.productName == this.productName;
        }

        public void GetInfo()
        {
            Console.WriteLine(
                $"\nID продукта: {id}" +
                $"\nUPC: {upc}" +
                $"\nНазвание продукта: {productName}" +
                $"\nПроизводитель продукта: {productProducer}" +
                $"\nЦена продукта: {cost}" +
                $"\nСрок хранения: до {expirationDate}" +
                $"\nКоличество продуктов на складе: {amount}\n\n");
        }
        public static void ObjectCount()
        {
            Console.WriteLine($"\nКоличество созданных объектов: {countW}");
        }
        public void TestMethod1(int param)
        {
            param++;
            Console.WriteLine($"Значение переменной param в методе testMethod1 = {param}");
        }

        public void TestMethod2(ref int param)
        {
            param++;
            Console.WriteLine($"Значение переменной param в методе testMethod2 = {param}");
        }
        public void TestMethod3(out int param)
        {
            param = 10;
            Console.WriteLine($"Значение переменной param в методе testMethod2 = {param}");
        }
    }

}
