using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Đề_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char c = 'a';
            Thread t1 = new Thread(() =>
            {
                do
                {
                    Console.WriteLine("Nhap ki tu: ");
                    try
                    {
                        c = Convert.ToChar(Console.ReadLine());
                        Console.WriteLine("ki tu da nhap " + c);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Nhap lai!");
                    }

                    Thread.Sleep(7);
                } while (!c.Equals('!'));
                Console.WriteLine("End t1");
            });

            Thread t2 = new Thread(() =>
            {
                do
                {
                    Console.Beep();
                    Thread.Sleep(10);
                } while (!c.Equals('!'));
                Console.WriteLine("End t2");
            });

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
            Console.ReadKey();
        }
    }
}
