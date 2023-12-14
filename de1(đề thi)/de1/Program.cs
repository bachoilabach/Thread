using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace de1
{
    internal class Program
    {
        static void CT1()
        {
            using (StreamWriter file = new StreamWriter("D:\\vidu.txt"))
            {
                char input;
                do
                {
                    Console.WriteLine("    Nhap mot ki tu: ");
                    input = Console.ReadKey().KeyChar;
                    file.Write(input);
                } while (input != '#');
            }
        }

        
        static void Main(string[] args)
        {
            var t1 = new Thread(CT1);
            
            t1.Start();
            
            t1.Join();
            
            Console.ReadKey();
        }
    }
}
