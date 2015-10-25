using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class ServerThreadHandler
    {
        // Global variables
        private Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public ServerThreadHandler(Socket client)
        {
            this.clientSocket = client;
        }

        // Create a new thread for a new client
        public void StartHandling()
        {
            Console.WriteLine("Accepting connection.\nStarting handler...");
            Thread handler = new Thread(ServerHandler);
            handler.Priority = ThreadPriority.AboveNormal;
            handler.Start();
        }

        private void ServerHandler()
        {
            Boolean loop = true;
            ASCIIEncoding encoding = new ASCIIEncoding();
            while (loop)
            {
                try
                {
                    Console.WriteLine("Connection accepted from " + clientSocket.RemoteEndPoint);

                    byte[] b = new byte[1500];           // Create byte array for receiving client data
                    int csr = clientSocket.Receive(b);  // Receive the client data
                    Console.WriteLine("Received connection...");
                    string dataString = "";     // This will hold the raw data coming in from the connected peer

                    // Build the message
                    for (int i = 0; i < csr; i++)
                    {
                        dataString += Convert.ToChar(b[i]);
                    }
                    /*
                    This will split/organize the raw data into a format
                    the server can understand.
                    */
                    string[] tokens = dataString.Split(',');

                    /*
                    (REG)istration
                    The 'REG' keyword is used by the server to identify that this is a registration call
                    made by the client form and that it is to be registered in the serverside database.

                    (C)lient (F)ile (R)equest
                    The 'CFR' keyword is used by the server to identify that this is a request call
                    made by the client form for a file hosted by another client.

                    (S)top (C)lient (L)oop
                    The 'SCL' keyword is used by the client to identify when the server is done sending
                    information during a connection request.
                    */
                    ServDatabase servDB = new ServDatabase();
                    if (tokens[0].Equals("REG")){
                        // Register the client
                        clientSocket.Send(encoding.GetBytes("IP " + tokens[1] + " registered."));
                        clientSocket.Send(encoding.GetBytes("SCL"));
                        servDB.RegisterPeer(dataString.Remove(0, 4));
                        Console.WriteLine("Printing the data list...");
                        servDB.PrintDataList();
                    }
                    else if (tokens[0].Equals("CFR"))
                    {
                        /*
                        CFR Request
                        [0] = Keyword
                        [1] = Requested File
                        [2] = Requesting Peer IP Address
                        */
                        // Search data list for files
                        Console.WriteLine("File search for " + tokens[1] + " received.");
                        string hostingPeer = servDB.RetreivePeer(tokens[2], dataString.Remove(0,4));   // Remove the 'CFR' keyword
                        clientSocket.Send(encoding.GetBytes(hostingPeer));
                        clientSocket.Send(encoding.GetBytes("SCL"));
                    }
                    else{
                        Console.WriteLine(dataString);  // Print client data to the console
                        /* Start data sent to client
                        This is how the peer list from the server DB will be sent.
                        */
                        clientSocket.Send(encoding.GetBytes("String received by server"));
                        clientSocket.Send(encoding.GetBytes("SCL"));
                        /* End data sent to client */
                    }
                    // Clear the datastring
                    dataString = "";
                }catch(Exception e)
                {
                    Console.WriteLine("Client Connection Error: " + e.ToString());
                    loop = false;
                }
            }

            //Stop(); // Stop the client socket connection
        }

        private void Stop()
        {
            // Clean up
            clientSocket.Close();
        }

        private string GetIpAddress()
        {
            IPHostEntry host;
            string localIp = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress address in host.AddressList)
            {
                if (address.AddressFamily.ToString() == "InterNetwork")
                {
                    localIp = address.ToString();
                }
            }
            return localIp;
        }
    }
}
