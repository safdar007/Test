using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Generic;


namespace SCADA_Server_DLG
{
    
    public partial class SCADA_mainDlg : Form
    {
        static List<Socket> socketlist = new List<Socket>();
        static List<Socket> discntlist1 = new List<Socket>();
        //static List<string> discntlist1 = new List<string>();
        static List<string> conctlist11 = new List<string>();
        private static Mutex mut = new Mutex();
        static long socketCount = 0;
        static int x = 0;
        static int y = 0;
        static int z = 0;
        static long clientDissconnect = 0;
        static Socket port;
        static Socket socketCnct;
        static Socket socketDiscnct;
        public static string data = null;
        enum SERVER_STATES { STOP = 0, RUNNING = 1 };
        static SERVER_STATES scadaServerSatate;
        static int scadaPort = 0;
        static bool flstru = false;
        
        static bool SocketConnected(Socket client)
        {
            // This is how you can determine whether a socket is still connected. 
            bool blockingState = client.Blocking;
            try
            {
                byte[] tmp = new byte[1];

                client.Blocking = false;
                client.Send(tmp, 0, 0);
                Console.WriteLine("Connected!");
                return true;
            }
            catch (SocketException e)
            {
                // 10035 == WSAEWOULDBLOCK 
                if (e.NativeErrorCode.Equals(10035))
                {
                    Console.WriteLine("Still Connected, but the Send would block");
                    return true;
                }
                else
                {
                    Console.WriteLine("Disconnected: error code {0}!", e.NativeErrorCode);
                    return false;
                }
            }
            finally
            {
                client.Blocking = blockingState;
            }
          
            Console.WriteLine("Connected: {0}", client.Connected);
            return client.Connected;
        }

        public static void ReadThread()
        {
            while (scadaServerSatate == SERVER_STATES.RUNNING)
            {
                byte[] buffer = new Byte[1024];
                long currentSocketCount = socketlist.Count;
                //socketlist.Add(port);
                if (currentSocketCount > socketCount)
                {
                    long newSockets = currentSocketCount - socketCount;

                        for (int l = (int)socketCount; l < currentSocketCount; l++)
                        {
                            socketCnct = socketlist[l];
                            Socket handleSocket = (Socket)socketlist[l];
                            x = l;
                            x++;
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
                            //handleSocket.Shutdown(SocketShutdown.Both);
                            //handleSocket.Close();

                        }//for (int l = 0; l < newSockets; l++)
                    
                    socketCount = currentSocketCount;

                }// if (currentSocketCount > socketCount)
                int foreachvarriable = 0;
                if (socketlist.Count > 0)
                {
                    for (int lp = 0; lp < socketlist.Count; lp++) // Loop through List with foreach.
                    {

                        flstru = SocketConnected(socketlist[lp]);
                        if (flstru == false)
                        {
                            if (mut.WaitOne(1000))
                            {
                                y = foreachvarriable;
                                discntlist1.Add(socketlist[lp]);
                                socketlist.RemoveAt(lp);
                            }// Release the Mutex.
                            mut.ReleaseMutex();

                        }
                        foreachvarriable++;
                    }
                }
                Thread.Sleep(1000);
            }//while true

        }//public static void ReadThread() 

        public static void ListenThread()
        {
            IPHostEntry hostip = Dns.Resolve(Dns.GetHostName());
            IPAddress ip = hostip.AddressList[0];
            IPEndPoint EndPoint = new IPEndPoint(ip, scadaPort);
            port = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            try
            {
                port.Bind(EndPoint);
                port.Listen(5);

                while (scadaServerSatate == SERVER_STATES.RUNNING)
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

        public SCADA_mainDlg()
        {
            InitializeComponent();
            
            scadaServerSatate = SERVER_STATES.STOP;
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (scadaServerSatate == SERVER_STATES.STOP)
            {
                
                scadaPort = (int) numericUpDownPort.Value;//???
                btnStartStop.Text = "Stop";
                scadaServerSatate = SERVER_STATES.RUNNING;
                Thread serverThread = new Thread(new ThreadStart(ListenThread));
                //listen();
                serverThread.Start();
                
                Thread readThread = new Thread(new ThreadStart(ReadThread));
                readThread.Start();
                
            }
            else if (scadaServerSatate == SERVER_STATES.RUNNING)
            {
                scadaServerSatate = SERVER_STATES.STOP;
                btnStartStop.Text = "Start";
                port.LingerState = new LingerOption(true, 0);
                port.Close();
            }            
        }

        private void btnShow_Click(object sender, System.EventArgs e)
        {
            
            if (y > 0)
            {
                dissconnectClient.Value = y; 
            }

            newClient.Value = x;
            totalClientConnected.Text = socketlist.Count.ToString();
            lstDiscnt.Items.AddRange(discntlist1.ToArray());

            for (int index = 0; index < socketlist.Count; index++)
            {
                Socket client = socketlist[index];
                lstCnt.Items.Add(client.RemoteEndPoint);
            }
        }

     }
}
