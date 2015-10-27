using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDP
{
    public class UDPSender
    {
        byte[] helloBytes = Encoding.ASCII.GetBytes("HELLO");
        string destinationIP;
        int sendingPort;

        public UDPSender(string NewIPAddress, int newPort)
        {
            destinationIP = NewIPAddress;
            sendingPort = newPort;
        }

        public void startUDPSender()
        {
            Thread senderThread = new Thread(messsageSender);
            senderThread.Start();
        }

        public void messsageSender()
        {
            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress send_to_address = IPAddress.Parse(destinationIP);
            IPEndPoint sending_end_point = new IPEndPoint(send_to_address, sendingPort);

            while (true)
            {
                try
                {
                    sending_socket.SendTo(helloBytes, sending_end_point);
                    Console.WriteLine("Sent message");
                }
                catch (Exception e)
                {
                    Console.WriteLine(" Exception: {0}", e.Message);
                }
                Thread.Sleep(60000);
            }
        }
    }
}
