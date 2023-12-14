using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chuoi_ki_tu
{
    internal class Program
    {
        static bool done = false;
        static bool pause = false;
        static ConsoleKeyInfo key = new ConsoleKeyInfo();
        static Queue<ConsoleKeyInfo> C = new Queue<ConsoleKeyInfo>();
        static void CT1()
        {
            while (!pause)
            {
                if (!done && !pause)
                {
                    Console.WriteLine("\nNhap mot ki tu: ");
                    key = Console.ReadKey();
                    C.Enqueue(key);
                    if (key.KeyChar == '!') 
                    {
                        pause = true;
                    }
                    done = true;
                }
            }
        }

        static void CT2()
        {
            while(!pause)
            {
                if (done)
                {
                    Console.WriteLine("Ki tu da nhap la: ");
                    foreach (var item in C)
                    {
                        Console.WriteLine(Convert.ToByte(item.Key));
                    }
                    done = false;
                    Thread.Sleep(1000);
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
