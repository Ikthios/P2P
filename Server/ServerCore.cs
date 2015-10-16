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
    class ServerCore
    {
        static void Main(string[] args)
        {
            // Class variables
            ServerCore servCore = new ServerCore();

            // Get user input for the ip address and port number
            Console.WriteLine("Enter the hosting IP.");
            String ipString = Console.ReadLine();
            Console.WriteLine("Enter the hosting port.");
            String portString = Console.ReadLine();

            //string ipString = servCore.GetIpAddress();
            IPAddress ipaddress = IPAddress.Parse(ipString);
            int port = int.Parse(portString);

            // Initialize the listener
            TcpListener listener = new TcpListener(ipaddress, port);
            // Set loop variable
            Boolean loop = true;
            try
            {
                // Start listening on the specified port
                Console.WriteLine("Starting the TCP Listener...");
                listener.Start();
                Console.WriteLine("Server running at port " + port);
                Console.WriteLine("Local end point is " + listener.LocalEndpoint);
                Console.WriteLine("Listening for requests...");

                while (loop)
                {
                    Socket newClient = listener.AcceptSocket();
                    ServerThreadHandler clientThread = new ServerThreadHandler(newClient);

                    clientThread.StartHandling();
                }
            }catch(Exception error)
            {
                Console.WriteLine(error.ToString());
            }
        }
    }
}
