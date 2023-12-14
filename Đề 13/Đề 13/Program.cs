using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Đề_13
{
    internal class Program
    {
        static object locker = new object();
        static Random random = new Random();

        static void CT1()
        {
            while (true)
            {
                int randomNumber = random.Next();
                lock (locker)
                {
                    File.WriteAllText("vd.dat", randomNumber.ToString());
                }
                Thread.Sleep(10);
            }
        }

        static void CT2()
        {
            while (true)
            {
                string content;
                lock (locker)
                {
                    content = File.ReadAllText("vd.dat");
                }

                int number;
                if (int.TryParse(content, out number))
                {
                    Console.WriteLine("So nguyen duoc doc tu file: " + number);
                }
                Thread.Sleep(5);
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
        }
    }
}
