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
using System.Threading;
using System.Text;

namespace Clients_Dlg
{
        public partial class frmMain : Form
        {
            private static Mutex mut = new Mutex();
            static int port = 11;
            static string iPAdress = "192.168.0.104";
            static string message = "...";
            static Socket client = null; 
            enum CLIENT_STATES { Disconnect = 0, Connect = 1};
            static CLIENT_STATES scadaServerSatate;
            static int scadaPort = 0;

            // The response from the remote device.
            private static String response = String.Empty;


            public static void ConnectingThread()
            {
                while(scadaServerSatate == CLIENT_STATES.Connect)
                {
                    if (client == null)
                    {
                        //try
                        {
                            // Establish the remote endpoint for the socket.
                            // The name of the 
                            // remote device is "host.contoso.com".
                            //IPHostEntry ipHostInfo = Dns.GetHostEntry(iPAdress);
                            IPHostEntry ipHostInfo = Dns.Resolve(iPAdress);
                            IPAddress ipAddress = ipHostInfo.AddressList[0];
                            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                            // Create a TCP/IP socket.
                            client = new Socket(AddressFamily.InterNetwork,
                            SocketType.Stream, ProtocolType.Tcp);
                            // Connect to the remote endpoint.
                            //client.BeginConnect(remoteEP,
                            //    new AsyncCallback(ConnectCallback), client);
                            client.Connect(remoteEP);
                            //connectDone.WaitOne();
                            // Send test data to the remote device.

                            //if (mut.WaitOne(10000))
                            {
                                // Convert the string data to byte data using ASCII encoding.
                                byte[] byteData = Encoding.ASCII.GetBytes(message);

                                // Begin sending the data to the remote device.
                                client.Send(byteData);
                                //Send(client, "<1>This data is sent by SCADA's Clint <END>");
                                //sendDone.WaitOne();
                            }

                            // Write the response to the console.
                            Console.WriteLine("Response received : {0}", response);
                            client.LingerState = new LingerOption(false, 0);
                        }
                        //catch (Exception e)
                        {
                            //    Console.WriteLine(e.ToString());
                        }
                    }//if (client == null)
                    Thread.Sleep(1000);
                }//while(scadaServerSatate == CLIENT_STATES.Connect)

                if (client != null)
                {
                    // Release the socket.
                    client.LingerState = new LingerOption(true, 0);
                    //client.Disconnect(false);
                    //client.Shutdown(SocketShutdown.Both);
                    client.Close();
                    client = null;

                }//if (client != null)

                
            }//public static void ConnectingThread()

            public frmMain()
            {
                InitializeComponent();
                txtServerIP.Text = Dns.GetHostName();
            }

            private void btnConnectDisconnect_Click(object sender, System.EventArgs e)
            {
                if (scadaServerSatate == CLIENT_STATES.Disconnect)
                {
                    scadaServerSatate = CLIENT_STATES.Connect;
                    scadaPort = (int)portAddress.Value;
                    iPAdress = txtServerIP.Text;
                    btnConnectDisconnect.Text = "Disconnect";
                    btnConnectDisconnect.BackColor = System.Drawing.Color.Green;
                    port = (int)portAddress.Value;
                    message = "123";
                    Thread clientThread = new Thread(new ThreadStart(ConnectingThread));
                    clientThread.Start();
                    //Thread.Sleep(1000);
                    
                }
                else if (scadaServerSatate == CLIENT_STATES.Connect)
                {
                    scadaPort = (int)portAddress.Value;
                    btnConnectDisconnect.Text = "Connect";
                    btnConnectDisconnect.BackColor = System.Drawing.Color.Red;
                    scadaServerSatate = CLIENT_STATES.Disconnect;
                }

            }

            private void sendButton_Click(object sender, EventArgs e)
            {
                
                byte[] nextMsgSend = Encoding.ASCII.GetBytes(textMsgSend.Text);
                client.Send(nextMsgSend);
            }
       }

    
}