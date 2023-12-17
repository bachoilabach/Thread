using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Đề_1
{
    internal class Program
    {
        static void de1()
        {
            List<string> kq =new List<string>();
            bool done = false;

            Thread t1 = new Thread(() =>
            {
                if (!done)
                {
                    StreamReader sr = new StreamReader("D:\\vd.txt");

                    Console.WriteLine("Doc file: ");
                    while(sr.Peek()>= 0)
                    {
                        char rs = (char)sr.Read();
                        if (char.IsWhiteSpace(rs)) continue;

                        var item = Convert.ToInt32(rs).ToString("X");

                        kq.Add(item);
                        Console.Write(item+ " ");
                    }
                }
                Console.WriteLine("\n end t1");
                done = true;
            });

            Thread t2 = new Thread(() =>
            {
                if (done)
                {
                    while (true)
                    {
                        Console.WriteLine("\n Ct2: " + kq.Count());
                        foreach (var item in kq)
                        {
                            Console.Write(item+ " ");
                        }
                        break;
                    }
                    done = false;
                }
            });

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }
        static void Main(string[] args)
        {
            de1();
            Console.ReadKey();
        }
    }
}
