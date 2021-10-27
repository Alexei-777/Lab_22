using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

//Сформировать массив случайных целых чисел (размер  задается пользователем).
//Вычислить сумму чисел массива и максимальное число в массиве.
//Реализовать  решение  задачи  с  использованием  механизма  задач продолжения.

namespace Lab_22
{
    class Program
    {
        static void Array1(int x)
        {
            int[] array = new int[x];
            int Summ = 0;
            int Max = 0;
            Random random = new Random();

            for (int i = 0; i < x; i++)
            {
                array[i] = random.Next(0, 100);
                Summ += array[i];
                if (Max < array[i]) { Max = array[i]; }
                Console.WriteLine($"Массив 1 элимент {i} = {array[i]}");
                Thread.Sleep(100);
            }
            Console.WriteLine($"Сумма массива 1 = {Summ}");
            Console.WriteLine($"Наибольшее число в массиве 1 = {Max}");
        }
        static int Array2(int x)
        {
            //int x = (int)a;
            int[] array = new int[x];
            int Summ = 0;
            int Max = 0;
            Random random = new Random();

            for (int i = 0; i < x; i++)
            {
                array[i] = random.Next(100, 200);
                Summ += array[i];
                if (Max < array[i]) { Max = array[i]; }
                Console.WriteLine($"Массив 2 элимент {i} = {array[i]}");
                Thread.Sleep(200);
            }
            Console.WriteLine($"Наибольшее число в массиве 2 = {Max}");
            return (Summ);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ввведите глубину массива");
            int x = Convert.ToInt32(Console.ReadLine());

            //Action<object> action1 = new Action<object>(Array1);
            //Task task1 = new Task(action1,a);
            //task1.Start();


            Task task1 = new Task(()=>Array1(x));
            task1.Start();

            //Task task1 = new Task(Array1);
            //task1.Start();

            ////Task task2 = Task.Factory.StartNew(Array2);
            ////task2.Start();

            //Func<int> func2 = new Func<int>(Array2(int x));
            //Task<int> task2 = new Task<int>(func2);

            Task<int> task2 = new Task<int>(()=>Array2(x));
            task2.Start();

            Console.WriteLine($"Сумма массива 2 = {task2.Result}");
            Console.WriteLine("Main закончил :)");
            Console.ReadKey();




        }
    }
}
