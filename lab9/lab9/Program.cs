using System;

namespace lab9
{

    class Game
    {
        public delegate void GameHandler(string message);
        public event GameHandler EventAttack;
        public event GameHandler EventHeal;

        public string Name { get; private set; }
        public int MaxHealth { get; private set; }
        public int Health { get; private set; }
        public int Attack { get; private set; }


        public Game(string name, int health, int attack)
        {
            Name = name;
            MaxHealth = health;
            Health = health;
            Attack = attack;
        }
        
        public void DoAttack(Game target)
        {
            if (target.Health > 0)
            {
                target.Health -= Attack;
                EventAttack?.Invoke($"{Name} нанёс {Attack} урона, атаковав {target.Name}");   // Вызов события 
                if (target.Health > 0) Console.WriteLine($"У {target.Name} осталось {target.Health} ОЗ");
                else Console.WriteLine($"{target.Name} был убит!");
            } 
            else
            {
                Console.WriteLine($"{target.Name} уже мёртв!");
            }

        }
        public void DoHeal(Game target)
        {

            if (target.Health > 0)
            {
                target.Health += 5;
                EventHeal?.Invoke($"{Name} исцелил {target.Name}, на {5} ОЗ ");   // Вызов события 
                if (target.Health >= target.MaxHealth) 
                { 
                    target.Health = target.MaxHealth;
                    Console.WriteLine($"Кол-во ОЗ {target.Name} достигло максимума!");
                }
                Console.WriteLine($"Теперь у {target.Name} {target.Health} ОЗ");
            }
            else
            {
                Console.WriteLine($"{target.Name} уже мёртв!");
            }


        }


    }


    class Program
    {
        static void Main(string[] args)
        {
            Game hero = new Game("KriSWhitch", 50, 10);
            hero.EventAttack += (message) => Console.WriteLine(message);
            hero.EventHeal += (message) => Console.WriteLine(message);
            Game enemy1 = new Game("Skeleton-1", 15, 5);
            enemy1.EventAttack += (message) => Console.WriteLine(message);
            enemy1.EventHeal += (message) => Console.WriteLine(message);
            Game enemy2 = new Game("Skeleton-2", 15, 5);
            enemy2.EventAttack += (message) => Console.WriteLine(message);
            enemy2.EventHeal += (message) => Console.WriteLine(message);

            hero.DoAttack(enemy1);
            enemy1.DoAttack(hero);
            enemy2.DoAttack(hero);
            hero.DoAttack(enemy1);
            enemy2.DoAttack(hero);
            hero.DoAttack(enemy2);
            enemy2.DoAttack(hero);
            hero.DoAttack(enemy2);
            hero.DoHeal(hero);
            hero.DoHeal(hero);
            hero.DoHeal(hero);
            hero.DoHeal(hero);

        }
    }
}
