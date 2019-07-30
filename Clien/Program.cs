using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clien
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 8082;
            string ipaddress = "172.16.5.173";
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipaddress), port);
            //Thread t1 = new Thread(new ThreadStart());

            clientSocket.Connect(ep);
            Console.WriteLine("CLient is connected");
            while(true)
            {
                string msg = null;
                Console.WriteLine("Enter message");
                msg = Console.ReadLine();
                clientSocket.Send(System.Text.Encoding.ASCII.GetBytes(msg), 0, msg.Length,SocketFlags.None);
                byte[] msgfromServer = new Byte[100];
                int size=clientSocket.Receive(msgfromServer);

                Console.WriteLine("server" + System.Text.Encoding.ASCII.GetString(msgfromServer,0,size));


            }

        }
    }
}
