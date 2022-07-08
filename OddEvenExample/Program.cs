using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OddEvenExample
{
    class Program
    {
        public static AutoResetEvent _handle1 = new AutoResetEvent(true);
        public static AutoResetEvent _handle2 = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            var t1 = Task.Factory.StartNew(() => PrintOddNumbers());

            var t2 = Task.Factory.StartNew(() => PrintEvenNumbers());

            Task.WaitAny(t1, t2);
           
            Console.WriteLine("End");

            Console.ReadLine();
        }
        static void PrintOddNumbers()

        {

            int[] arr = new int[] { 1, 3, 5, 7, 9, 11, 13, 15 };

            foreach (var item in arr)

            {
                _handle1.WaitOne();
                Console.WriteLine(item);
                //Thread.Sleep(2000);
                _handle2.Set();

            }

        }

        static void PrintEvenNumbers()

        {

            int[] arr = new int[] { 2, 4, 6, 8, 10, 12, 14 };

            foreach (var item in arr)

            {
                _handle2.WaitOne();
                Console.WriteLine(item);
                //Thread.Sleep(2000);
                _handle1.Set();
            }

        }
    }
}
