using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace lab16
{

    public static class Methods
    {

        private const long maxNum = 100000;

        // прервать выполняемую задачу.

        private static CancellationTokenSource source = new CancellationTokenSource();

        private static CancellationToken token = source.Token;  // получаем сам токен
                                                                //Чтобы отменить операцию, необходимо вызвать метод Cancel() 

        //поиск простых чисел
        public static void SimpleNumberSearch()
        {
            for (long i = 2; i <= maxNum; i++)
            {
                if (AreSimple(i)); //вызываем метод и передаем туда числа от 2 до 100.000
                // Some actions
                //Console.Write(i + ", ");
                if (token.IsCancellationRequested)  // true, если для данного токена есть запрос на отмену т
                {

                    Console.WriteLine("See you soon\n"); //увидимся скоро
                    return;
                }
            }
        }

        private static bool AreSimple(long num)
        {
            // простое число или нет проверяем не делитсья ли 
            // Число на числа до его половины
            for (long i = 2; i <= (num / 2); i++)
                if (num % i == 0)
                    return false;
            return true;
        }


        public static void Task1()
        {
            int itaration = 3;
            //создаем объект стопвоч у которого есть св-ва и методы чтобы измерять время за которое тот или иной метод(или задача) выполнилась
            Stopwatch stopwatch = new Stopwatch();
            while (itaration > 0)
            {
                stopwatch.Start(); //запускаем измерение времени
                Task task = Task.Factory.StartNew(SimpleNumberSearch); //таким пособом мы запускаем выолнение задачи(метода SimpleNumberSearch)
                Console.WriteLine($"Task {itaration} id: {task.Id.ToString()}");  //идентификатор задачи
                Console.WriteLine($"Task {itaration} status: {task.Status.ToString()}"); //статус задачи
                task.Wait(); //ожидаем завершение выполнение задачи
                stopwatch.Stop();//останавливаем таймер который измерял время выполнеине
                Console.WriteLine($"Time for task {itaration}: {stopwatch.Elapsed.TotalMilliseconds.ToString()}\n"); //время для задачи 3 2 1  и дальше выводит время в миллисек
                stopwatch.Reset();//обнуляем затраченное время обнуляем таймер
                itaration--;
                Console.WriteLine("--------------------");
            }
            Console.WriteLine("=================================================");
        }
    }

        class Program
    {
        static void Main(string[] args)
        {
            Methods.Task1();
        }
    }
}
