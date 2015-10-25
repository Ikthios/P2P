using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client
{
    class ClientCore
    {
        // Class variables
        private Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private TcpListener listener;

        // Default constructor
        public ClientCore() { }

        public void StartClientThread()
        {
            ClientThreadHandler cth = new ClientThreadHandler();
            string ipAddress = cth.GetIpAddress();
            int port = 5500;

            // Internal check
            Debug.WriteLine("Starting client thread at " + ipAddress + ":" + port + " [CLIENTCORE].");

            StartClientServer(ipAddress, port);
        }

        public void StartClientServer(String ip, int port)
        {
            string ipString = ip.ToString();
            // Parse client ip address
            IPAddress ipaddress = IPAddress.Parse(ipString);  // Format exception

            // Initialize client listener
            listener = new TcpListener(ipaddress, port);

            // Set loop variable
            Boolean loop = true;
            try
            {
                // Start listening on client port
                listener.Start();
                
                while (loop)
                {
                    Socket newClient = listener.AcceptSocket();
                    ClientThreadHandler cth = new ClientThreadHandler(newClient);
                    cth.StartHandling();
                }
            }catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
