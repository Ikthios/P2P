using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class ClientCore
    {
        // Class variables
        private ClientForm clientForm = new ClientForm();
        private Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private TcpListener listener;

        // Default constructor
        public ClientCore() { }

        public void StartClientThread()
        {
            ClientForm form = new ClientForm();
            StartClientServer(form.GetIpAddress(), 5500);
            
            // Internal check
            Debug.WriteLine("Starting client thread at " + form.GetIpAddress() + " [CLIENTCORE].");
        }

        public void StartClientServer(String ip, int port)
        {
            string ipString = ip.ToString();
            // Internal check
            Debug.WriteLine("Parsing IP Address [CLIENTCORE].");
            // Parse client ip address
            IPAddress ipaddress = IPAddress.Parse(ipString);  // Format exception

            // Internal check
            Debug.WriteLine("Designating listener [CLIENTCORE].");
            // Initialize client listener
            listener = new TcpListener(ipaddress, port);

            // Set loop variable
            Boolean loop = true;

            // Internal check
            Debug.WriteLine("Reached try block [CLIENTCORE].");
            try
            {
                // Internal check
                Debug.WriteLine("Starting listener [CLIENTCORE].");
                // Start listening on client port
                clientForm.DisplayConnection("Starting client listener on port " + port);
                listener.Start();
                
                // Internal check
                Debug.WriteLine("Starting while loop [CLIENTCORE].");
                while (loop)
                {
                    // Internal check
                    Debug.WriteLine("Listener accepting socket [CLIENTCORE].");
                    Socket newClient = listener.AcceptSocket();
                    ClientThreadHandler clientThread = new ClientThreadHandler(newClient);
                    clientThread.StartHandling();
                    // Internal check
                    Debug.WriteLine("Looping clientThread [CLIENTCORE].");
                }
            }catch(Exception error)
            {
                clientForm.DisplayError(error.ToString());
                // Internal check
                Debug.WriteLine("Failed to start looping interface [CLIENTCORE].");
            }
        }
    }
}
