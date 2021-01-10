using System;
using System.Linq;
using System.Collections.Generic;

namespace _3_2
{

    class Location
    {
        public int latDistance;
        public int longDistance;
        public double speed;
    }

    class Taxi
    {
        public string number;
        public Location currentLocation;
        public Status status;
        public enum Status
        {
            Busy,
            Free
        }
        public double Way(int x, int y)
        {
            return Math.Sqrt(Math.Pow((currentLocation.latDistance - x), 2) + Math.Pow((currentLocation.longDistance - y), 2));
        }
    }

    class Park<T>
    {
        public List<T> list = new List<T>();

        public T Find(Predicate<T> predicate)
        {
            foreach(var el in list)
            {
                if (predicate(el))
                {
                    Console.WriteLine("Объект найден!");
                    return el;
                }
            }
            return default(T);
        }

        public void Add(T el)
        {
            list.Add(el);
        }
        public void Delete(T el)
        {
            list.Remove(el);
        }
        public void Clear()
        {
            list.Clear();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var uber = new Park<Taxi>();

            Taxi taxi1 = new Taxi { currentLocation = new Location { latDistance = 5, longDistance = 5, speed = 15 }, number = "Car №1", status = Taxi.Status.Free };
            Taxi taxi2 = new Taxi { currentLocation = new Location { latDistance = 15, longDistance = 5, speed = 25 }, number = "Car №2", status = Taxi.Status.Free };
            Taxi taxi3 = new Taxi { currentLocation = new Location { latDistance = 5, longDistance = 45, speed = 15 }, number = "Car №3", status = Taxi.Status.Busy };
            Taxi taxi4 = new Taxi { currentLocation = new Location { latDistance = 35, longDistance = 10, speed = 20 }, number = "Car №4", status = Taxi.Status.Free };

            uber.Add(taxi1); uber.Add(taxi2); uber.Add(taxi3); uber.Add(taxi4);
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            var linq = from t in uber.list orderby t.Way(x,y) select t;
            foreach (Taxi t in linq)
            {
                Console.WriteLine($"{t.Way(x, y)} тайла от {t.number}");
            }
            var min = linq.Min(el => el.Way(x, y));
            var nearest = linq.FirstOrDefault(el => el.Way(x,y) == min);
            Console.WriteLine($"Такси {nearest.number} самое ближайшее к вызову. От неё до клиента {nearest.Way(x,y)} тайлов");
        }
    }
}
