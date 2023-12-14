using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//Đề 12
namespace Đề_3
{
    internal class Program
    {
        static ConsoleKeyInfo ConsoleKeyInfo = new ConsoleKeyInfo();
        static bool pause = false;
        static bool done = false;
        static Queue<ConsoleKeyInfo> queue = new Queue<ConsoleKeyInfo>();

        static void CT1()
        {
            while (!pause)
            {
                if (!pause && !done)
                {
                    Console.WriteLine("\nNhap ki tu: ");
                    ConsoleKeyInfo = Console.ReadKey();

                    if (ConsoleKeyInfo.Key == ConsoleKey.Escape) pause = true;
                    queue.Enqueue(ConsoleKeyInfo);
                    done = true;
                }
            }
            Console.WriteLine("End t1");
        }

        static void CT2()
        {
            while (!pause)
            {
                if (done)
                {
                    Console.WriteLine("\nKi tu da nhap: ");
                    foreach (var item in queue)
                    {
                        Console.Write(item.Key.ToString() + " ");
                    }
                    done = false;
                }
            }
        }
        static void Main(string[] args)
        {
            var t1 = new Thread(CT1);
            var t2 = new Thread(CT2);
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.ReadKey();
        }
    }
}
