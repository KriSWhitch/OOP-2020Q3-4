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

        public static void Task2()
        {//у нас есть возможность отмны этой задачи во время ее выполнения
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Task task = Task.Factory.StartNew(SimpleNumberSearch);
            Console.WriteLine($"Task id: {task.Id.ToString()}");
            Console.WriteLine($"Task status: {task.Status.ToString()}");

            Console.WriteLine("Press q - to exit from task"); //нажми q чтоб выйти из задачи
            if (Console.ReadKey().KeyChar == 'q')
            {//Чтобы отменить операцию, необходимо вызвать метод Cancel() у объекта CancellationTokenSource:
                source.Cancel();
            }

            task.Wait(); // таймер будет все время ждать пока q не нажмем
            stopwatch.Stop();
            Console.WriteLine($"Time for task: {stopwatch.Elapsed.TotalMilliseconds.ToString()}\n");
            Console.WriteLine("=================================================");
        }

        // Methods by formula: m = Vq, where q - density, V - capacity
        const int capacity = 100;
        const int density = 1000;
        const int weight = 6000;

        public static int GetWeight() => capacity * density;
        public static int GetDensity() => weight / capacity;
        public static int GetCapacity() => weight / density;

        public static async void Task3_4Asinc()
        {//. Создайте три задачи с возвратом результата и используйте их для
            //выполнения четвертой задачи.Например, расчет по формуле.
            Task<int> task1 = Task.Factory.StartNew(GetWeight); //вызывваем все три задачи в отдельных (асинхронных)задачах
            Task<int> task2 = Task.Factory.StartNew(GetDensity);
            Task<int> task3 = Task.Factory.StartNew(GetCapacity);
            //await значит выполнение асинхронной операции
            //4. Создайте задачу продолжения (continuation task) в двух вариантах:
            // C ContinueWith -планировка на основе завершения множества
            //предшествующих задач

            await task1.ContinueWith((firstTask) => Console.WriteLine($"First task result: {firstTask.Result}")); //выводим на консоль результат после того как задача task1 завершила свою работу
            await task2.ContinueWith((secondTask) => Console.WriteLine($"Second task result: {secondTask.Result}"));
            await task3.ContinueWith((thirdTask) => Console.WriteLine($"Third task result: {thirdTask.Result}"));

            task3.ContinueWith((thirdTask) => Console.WriteLine($"Third task result with GetAwaiter(): {thirdTask.Result}")).GetAwaiter();
            task2.ContinueWith((secondTask) => Console.WriteLine($"Second task result with GetAwaiter().GetResult(): {secondTask.Result}")).GetAwaiter().GetResult();
            //getresult прекращает ожидание завершение асинхронной задачи
            Console.WriteLine("================================================\n");
        }

        public static void Task5()
        {
            const int arrSize = 1000000;
            const int arrCount = 10;
            Stopwatch stopwatch = Stopwatch.StartNew();//начинаем считать время
            Parallel.For(0, arrCount, (Count) => //параллельный цикл фор от 0 до arrCount дальше (создаем 11 массивов размером ArrSize)
            {
                int[] arr = new int[arrSize];
                Parallel.ForEach(arr, (el) => //цикл форич где первый параметр коллекция которую перебираем а второй параметр функция анонимная(выполняется для каждой итерации)
                {
                    el = arrCount * arrCount;
                });
            });
            stopwatch.Stop();//остановили таймер
            Console.WriteLine("Time with Parallel.For, Parallel.ForEach: " + stopwatch.Elapsed.Milliseconds.ToString()); //результаты в милисек
            stopwatch.Restart();//сбросили таймер и запустили его снова
            for (int i = 0; i < arrCount; i++)
            {// Оцените производительность по сравнению с обычными циклами
                int[] arr = new int[arrSize];
                for (int j = 0; j < arr.Length; j++) arr[j] = arrCount * arrCount;
            }
            stopwatch.Stop();
            Console.WriteLine("Time with two for operators: " + stopwatch.Elapsed.Milliseconds.ToString());
            Console.WriteLine("===============================================\n");
        }

        public static void Task6()
        {
            Parallel.Invoke(Task6Handler, Task6Handler, Task6Handler); //выполняем все 3 задачи в парралельном режиме
            Console.WriteLine("===============================================\n");
        }
        private static void Task6Handler()
        {
            int[] arr = new int[100000];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = i * i;
            Console.WriteLine("Task complete with Parallel.Invoke\n");
        }

    }

        class Program
    {
        static void Main(string[] args)
        {
            //Methods.Task1();
            //Methods.Task2();
            Methods.Task3_4Asinc();
            Methods.Task5();
            Methods.Task6();

            Console.WriteLine("Complete");
            Console.ReadKey();
        }
    }
}
