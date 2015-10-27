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
            IPAddress ipaddress = IPAddress.Parse(servCore.GetIpAddress());
            int port = 6000;

            Console.WriteLine("Server running at " + ipaddress.ToString() + ":" + port);

            // Initialize the listener
            TcpListener listener = new TcpListener(ipaddress, port);
            // Set loop variable
            Boolean loop = true;
            try
            {
                UDPListener serverListener = new UDPListener(60001);
                serverListener.StartUDPListener();

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
