using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Đề_2
{
    internal class Program
    {
        static bool done = false;
        static bool pause = false;
        static int random = 0;
        static void CT1()
        {
            Random rd = new Random();
            while (true)
            {
                if (!done)
                {
                    random = rd.Next();
                    if(random % 10011 == 0)
                    {
                        pause = true;
                        break;
                    }
                    done = true;
                }
            }
            Console.WriteLine("So chia het cho 10011 la: " + random);
            Console.WriteLine("Het luong 1");
        }
        
        static void CT2()
        {
            while (!pause)
            {
                if (done)
                {
                    if(random % 3 == 0)
                    {
                        Console.WriteLine("So chia het cho 3 la: " + random);
                    }
                    done = false;
                }
            }
            Console.WriteLine("Het luong 2");
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
