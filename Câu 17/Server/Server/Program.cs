using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 100);
                Socket server = new Socket(SocketType.Stream, ProtocolType.Tcp);
                server.Bind(ipe);
                server.Listen(50);
                Console.WriteLine("Dang cho ket noi");
                do
                {
                    Socket client = server.Accept();
                    Console.WriteLine("Co ket noi");

                    //Nhan
                    byte[] receive = new byte[1024];
                    int len = client.Receive(receive);
                    string receiveN = ASCIIEncoding.ASCII.GetString(receive, 0, len);
                    int n = Convert.ToInt32(receiveN);
                    if (n < 0) break;
                    Console.WriteLine("So phan tu cua mang: " + n);
                    int[] arr = new int[n];
                    for (int i = 0; i < n; i++)
                    {
                        byte[] receiveArr = new byte[1024];
                        int lenArr = client.Receive(receiveArr);
                        string receiveArrN = ASCIIEncoding.ASCII.GetString(receiveArr, 0, lenArr);
                        arr[i] = Convert.ToInt32(receiveArrN);
                    }

                    Array.Reverse(arr);
                    Console.WriteLine("Tung phan tu trong mang sau khi dao nguoc la: ");
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine(i);
                        Console.WriteLine("Ma hexa: " + arr[i].ToString("X"));
                    }

                    client.Close();
                } while (true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
