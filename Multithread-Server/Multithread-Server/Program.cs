using System;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace Multithread_Server
{
    class Program
    {
        static List<Socket> socketlist = new List<Socket>();
        static long socketCount = 0;
        
        public static void ReadThread() 
        {
            while (true)
            {
                byte[] buffer = new Byte[1024];
                long currentSocketCount = socketlist.Count;

                if (currentSocketCount > socketCount)
                {
                    long newSockets = currentSocketCount - socketCount;

                    for (int l = (int)socketCount; l < currentSocketCount; l++)
                    {
                        Socket handleSocket = (Socket)socketlist[l];

                        while (true)
                        {
                            buffer = new byte[1024];
                            int getdata = handleSocket.Receive(buffer);
                            data += Encoding.ASCII.GetString(buffer, 0, getdata);
                            if (data.IndexOf("<END>") > -1)
                            {
                                break;
                            }

                        }//while
                        // Show the data on the console.
                        Console.WriteLine("Text received : {0},{1}", data, handleSocket.LocalEndPoint.ToString());

                        // Echo the data back to the client.
                        byte[] msg = Encoding.ASCII.GetBytes("This data is sent by SACADA's Server" + " + IP & Port =" + handleSocket.LocalEndPoint.ToString());

                        handleSocket.Send(msg);
                        handleSocket.Shutdown(SocketShutdown.Both);
                        handleSocket.Close();

                    }//for (int l = 0; l < newSockets; l++)

                    socketCount = currentSocketCount;

                }// if (currentSocketCount > socketCount)
                Thread.Sleep(1000);
            }//while true
            
        }//public static void ReadThread() 

        public static void ListenThread()
        {
            IPHostEntry hostip = Dns.Resolve(Dns.GetHostName());
            IPAddress ip = hostip.AddressList[0];
            IPEndPoint EndPoint = new IPEndPoint(ip, 11);

            Socket port = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            try
            {
                port.Bind(EndPoint);
                port.Listen(5);

                while (true)
                {
                    Console.WriteLine("Waiting for a connecting with Clint...");
                    Socket handleSocket = port.Accept();

                    socketlist.Add(handleSocket);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }//public static void ListenThread()

        public static string data = null;
        public static int Main(String[] args)
        {
            Thread serverThread = new Thread(new ThreadStart(ListenThread));
            //listen();
            serverThread.Start();
            
            Thread readThread = new Thread(new ThreadStart(ReadThread));
            readThread.Start();

            return 0;
        }
    }
}

