using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Đề_thi_mới
{
    internal class Program
    {
        static string str = "";
        static bool t = false;
        static void nhap()
        {
            do
            {
                Console.WriteLine("Nhap mot sau ki tu: ");
                str = Console.ReadLine();
            } while (str!="quit");
        }

        static void xuat()
        {
            while (str != "quit")
            {
                Console.WriteLine("CT2: " + str);
                Thread.Sleep(1500);
            }
        }
        static void Main(string[] args)
        {
            var t1 = new Thread(nhap);
            var t2 = new Thread(xuat);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.ReadKey();
        }
    }
}
