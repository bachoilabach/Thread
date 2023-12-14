using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Đề_05_1
{
    internal class Program
    {
        static void DocFai()
        {
            while (true)
            {
                try
                {
                    using (StreamReader sr = new StreamReader("D:\\dulieu.txt"))
                    {
                        while(sr.Peek() >= 0)
                        {
                            int a = sr.Read();
                            char c = (char)a;
                            Console.WriteLine("Ki tu trong file: " + c);
                            if(a == '!')
                            {
                                Console.WriteLine("Het");
                                break;
                            }
                            Thread.Sleep(1000);
                        }
                    }
                    break;
                }catch (Exception ex)
                {
                    Console.WriteLine("Dang cho ghi file");
                }
            }
        }
        static void Main(string[] args)
        {
            var t2 = new Thread(DocFai);
            t2.Start();
            t2.Join();
            Console.ReadKey();
        }
    }
}
