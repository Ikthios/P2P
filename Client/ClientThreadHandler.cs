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

        // Default constructor
        public ClientThreadHandler() { }

        // Overloaded constructor
        public ClientThreadHandler(Socket client)
        {
            this.TcpClientSocket = client;
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
                int csr = TcpClientSocket.Receive(b);  // Receive the peer data
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

                    TcpClient sendPeer = new TcpClient(tokens[1], int.Parse(tokens[2]));
                    Stream peerStream = sendPeer.GetStream();
                    byte[] fileArray = File.ReadAllBytes(filePath + fileName);
                    peerStream.Write(fileArray, 0, fileArray.Length);
                    sendPeer.Close();
                    Debug.WriteLine("File transferred [CLIENTTHREADHANDLER]");

                    // Internal check
                    Debug.WriteLine("Sending file [CLIENTTHREADHANDLER]");
                    try
                    {
                        // Send the file to the requesting peer
                        //clientSocket.SendFile(filePath + fileName);
                    }catch(Exception error)
                    {
                        Debug.WriteLine("Sending file error: " + error.ToString() + " [CLIENTTHREADHANDLER]");
                    }
                }
            }   // End while loop
        }

        public void FileSearch(TcpClient tcpServer, string sendString)
        {
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

                sendStream.Close();
                
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
                        dataString += Convert.ToChar(streamBytesB[j]);
                    }

                    /*
                    If the received data is related to a peer request then
                    here is where the return string from the server will be
                    parsed, split and handled accordingly.
                    [0] = Keyword
                    [1] = IP Address (Outside peer)
                    [2] = Port of requesting client (Outside Peer)
                    [3] = Request filename
                    */
                    
                    string[] dataArray = dataString.Split(',');

                    if (dataArray[0].Equals("SCL"))
                    {
                        loop = false;
                    }
                    else if (dataArray[0].Equals("PPR"))
                    {
                        try
                        {
                            TcpClient tcpPeer = new TcpClient();

                            // Stage 1, Send file request to peer (dataString) is already formatted for this
                            tcpPeer.Connect(dataArray[1], int.Parse(dataArray[2]));
                            sendStream = tcpPeer.GetStream();
                            byte[] streamBytesData = encoding.GetBytes(dataString);
                            // Sending Format: [PPR Keyword, Peer IP, Peer internal host port, File to be Requested]
                            sendStream.Write(streamBytesData, 0, streamBytesData.Length);
                        }
                        catch (Exception error)
                        {
                            Debug.WriteLine("Stage 1 error: " + error.ToString());
                        }
                    }
                }
            }
            catch (Exception error)
            {
                Debug.WriteLine(error.ToString());
            }
        }

        public string GetIpAddress()
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
