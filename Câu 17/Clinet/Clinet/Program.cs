using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 100);
            Socket client = new Socket(SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ipe);
            Console.WriteLine("Da ket noi");
            while (true)
            {
                try
                {
                    Console.WriteLine("Nhap so luong phan tu: ");
                    int n = int.Parse(Console.ReadLine());
                    byte[] send = ASCIIEncoding.ASCII.GetBytes(n.ToString());
                    client.Send(send);
                    if (n < 0) break;

                    int[] arr = new int[n];
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine("Nhap phan tu thu " + (i + 1) + ": ");
                        arr[i] = int.Parse(Console.ReadLine());

                        byte[] sendArr = ASCIIEncoding.ASCII.GetBytes(arr[i].ToString());
                        client.Send(sendArr);

                    }

                    client.Close();
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Nhap lai!");
                }
            }
            Console.ReadKey();

        }
    }
}
