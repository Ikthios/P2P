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

namespace Client
{
    class ClientThreadHandler
    {
        // Global variables
        private Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public ClientThreadHandler(Socket client)
        {
            this.clientSocket = client;
        }

        public void StartHandling()
        {
            Thread handler = new Thread(clientHandler);
            handler.Start();

            // Internal check
            Debug.WriteLine("Looping new handler [CLIENTTHREADHANDLER]");
        }

        public void clientHandler()
        {
            // Internal check
            Debug.WriteLine("Starting clientHander [CLIENTTHREADHANDLER]");

            /*
            This is where the client will accept peer connections
            and handle request/file transactions.
            */
            Boolean loop = true;
            ASCIIEncoding encoding = new ASCIIEncoding();
            while (loop)
            {
                byte[] b = new byte[1500];          // Create byte array for receiving client data
                                                    // 1500 bytes is the standard TCP file transfer size
                int csr = clientSocket.Receive(b);  // Receive the peer data
                string dataString = "";             // This will hold the raw data coming in from the connected peer

                // Build the message
                for (int i = 0; i < csr; i++)
                {
                    dataString += Convert.ToChar(b[i]);
                }
                /*
                This will split/organize the raw data into a format
                the server can understand.
                [0] = Keyword
                [1] = IP Address
                [2] = Port of requesting client
                [3] = Request filename
                */
                string[] tokens = dataString.Split(',');

                /*
                (P)eer to (P)eer (R)equest
                The 'PPR' keyword is used by the client to identify that the incoming
                data is from another peer requesting a locally hosted file.
                */
                if (tokens[0].Equals("PPR"))
                {
                    string fileName = tokens[3];
                    string filePath = "C:\\Clinet\\";

                    // Internal check
                    ClientForm clientForm = new ClientForm();
                    clientForm.DisplayConnection("Constructing file...");

                    // Construct the message structure into byte arrays
                    byte[] fileNameByte = Encoding.ASCII.GetBytes(fileName);
                    byte[] fileData = File.ReadAllBytes(filePath + fileName);
                    byte[] clientData = new byte[4 + fileNameByte.Length + fileData.Length];
                    byte[] fileNameLength = BitConverter.GetBytes(fileNameByte.Length);

                    // Internal check
                    clientForm.DisplayConnection("Copying file...");
                    fileNameLength.CopyTo(clientData, 0);
                    fileNameByte.CopyTo(clientData, 4);
                    fileData.CopyTo(clientData, 4 + fileNameByte.Length);

                    // Internal check
                    clientForm.DisplayConnection("Sending file...");
                    clientSocket.Send(clientData);
                }
                else
                {
                    /*
                    If the datastring consists of a file there will be no keyword.
                    This code section will then collect the file, reconstruct it and
                    store it in 'C:\Clinet'.
                    */

                }
            }
        }

        private string GetIpAddress()
        {
            string ipAddress = String.Empty;
            // Get all IP addresses using the local hostname
            foreach (IPAddress ipa in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                {
                    // Grab the first IP address that matches the local IP address
                    ipAddress = ipa.ToString();
                    break;
                }
            }

            return ipAddress.ToString();
        }
    }
}
