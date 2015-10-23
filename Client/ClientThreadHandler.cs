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
        private Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Default constructor
        public ClientThreadHandler() { }

        // Overloaded constructor
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
                    string filePath = "C:\\Clinet\\";
                    string fileName = tokens[3];
                    
                    // Internal check
                    Debug.WriteLine("Constructing file [CLIENTTHREADHANDLER]");
                    
                    // Construct the message structure into byte arrays
                    byte[] fileNameByte = Encoding.ASCII.GetBytes(fileName);
                    byte[] fileData = File.ReadAllBytes(filePath + fileName);
                    byte[] clientData = new byte[4 + fileNameByte.Length + fileData.Length];
                    byte[] fileNameLength = BitConverter.GetBytes(fileNameByte.Length);

                    // Internal check
                    Debug.WriteLine("Copying file [CLIENTTHREADHANDLER].");
                    // Copy the first 4 bytes, length of the data file, to the clientData
                    // Start this data at byte 0
                    fileNameLength.CopyTo(clientData, 0);
                    // Copy the filename to the clientdata, starting at byte 5
                    fileNameByte.CopyTo(clientData, 4);
                    // Copy the actual file, but the offset needs to be calculated since
                    //  the length of the filename is unknown
                    fileData.CopyTo(clientData, 4 + fileNameByte.Length);

                    // Internal check
                    Debug.WriteLine("Sending file [CLIENTTHREADHANDLER]");
                    try
                    {
                        // Send the file to the requesting peer
                        clientSocket.SendFile(filePath + fileName);
                        clientSocket.Close();
                    }catch(Exception error)
                    {
                        Debug.WriteLine("Sending file error: " + error.ToString() + " [CLIENTTHREADHANDLER]");
                    }
                }
            }   // End while loop
        }

        public void FileSearch(TcpClient tcpServer, string sendString)
        {
            // TcpClient Variables
            TcpClient tcpPeer = new TcpClient();

            // GUI Form Variables
            ClientForm form = new ClientForm();

            try
            {
                /*
                Sending a message to the server
                */
                // Return the network stream used to send/receive data
                Stream sendStream = tcpServer.GetStream();

                ASCIIEncoding encoding = new ASCIIEncoding();
                // Encode 'sendString' into a stream of bytes
                byte[] streamBytesA = encoding.GetBytes(sendString);

                // Advance current position in this stream by # of bytes written
                sendStream.Write(streamBytesA, 0, streamBytesA.Length);

                Boolean loop = true;
                while (loop)
                {
                    /*
                    Reading a message from the server
                    */
                    Debug.WriteLine("Receiving data from server [CLIENTFORM].");
                    byte[] streamBytesB = new byte[1500];
                    int i = sendStream.Read(streamBytesB, 0, 100);
                    string dataString = "";

                    for (int j = 0; j < i; j++)
                    {
                        //Console.Write(Convert.ToChar(streamBytesB[j]));
                        dataString += Convert.ToChar(streamBytesB[j]);
                    }

                    /*
                    If the received data is related to a peer request then
                    here is where the return string from the server will be
                    parsed, split and handled accordingly.
                    [0] = Keyword
                    [1] = IP Address
                    [2] = Port of requesting client
                    [3] = Request filename
                    */
                    string[] dataArray = dataString.Split(',');

                    if (dataArray[0].Equals("SCL"))
                    {
                        // Print server message in peer listing text box
                        //peerListBox.AppendText(dataString + "\n");
                        loop = false;
                    }
                    else if (dataArray[0].Equals("PPR"))
                    {
                        // PPR, Peer IP, Peer internal host port, File to be Requested
                        //form.peerListBox.AppendText(dataString + "\n");
                        Debug.WriteLine(dataString + " [CLIENTTHREADHANDLER]");

                        try
                        {
                            // Stage 1, Send file request to peer (dataString) is already formatted for this
                            tcpPeer.Connect(dataArray[1], int.Parse(dataArray[2]));
                            sendStream = tcpPeer.GetStream();
                            byte[] streamBytesData = encoding.GetBytes(dataString);
                            sendStream.Write(streamBytesData, 0, streamBytesData.Length);
                            Debug.WriteLine("Stage 2 complete [CLIENTTHREADHANDLER].");
                        }
                        catch (Exception error)
                        {
                            Debug.WriteLine("Stage 1 error: " + error.ToString());
                        }
                    }
                    else
                    {
                        try
                        {
                            string[] tokens = sendString.Split(',');

                            using (var stream = tcpPeer.GetStream())
                            using (var output = File.Create(@"C:\Clinet\" + tokens[1]))
                            {
                                Debug.WriteLine("Receiving file [CLIENTTHREADHANDLER]");

                                // Read the file in chunks of 1KB
                                var buffer = new byte[1024];
                                int bytesread;
                                while((bytesread = stream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    // Create and print the file to the storage folder.
                                    output.Write(buffer, 0, bytesread);
                                }

                                Debug.WriteLine("File created, closing connection [CLIENTTHREADHANDLER]");
                                stream.Close();
                                tcpPeer.Close();
                            }
                        }catch(Exception error)
                        {
                            Debug.WriteLine("File receiver: " + error.ToString());
                        }
                    }
                }
            }
            catch (Exception error)
            {
                //errorTextBox.AppendText(DateTime.Now + "Data failed to send.");
                form.DisplayError(DateTime.Now + "Data failed to send.");
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
