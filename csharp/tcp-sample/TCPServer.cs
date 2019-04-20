using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TCPServerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string ipStr = "192.168.102.100";
                int portNum = 8080;

                IPAddress ip = IPAddress.Parse(ipStr);
                TcpListener tcpListener = new TcpListener(ip, portNum);

                tcpListener.Start();

                Console.WriteLine($"The server is running at {ipStr}:{portNum}");
                Console.WriteLine($"The local end point is {tcpListener.LocalEndpoint}");
                Console.WriteLine("Waiting for a connection...");

                Socket socket = tcpListener.AcceptSocket();
                Console.WriteLine($"Connection accepted from {socket.RemoteEndPoint}");


                Console.WriteLine("Receiving data...");
                byte[] buffer = new byte[1024];
                int receivedBytes;

                while (true)
                {
                    receivedBytes = socket.Receive(buffer);
                    Console.WriteLine($"Received {receivedBytes} bytes");
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

                ASCIIEncoding encoder = new ASCIIEncoding();

                byte[] ackMessage = encoder.GetBytes("Hey, I received your message.");

                socket.Send(ackMessage);

                socket.Close();
                tcpListener.Stop();
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
