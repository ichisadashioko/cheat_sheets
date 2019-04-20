using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TCPClientSample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string ipStr = "192.168.102.100";
                int portNum = 8080;

                TcpClient tcpClient = new TcpClient();

                tcpClient.Connect(ipStr, portNum);

                Console.WriteLine($"Connected to {ipStr}:{portNum}");
                Console.Write("Enter message: ");

                string sendMessage = Console.ReadLine();

                NetworkStream stream = tcpClient.GetStream();

                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] messageData = encoder.GetBytes(sendMessage);

                Console.WriteLine("Sending...");

                stream.Write(buffer: messageData, offset: 0, size: messageData.Length);

                byte[] buffer = new byte[1024];
                int receivedBytes;

                while (true)
                {
                    receivedBytes = stream.Read(buffer, 0, buffer.Length);
                    // do something
                    byte[] message = new byte[receivedBytes];
                    Array.Copy(buffer, 0, message, 0, receivedBytes);
                    string mess = Encoding.ASCII.GetString(message);
                    Console.Write(mess);

                    if (receivedBytes < buffer.Length)
                    {
                        break;
                    }
                }
                Console.WriteLine();

                tcpClient.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error...");
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine("Press Enter to exit!");
            Console.ReadLine();
        }
    }
}
