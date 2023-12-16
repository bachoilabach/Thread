using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Đề_18
{
    internal class Program
    {
        static Queue<int> Queue = new Queue<int>();
        static bool done = false;

        static int a = 0;
        static void CT1()
        {
            do
            {
                try
                {
                    Console.WriteLine("Nhap mot so nguyen: ");
                    a = int.Parse(Console.ReadLine());
                    if (a >= 0)
                    {
                        Queue.Enqueue(a);
                    }
                    else
                    {
                        done = true;
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Nhap lai!");
                }

            } while (true);
        }
        static void CT2()
        {
            while (!done)
            {
                Thread.Sleep(1000);
            }
            Console.WriteLine("Mang so nguyen vua nhap la: ");
            foreach (var item in Queue)
            {
                Console.WriteLine(item.ToString() + " ");
            }
            done = false;
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(CT1);
            Thread t2 = new Thread(CT2);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
            Console.ReadKey();

        }
    }
}
