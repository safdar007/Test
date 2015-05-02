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
        static int oldMsg = 0;
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
        static byte[] buffer;
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

        public static void ReadThread()
        {
            while (scadaServerSatate == SERVER_STATES.RUNNING)
            {
                buffer = new Byte[1024];
                long currentSocketCount = socketlist.Count;
                //socketlist.Add(port);
                //check the new connection request
                if (currentSocketCount > socketCount)
                {
                    long newSockets = currentSocketCount - socketCount;

                        for (int l = (int)socketCount; l < currentSocketCount; l++)
                        {
                            y++;
                            socketCnct = socketlist[l];
                            Socket handleSocket = (Socket)socketlist[l];
                            clientMsgIP = handleSocket;
                            while (true)
                            {
                                buffer = new byte[1024];
                                int getdata = handleSocket.Receive(buffer);
                                if (getdata > 0)
                                
                                data += Encoding.ASCII.GetString(buffer, 0, getdata);
                                if (data.IndexOf("<END>") > -1)
                                {
                                    break;
                                }

                            }//while
                            // Show the data on the console.
                            Console.WriteLine("Text received : {0},{1}", data, handleSocket.LocalEndPoint.ToString());

                            // Echo the data back to the client.
                            msg = Encoding.ASCII.GetBytes("This data is sent by SACADA's Server" + " + IP & Port =" + handleSocket.LocalEndPoint.ToString());
                             
                            handleSocket.Send(msg);
                            //handleSocket.Shutdown(SocketShutdown.Both);
                            //handleSocket.Close();

                        }//for (int l = 0; l < newSockets; l++)
                    
                    socketCount = currentSocketCount;

                }// if (currentSocketCount > socketCount)
                
                //if client disconect Remove that socket
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
                                discntlist1.Add(socketlist[lp]);
                                socketlist.RemoveAt(lp);
                            }// Release the Mutex.
                            mut.ReleaseMutex();

                        }//if (flstru == false)

                        foreachvarriable++;
                    
                    }//for (int lp = 0; lp < socketlist.Count; lp++) // Loop through List with foreach.
                }//if (socketlist.Count > 0)

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

        /*private void btnShow_Click(object sender, System.EventArgs e)
        {

            lstConnectedClients.Items.Clear();
            lstDisconnectIPs.Items.Clear();
            if (msg != null)
            {
                rTxtBoxMessageHistory.Text = data.ToString();
            } 
            newClient.Text = y.ToString();
            totalClientConnected.Text = socketlist.Count.ToString();
           // lstDisconnectIPs.Items.AddRange(discntlist1.ToArray());
            for (int index = 0; index < discntlist1.Count; index++)
            {
                Socket client = discntlist1[index];
                lstDisconnectIPs.Items.Add(client.RemoteEndPoint);
            }
            for (int index = 0; index < socketlist.Count; index++)
            {
                Socket client = socketlist[index];
                lstConnectedClients.Items.Add(client.RemoteEndPoint);
            }
        }*/

        private void timerConnectedClients_Tick(object sender, EventArgs e)
        {
            lstDisconnectIPs.Items.Clear();
            newClient.Text = y.ToString();
            totalClientConnected.Text = socketlist.Count.ToString();

            if (data != null)
            {
           //     rTxtBoxMessageHistory.Text = data + clientMsgIP.RemoteEndPoint;
             //   data = null;
            }

            for (int index = 0; index < discntlist1.Count; index++)
            {
                Socket client = discntlist1[index];
                lstDisconnectIPs.Items.Add(client.RemoteEndPoint);    
            }

            for (int index = 0; index < socketlist.Count; index++)
            {
                lstConnectedClients.Items.Clear();
                Socket client = socketlist[index];
                lstConnectedClients.Items.Add(client.RemoteEndPoint);
            }
            
            //check and add new client connection in all connected list
            for (int index = 0; index < socketlist.Count; index++)
            {
                string receiveMsg = "";
                Socket client = socketlist[index];
                string s = client.RemoteEndPoint.ToString();
                while(client.Available > 0 )
                {
                    int getdata = client.Receive(buffer);
                    if (getdata > 0)
                    {   receiveMsg += Encoding.ASCII.GetString(buffer, 0, getdata);  }
                }//while(client.Available > 0 )
                if (receiveMsg.Length > 0)
                {

                    rTxtBoxMessageHistory.Text += receiveMsg + client.RemoteEndPoint; 
                }

                bool found = false;
                for (int itemIndex = 0; itemIndex < listAllConnected.Items.Count; itemIndex++ )
                {
                    string currentClient = listAllConnected.Items[itemIndex].ToString();
                    if (s == currentClient)
                    {
                        
                        found = true;
                        if (listAllConnected.SelectedItem != null)
                        
                        break;
                    }
                }//for (int itemIndex = 0; itemIndex < listAllConnected.Items.Count; itemIndex++ )

                if (found == false)
                { listAllConnected.Items.Add(client.RemoteEndPoint); }


            }//for (int index = 0; index < socketlist.Count; index++)

            //check and remove disconnected clients from all connected lists
            for (int itemIndex = 0; itemIndex < listAllConnected.Items.Count; itemIndex++)
            {
                string currentClient = listAllConnected.Items[itemIndex].ToString();
                bool found = false;
                
                for (int index = 0; index < socketlist.Count; index++)
                {
                    Socket client = socketlist[index];
                    string s = client.RemoteEndPoint.ToString();
                    if (s == currentClient)
                    {
                        found = true;
                        break;
                    }
                }//for (int itemIndex = 0; itemIndex < listAllConnected.Items.Count; itemIndex++ )

                if (found == false)
                { listAllConnected.Items.RemoveAt(itemIndex); }
            }//for (int index = 0; index < socketlist.Count; index++)
        }

        private void button1_Click(object sender, EventArgs e)
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
        }//private void timerConnectedClients_Tick(object sender, EventArgs e)

     }
}
