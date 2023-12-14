using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Đề_01
{
    internal class Program
    {
        static void CT1()
        {
            var rd = new Random();
            using (StreamWriter sr = new StreamWriter("D:\\dulieu.txt"))
            {
                while (true)
                {
                    try
                    {
                        var num = rd.Next(0, int.MaxValue);
                        sr.WriteLine(num.ToString());
                        Console.WriteLine("CT1: " + num);
                        if (num % 1024 == 0)
                        {
                            Console.WriteLine("So chi het cho 1024 la: " + num); 
                            break;
                        }
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Loi");
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(CT1);
            t1.Start();
            t1.Join();
            Console.ReadKey();
        }
    }
}
