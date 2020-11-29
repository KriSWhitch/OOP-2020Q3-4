using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
//using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;


namespace lab14
{
    [Serializable]
    public class Clock : Goods
    {
        public Clock()
        {
            this.name = "Без имени";
        }

        public Clock(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return $"Тип данного объекта: {GetType()}\n" +
                $"ID: {GetHashCode()}\n" +
                $"Название часов: {name}";
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {

            // Задание 1
            Clock cl1 = new Clock { Name = "Часики" };

            // Binary
            BinaryFormatter binf = new BinaryFormatter();
            using (FileStream fs = new FileStream("clocks.dat", FileMode.OpenOrCreate))
            {
                binf.Serialize(fs, cl1);
                Console.WriteLine($"Объект сериализован в Binary");
            }

            using (FileStream fs = new FileStream("clocks.dat", FileMode.OpenOrCreate))
            {
                Clock newCl = (Clock)binf.Deserialize(fs);
                Console.WriteLine($"Объект десериализован\n" +
                    $"Название часов: {newCl.name}");
            }

            // JSON
            using (FileStream fs = new FileStream("clocks.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, cl1);
                Console.WriteLine($"Объект сериализован в JSON");
            }

            using (FileStream fs = new FileStream("clocks.json", FileMode.OpenOrCreate))
            {
                Clock newCl = await JsonSerializer.DeserializeAsync<Clock>(fs);
                Console.WriteLine($"Объект десериализован\n" +
                    $"Название часов: {newCl.name}");
            }

            // XML
            XmlSerializer xmlf = new XmlSerializer(cl1.GetType());
            using (FileStream fs = new FileStream("clocks1.xml", FileMode.OpenOrCreate))
            {
                xmlf.Serialize(fs, cl1);
                Console.WriteLine($"Объект сериализован в XML");
            }

            using (FileStream fs = new FileStream("clocks1.xml", FileMode.OpenOrCreate))
            {
                Clock newCl = (Clock)xmlf.Deserialize(fs);
                Console.WriteLine($"Объект десериализован\n" +
                    $"Название часов: {newCl.name}");
            }

            //// SOAP
            //SoapFormatter soapf = new SoapFormatter();
            //using (FileStream fs = new FileStream("clocks.xml", FileMode.OpenOrCreate))
            //{
            //    soapf.Serialize(fs, cl1);
            //    Console.WriteLine($"Объект сериализован в XML");
            //}

            //using (FileStream fs = new FileStream("clocks.xml", FileMode.OpenOrCreate))
            //{
            //    Clock newCl = (Clock)soapf.Deserialize(fs);
            //    Console.WriteLine($"Объект десериализован\n" +
            //        $"Название часов: {newCl.name}");
            //}

            // Задание 2. Сериализация массива в XML
            Clock[] collection = new Clock[] {new Clock("Rolex"), new Clock("Casio"), new Clock("Q&Q") };
            XmlSerializer xmlf1 = new XmlSerializer(collection.GetType());
            using (FileStream fs = new FileStream("clocks2.xml", FileMode.OpenOrCreate))
            {
                xmlf1.Serialize(fs, collection);
                Console.WriteLine($"Объект сериализован в XML");
            }

            using (FileStream fs = new FileStream("clocks2.xml", FileMode.OpenOrCreate))
            {
                Clock[] newCollection = (Clock[])xmlf1.Deserialize(fs);
                Console.WriteLine($"Объект десериализован\n");
                for (int i = 0; i < newCollection.Length; i++)
                {
                    Console.WriteLine($"Часы №{i+1}: {newCollection[i].Name}");
                }
            }

            // Задание 3. Два селектора для XML документа

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("clocks2.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            // выбор всех дочерних узлов
            XmlNodeList childnodes = xRoot.SelectNodes("//Clock/name");
            Console.WriteLine($"Название часов: ");
            foreach (XmlNode n in childnodes) Console.WriteLine(n.InnerText);

            childnodes = xRoot.SelectNodes("Clock[name='Rolex']");
            Console.WriteLine($"Часы Rolex: ");
            foreach (XmlNode n in childnodes) Console.WriteLine(n.OuterXml);

            // Задание 4 Используя Linq to XML (или Linq to JSON) создан новый xml документ и написано несколько запросов.

            XDocument xdoc = XDocument.Load("clocks2.xml");
            foreach (XElement clockElement in xdoc.Element("ArrayOfClock").Elements("Clock"))
            {
                XElement nameElement = clockElement.Element("name");
                Console.WriteLine($"Часы: {nameElement.Value}");
            }


        }
    }
}
