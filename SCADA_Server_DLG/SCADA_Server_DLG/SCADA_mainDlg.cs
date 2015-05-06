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
        const string OPENING_BRACE = " [";
        
        static bool SocketConnected(Socket client)
        {
            // This is how you can determine whether a socket is still connected. 
            bool blockingState = client.Blocking;
            try
            {
                byte[] tmp = new byte[1];

                client.Blocking = false;
                client.Send(tmp, 0, 0);
                //Console.WriteLine("Connected!");
                return true;
            }
            catch (SocketException e)
            {
                // 10035 == WSAEWOULDBLOCK 
                if (e.NativeErrorCode.Equals(10035))
                {
                //    Console.WriteLine("Still Connected, but the Send would block");
                    return true;
                }
                else
                {
              //      Console.WriteLine("Disconnected: error code {0}!", e.NativeErrorCode);
                    return false;
                }
            }
            finally
            {
                client.Blocking = blockingState;
            }
          
            //Console.WriteLine("Connected: {0}", client.Connected);
            return client.Connected;
        }//static bool SocketConnected(Socket client)

        public static void ListenThread()
        {
            IPHostEntry hostip = Dns.Resolve(Dns.GetHostName());
            IPAddress ip = hostip.AddressList[0];
            IPEndPoint EndPoint = new IPEndPoint(ip, scadaPort);
            port = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            byte[] buffer = new byte[1024];
            string receiveMsg = "";
            List<string> authorization = new List<string>();
            authorization.Add("123");
            authorization.Add("124");
            authorization.Add("125");

            try
            {
                port.Bind(EndPoint);
                port.Listen(5);

                while (scadaServerSatate == SERVER_STATES.RUNNING)
                {
                    //Console.WriteLine("Waiting for a connecting with Clint...");
                    Socket handleSocket = port.Accept();
                    socketCnct = handleSocket;
                    receiveMsg = "";
                    while (handleSocket.Available > 0)
                    {
                        int getdata = handleSocket.Receive(buffer);
                        if (getdata > 0)
                        { receiveMsg += Encoding.ASCII.GetString(buffer, 0, getdata); }
                    }//while(client.Available > 0 )

                    bool found = false;
                    for (int indexAuthorization = 0; indexAuthorization < authorization.Count; indexAuthorization++)
                    {
                        if (receiveMsg == authorization[indexAuthorization])
                        {
                            //send
                            found = true;
                            break;
                        }
                    }//for (int indexAuthorization = 0; indexAuthorization < authorization.Count; indexAuthorization++)

                    if (found == false)
                    {
                        handleSocket.LingerState = new LingerOption(true, 0);
                        handleSocket.Close();
                    }
                    else
                    { socketlist.Add(handleSocket); }
                }//while (scadaServerSatate == SERVER_STATES.RUNNING)
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
                if (socketlist.Count > 0)
                {
                    DialogResult result = MessageBox.Show(socketlist.Count + " Clients are currently connected.\nDo you also want to disconnect all connected clients?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        int socketCount = socketlist.Count;
                        for (int index = 0; index < socketCount; index++)
                        {
                            Socket client = socketlist[index];
                            lstDisconnectIPs.Items.Add(client.RemoteEndPoint + GetCurrentTime());
                            lstConnectedClients.Items.RemoveAt(index);

                            socketlist[index].LingerState = new LingerOption(true, 0);
                            socketlist[index].Close();
                            socketlist.RemoveAt(index);
                            index--;
                            socketCount--;
                        
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        //...
                    }
                    else
                    {
                        //...
                    }
                }//if (clientConnection == " ")
                
                scadaServerSatate = SERVER_STATES.STOP;
                btnStartStop.Text = "Start";
                port.LingerState = new LingerOption(true, 0);
                port.Close();
            }            
        }

        private string GetCurrentTime()
        {
            return OPENING_BRACE + DateTime.Now.ToString() +"]";
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
                    { receiveMsg += Encoding.ASCII.GetString(buffer, 0, getdata); }
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
                    lstDisconnectIPs.Items.Add(tempSocket.RemoteEndPoint + GetCurrentTime());
                    socketlist.RemoveAt(socketIndex); 
                }
            }//for (int socketIndex = 0; socketIndex < socketlist.Count; socketIndex++)
             totalClientConnected.Text = socketlist.Count.ToString();

             //Currently connected clients list
             if (lstConnectedClients.Items.Count < 1)
             {
                 for (int firstAdd = 0; firstAdd < socketlist.Count; firstAdd++)
                 {
                     lstConnectedClients.Items.Add(socketlist[firstAdd].RemoteEndPoint + GetCurrentTime());
                     listAllConnected.Items.Add(socketlist[firstAdd].RemoteEndPoint + GetCurrentTime()); 
                 }
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
                        int index = stringOfGui.LastIndexOf(OPENING_BRACE);
                        string requirString = stringOfGui.Substring(0,index);
                        if (stringEndPoint == requirString)
                        {
                            found = true;                            
                            break;
                        }
                     }//for (int indexOfGui = 0; indexOfGui < socketlist.Count; indexOfGui++)
                     if (found == false)
                     { lstConnectedClients.Items.Add(socketlist[indexOfSocket].RemoteEndPoint + GetCurrentTime()); }

                     //Create History of All connected IPs
                     bool newClientFound = false;
                     for (int indexOfAllConnected = 0; indexOfAllConnected < listAllConnected.Items.Count; indexOfAllConnected++)
                     {
                         string stringOfAllConnected = listAllConnected.Items[indexOfAllConnected].ToString();
                         int index = stringOfAllConnected.IndexOf(OPENING_BRACE);
                         string requirString = stringOfAllConnected.Substring(0, index);

                         if (stringEndPoint == requirString)
                        {
                            newClientFound = true;                            
                            break;
                        }
                     }//for (int indexOfGui = 0; indexOfGui < socketlist.Count; indexOfGui++)
                     if (newClientFound == false)
                     { listAllConnected.Items.Add(socketlist[indexOfSocket].RemoteEndPoint + GetCurrentTime()); }
                     
                 }//for (int indexOfSocket = 0; indexOfSocket < socketlist.Count; indexOfSocket++)

                 //Remove list Item if IP is not exist in Socket list
                 for (int indexGui = 0; indexGui < lstConnectedClients.Items.Count; indexGui++)
                 {
                     string guistring = lstConnectedClients.Items[indexGui].ToString();
                     int index = guistring.IndexOf(OPENING_BRACE);
                     string requirString = guistring.Substring(0, index);
                     bool found = false;
                     for (int listIndex = 0; listIndex < socketlist.Count; listIndex++)
                     {
                         string endPointString = socketlist[listIndex].RemoteEndPoint.ToString();
                         if (endPointString == requirString)
                         {
                             found = true;
                             break;
                         }
                     }//for (int listIndex = 0; listIndex < socketlist.Count; listIndex++)
                     if (found == false)
                     { lstConnectedClients.Items.RemoveAt(indexGui); }
                 }

             }//else of if (lstConnectedClients.Items.Count < 1)

          }//private void timerConnectedClients_Tick(object sender, EventArgs e)

         private void btnDisconnectIP_Click(object sender, EventArgs e)
         {
                 if (lstConnectedClients.SelectedItem != null)
                 {
                     string itemDisconnect = lstConnectedClients.SelectedItem.ToString();
                     for (int itemIndex = 0; itemIndex < lstConnectedClients.Items.Count; itemIndex++)
                     {
                         Socket client = socketlist[itemIndex];
                         string s = client.RemoteEndPoint.ToString();
                         string currentClient = lstConnectedClients.Items[itemIndex].ToString();
                         int index = currentClient.IndexOf(OPENING_BRACE);
                         string requirString = currentClient.Substring(0, index);
                         
                         if (itemDisconnect == currentClient)
                         {
                             lstDisconnectIPs.Items.Add(s + GetCurrentTime());
                             lstConnectedClients.Items.RemoveAt(itemIndex);
                             client.LingerState = new LingerOption(true, 0);
                             client.Close();
                             socketlist.RemoveAt(itemIndex);
                         }

                     }//for (int itemIndex = 0; itemIndex < listAllConnected.Items.Count; itemIndex++)
                 }//if (listAllConnected.SelectedItem != null)
            }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (lstConnectedClients.SelectedItem != null)
            {
                string itemDisconnect = lstConnectedClients.SelectedItem.ToString();
                for (int itemIndex = 0; itemIndex < lstConnectedClients.Items.Count; itemIndex++)
                {
                    Socket client = socketlist[itemIndex];
                    string s = client.RemoteEndPoint.ToString();
                    string currentClient = lstConnectedClients.Items[itemIndex].ToString();
                    int index = currentClient.IndexOf(OPENING_BRACE);
                    string requirString = currentClient.Substring(0, index);

                    if (itemDisconnect == currentClient)
                    {
                        string writeMsg = textBoxWriteMsg.Text;
                        byte[] nextMsgSend = Encoding.ASCII.GetBytes(writeMsg);
                        client.Send(nextMsgSend);
                    }

                }//for (int itemIndex = 0; itemIndex < listAllConnected.Items.Count; itemIndex++)
            }//if (listAllConnected.SelectedItem != null)
        }

        private void btnSendAll_Click(object sender, EventArgs e)
        {
            if (socketlist.Count > 0)
            {
                for (int itemIndex = 0; itemIndex < socketlist.Count; itemIndex++)
                {
                    Socket client = socketlist[itemIndex];
                    string writeMsg = textBoxWriteMsg.Text;
                    byte[] nextMsgSend = Encoding.ASCII.GetBytes(writeMsg);
                    client.Send(nextMsgSend);
                }//for (int itemIndex = 0; itemIndex < lstConnectedClients.Items.Count; itemIndex++)
            }//if (socketlist.Count > 0)
        }//private void btnSendAll_Click(object sender, EventArgs e)
     }
}
