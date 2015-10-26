using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Client
{
    class ClientThreadHandler : ClientForm
    {
        // Global variables
        private Socket TcpClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        ClientMethods cm = new ClientMethods();

        // Default constructor
        public ClientThreadHandler() { }

        // Overloaded constructor
        public ClientThreadHandler(Socket client)
        {
            this.TcpClientSocket = client;
        }

        public void StartHandling()
        {
            // Internal check
            Debug.WriteLine("Starting clientHandler [CLIENTTHREADHANDLER]");

            /*
            This is where the client will accept peer connections
            and handle request/file transactions.
            */
            Boolean loop = true;
            ASCIIEncoding encoding = new ASCIIEncoding();
            while (loop)
            {
                byte[] dataArray = new byte[1500];              // Create byte array for receiving client data
                                                                // 1500 bytes is the standard TCP file transfer size
                int csr = TcpClientSocket.Receive(dataArray);   // Receive the peer data
                // csr = (C)lient (S)end (R)equest
                string dataString = "";                         // This will hold the raw data coming in from the connected peer

                // Build the message
                for (int i = 0; i < csr; i++)
                {
                    dataString += Convert.ToChar(dataArray[i]);
                }
                /*
                This will split/organize the raw data into a format
                the peer server can understand.
                [0] = Keyword
                [1] = IP Address of hosting peer
                [2] = Port of requesting peer
                [3] = Request filename
                [4] = IP Address of requesting peer
                */
                string[] tokens = dataString.Split(',');

                /*
                (P)eer to (P)eer (R)equest
                The 'PPR' keyword is used by the client to identify that the incoming
                data is from another peer requesting a locally hosted file.
                */
                if (tokens[0].Equals("PPR"))
                {
                    try
                    {
                        cm.SendFile(tokens[2], tokens[3], tokens[4]);
                        //loop = false;
                        break;
                    }
                    catch(Exception error)
                    {
                        Debug.WriteLine("File send error: " + error.ToString());
                    }
                }
                else
                {
                    try
                    {
                        cm.ReceiveFile(TcpClientSocket, dataArray, csr);
                        //loop = false;
                        //break;
                    }
                    catch(Exception error)
                    {
                        Debug.WriteLine("File receive error: " + error.ToString());
                    }
                }
            }   // End while loop
        }
    }
}
