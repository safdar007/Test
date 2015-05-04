using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
        static List<string> conctlist11 = new List<string>();
        private static Mutex mut = new Mutex();
        static byte[] msg;
        
        static long socketCount = 0;
        int currentCount = 0;
        static int y = 0;
        static int newMsgReceived = 0;
        string historyMsg = " ";
        static Socket port;
        static Socket socketCnct;
        static Socket clientMsgIP;
        public static string data = null;
        enum SERVER_STATES { STOP = 0, RUNNING = 1 };
        static SERVER_STATES scadaServerSatate;
        static int scadaPort = 0;
        static bool flstru = false;
        public static string oldClientSendData = null;
        
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
            timerConnectedClients.Start();
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
            }
            else if (scadaServerSatate == SERVER_STATES.RUNNING)
            {
                scadaServerSatate = SERVER_STATES.STOP;
                btnStartStop.Text = "Start";
                port.LingerState = new LingerOption(true, 0);
                port.Close();
            }            
        }

         private void timerConnectedClients_Tick(object sender, EventArgs e)
        {
            newClient.Text = y.ToString();
            
            //check and add new client connection in all connected list
            for (int index = 0; index < socketlist.Count; index++)
            {
                string receiveMsg = "";
                Socket client = socketlist[index];
                byte[] buffer = new byte[1024];
                string s = client.RemoteEndPoint.ToString();
                while(client.Available > 0 )
                {
                    int getdata = client.Receive(buffer);
                    if (getdata > 0)
                    {   receiveMsg += Encoding.ASCII.GetString(buffer, 0, getdata);  }
                }//while(client.Available > 0 )
                
                if (receiveMsg.Length > 0)
                {   rTxtBoxMessageHistory.Text += client.RemoteEndPoint+ " : " + receiveMsg + "\n";     }

            }//for (int index = 0; index < socketlist.Count; index++)
            
            //Check Socket status and update it
            for (int socketIndex = 0; socketIndex < socketlist.Count; socketIndex++)
            {
                Socket tempSocket = socketlist[socketIndex];
                bool connected = SocketConnected(tempSocket);
                if (connected == false)
                {
                    lstDisconnectIPs.Items.Add(tempSocket.RemoteEndPoint);
                    socketlist.RemoveAt(socketIndex); 
                }
            }//for (int socketIndex = 0; socketIndex < socketlist.Count; socketIndex++)
             totalClientConnected.Text = socketlist.Count.ToString();

             //Currently connected clients list
             if (lstConnectedClients.Items.Count < 1)
             {
                 for (int firstAdd = 0; firstAdd < socketlist.Count; firstAdd++)
                 { lstConnectedClients.Items.Add(socketlist[firstAdd].RemoteEndPoint); }
             }//if (lstConnectedClients.Items.Count < 1)
             else
             {
                 for (int indexOfSocket = 0; indexOfSocket < socketlist.Count; indexOfSocket++)
                 {
                     Socket tempSocket = socketlist[indexOfSocket];
                     string stringEndPoint = tempSocket.RemoteEndPoint.ToString();
                     bool found = false;
                     for (int indexOfGui = 0; indexOfGui < lstConnectedClients.Items.Count; indexOfGui++)
                     {
                        string stringOfGui = lstConnectedClients.Items[indexOfGui].ToString();
                        if (stringEndPoint == stringOfGui)
                        {
                            found = true;                            
                            break;
                        }
                     }//for (int indexOfGui = 0; indexOfGui < socketlist.Count; indexOfGui++)
                     if (found == false)
                     {
                         lstConnectedClients.Items.Add(socketlist[indexOfSocket].RemoteEndPoint);
                     
                     }

                 }//for (int indexOfSocket = 0; indexOfSocket < socketlist.Count; indexOfSocket++)
             }//else of if (lstConnectedClients.Items.Count < 1)

          }//private void timerConnectedClients_Tick(object sender, EventArgs e)

        private void btnDisconnectIP_Click(object sender, EventArgs e)
        {
            if (listAllConnected.SelectedItem != null)
            {
                for (int itemIndex = 0; itemIndex < listAllConnected.Items.Count; itemIndex++)
                {
                    Socket client = socketlist[itemIndex];
                    string s = client.RemoteEndPoint.ToString();
                    string currentClient = listAllConnected.Items[itemIndex].ToString();
                    string itemDisconnect = listAllConnected.SelectedItem.ToString();
                        if (itemDisconnect == s)
                        {
                            client.LingerState = new LingerOption(true, 0);
                            client.Close();
                            listAllConnected.Items.RemoveAt(itemIndex);
                            socketlist.RemoveAt(itemIndex);            
                        }

                }//for (int itemIndex = 0; itemIndex < listAllConnected.Items.Count; itemIndex++)
            }//if (listAllConnected.SelectedItem != null)
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

     }
}
