using System;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;

namespace SCADA_Server
{
    class Program
    {
        public static string data = null;
        public static void listen()
        {
            byte[] buffer = new Byte[1024];

            IPHostEntry hostip = Dns.Resolve(Dns.GetHostName());
            IPAddress ip = hostip.AddressList[0];
            IPEndPoint EndPoint = new IPEndPoint(ip, 11);

            Socket port = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                port.Bind(EndPoint);
                port.Listen(500);

                while (true)
                {
                 Console.WriteLine("Waiting for a connecting with Clint...");
                 Socket port1 = port.Accept();
                 data = null;

                   while (true)
                   {
                       buffer = new byte[1024];
                       int getdata = port1.Receive(buffer);
                       data += Encoding.ASCII.GetString(buffer, 0, getdata);
                       if (data.IndexOf("<END>") > -1)
                       {
                           break;
                       }

                   }
                   // Show the data on the console.
                   Console.WriteLine("Text received : {0}", data);

                   // Echo the data back to the client.
                   byte[] msg = Encoding.ASCII.GetBytes("This data is sent by SACADA's Server");

                   port1.Send(msg);
                   port1.Shutdown(SocketShutdown.Both);
                   port1.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            //Console.Read();
        }

        public static int Main(String[] args)
        {

            listen();
            return 0;
        }
    }
}
