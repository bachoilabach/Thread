using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Đề_05
{
    internal class Program
    {
        static void GhiFai()
        {
            using (StreamWriter sw = new StreamWriter("D:\\dulieu.txt"))
            {
                char input;
                do
                {
                    Console.WriteLine("Nhap mot ki tu: ");
                    input = Console.ReadKey().KeyChar;
                    sw.Write(input);
                } while (input != '!');
            }
        }
        static void Main(string[] args)
        {
            var t1 = new Thread(GhiFai);
            t1.Start();
            t1.Join();
            Console.ReadKey();
        }
    }
}
