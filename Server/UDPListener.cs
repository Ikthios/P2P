using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace UDPListener
{
    class UDPListener
    {
        int receivingPort;
        private static System.Timers.Timer checkTimer;
        private static HashSet<String> checkedIPAddresses = new HashSet<string>();

        public UDPListener(int newPort)
        {
            receivingPort = newPort;
        }

        public void StartUDPListener()
        {
            Thread receivingThread = new Thread(messageReceiver);
            receivingThread.Start();
            SetTimer();
        }

        public void messageReceiver()
        {
            UdpClient listener = new UdpClient(receivingPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, receivingPort);
            string received_data;
            byte[] receive_byte_array;

            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");
                    receive_byte_array = listener.Receive(ref groupEP);
                    Console.WriteLine("Received a broadcast from {0}", groupEP.ToString());
                    string[] IPHolster = groupEP.ToString().Split(':');
                    checkedIPAddresses.Add(IPHolster[0]);
                    received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);
                    Console.WriteLine("data follows \n{0}\n\n", received_data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void SetTimer()
        {
            // Create a timer with a twenty second interval.
            checkTimer = new System.Timers.Timer(20000);
            // Hook up the Elapsed event for the timer. 
            checkTimer.Elapsed += OnTimedEvent;
            checkTimer.AutoReset = true;
            checkTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
            foreach(string ip in checkedIPAddresses)
            {
                //Compare peer list to this list and remove
                Console.WriteLine(ip);
            }
            checkedIPAddresses.Clear();
        }
    } 

}

