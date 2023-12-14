using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace de1_1
{
    internal class Program
    {
        static void CT2()
        {
            int countA = 0;
            while (true)
            {
                try
                {

                    using (StreamReader sr = new StreamReader("D:\\vidu.txt"))
                    {
                        while (sr.Peek() >= 0)
                        {

                            int charVal = sr.Read();
                            Console.WriteLine(charVal);
                            if (charVal < 0)
                            {
                                break;
                            }

                            char character = (char)charVal;
                            Console.WriteLine("Tung ki tu la: " + character);
                            var item = Convert.ToByte(character);
                            Console.WriteLine("Ma hexa cua ki tu la: " + item);

                            if (character == 'A')
                            {
                                countA++;
                            }

                        }
                        Console.WriteLine("So luong ki tu A la: " + countA);
                        
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Dang cho ghi file");
                }
            }
        }

        static void Main(string[] args)
        {
            var t2 = new Thread(CT2);
            t2.Start();
            t2.Join();
            Console.ReadKey();
        }
    }
}
