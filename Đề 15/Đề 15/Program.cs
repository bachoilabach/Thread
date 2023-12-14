using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Đề_15
{
    internal class Program
    {
        static int[] a;
        static int[] b;

        static bool done = false;

        static void CT1()
        {

            try
            {
                Console.WriteLine("Nhap so phan tu cua mang a: ");
                int n = int.Parse(Console.ReadLine());
                if (n <= 0 || n > 10)
                {
                    return;
                }
                a = new int[n];

                Console.WriteLine("Nhap mang: ");
                for (int i = 0; i < n; i++)
                {
                    a[i] = int.Parse(Console.ReadLine());
                }
                done = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Nhap lai!");
            }

        }

        static void CT2()
        {
            while (!done)
            {
                Thread.Sleep(1000);
            }
            try
            {
                Random rd = new Random();
                int n = rd.Next(1, 11);
                b = new int[n];

                Console.WriteLine("So phan tu cua b la: " + n);
                Console.WriteLine("Mang b: ");
                for (int i = 0; i < n; i++)
                {
                    b[i] = rd.Next();
                    Console.WriteLine(b[i] + " ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
