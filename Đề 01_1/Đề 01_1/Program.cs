using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Đề_01_1
{
    internal class Program
    {
        static void CT2()
        {
            try
            {
                using (StreamReader sr = new StreamReader("D:\\dulieu.txt"))
                {
                    while(sr.Peek() >= 0) 
                    {
                        int num = int.Parse(sr.ReadLine());
                        Console.WriteLine("CT2: " + num);
                        if(num % 1024 == 0)
                        {
                            break;
                        }
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        static void Main(string[] args)
        {
            Thread t2 = new Thread(CT2);
            t2.Start();
            t2.Join();
            Console.ReadKey();
        }
    }
}
