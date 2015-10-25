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
        private Socket TcpPeerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

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
                    // Internal check
                    Debug.WriteLine("Constructing file [CLIENTTHREADHANDLER]");
                    // Create the requested file
                    string filePath = "C:\\Clinet\\";
                    string fileName = tokens[3];
                    byte[] fnByte = Encoding.ASCII.GetBytes(fileName);
                    byte[] fileData = File.ReadAllBytes(filePath + fileName);
                    byte[] clientData = new byte[4 + fnByte.Length + fileData.Length];
                    byte[] fileNameLength = BitConverter.GetBytes(fnByte.Length);
                    fileNameLength.CopyTo(clientData, 0);
                    fnByte.CopyTo(clientData, 4);
                    fileData.CopyTo(clientData, 4 + fnByte.Length);

                    try
                    {
                        // Connect to the peer
                        TcpPeerSocket.Connect(tokens[4], int.Parse(tokens[2]));
                        // Send the file to the requesting peer
                        Debug.WriteLine("Sending file to " + tokens[4] + ":" + tokens[2] + " [CLIENTTHREADHANDLER]");
                        TcpPeerSocket.Send(clientData);
                        try
                        {
                            // Close the peer socket after the data has been sent
                            Debug.WriteLine("Killing TcpPeerSocket [CLIENTTHREADHANDER].");
                            TcpPeerSocket.Close();
                            //loop = false;
                        }
                        catch(Exception error)
                        {
                            Debug.WriteLine("TcpPeerSocket.Close() error [CLIENTTHREADHANDLER] " + error.ToString());
                        }
                    }catch(Exception error)
                    {
                        Debug.WriteLine("Sending file error: " + error.ToString() + " [CLIENTTHREADHANDLER]");
                    }
                }
                else
                {
                    // Client receives requested file fron TcpClientSocket data variable 'csr'
                    /*
                    byte[] b = new byte[1500];
                    int csr = TcpClientSocket.Receive(b);
                    */
                    try
                    {
                        // Receive the requested file
                        Debug.WriteLine("Receiving requested file.");

                        string receivedPath = "C:\\Clinet\\";
                        int fileNameLen = BitConverter.ToInt32(dataArray, 0);
                        string fileName = Encoding.ASCII.GetString(dataArray, 4, fileNameLen);
                        BinaryWriter bWrite = new BinaryWriter(File.Open(receivedPath + fileName, FileMode.Append));
                        bWrite.Write(dataArray, 4 + fileNameLen, csr - 4 - fileNameLen);

                        try
                        {
                            // Kill the BinaryWriter and close the socket after the file has been received.
                            Debug.WriteLine("Killing the BinaryWriter [CLIENTTHREADHANDER].");
                            bWrite.Close();
                            //TcpClientSocket.Close();
                            //loop = false;
                        }
                        catch(Exception error)
                        {
                            Debug.WriteLine("BinaryWriter kill error [CLIENTTHREADHANDLER] " + error.ToString());
                        }
                    }
                    catch(Exception error)
                    {
                        Debug.WriteLine("File receive error [CLIENTTHREADHANDLER] " + error.ToString());
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
                // sendString = "CFR,filename.extension,clientIPAddress
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
                    byte[] dataArray = new byte[1500];
                    int i = sendStream.Read(dataArray, 0, 100);
                    string dataString = "";

                    for (int j = 0; j < i; j++)
                    {
                        dataString += Convert.ToChar(dataArray[j]);
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
                    
                    string[] tokens = dataString.Split(',');

                    if (tokens[0].Equals("SCL"))
                    {
                        loop = false;
                    }
                    else if (tokens[0].Equals("PPR"))
                    {
                        try
                        {
                            // Stage 1, Send file request to peer (dataString) is already formatted for this
                            // dataString = ("PPR," + PeerIpAddress + ",5500," + RequestedFile)
                            TcpClient tcpPeer = new TcpClient();
                            tcpPeer.Connect(tokens[1], int.Parse(tokens[2]));
                            sendStream = tcpPeer.GetStream();
                            byte[] streamBytesData = encoding.GetBytes(dataString);
                            sendStream.Write(streamBytesData, 0, streamBytesData.Length);

                            try
                            {
                                // Kill the sendStream and tcpPeer connection
                                Debug.WriteLine("Killing sendStream and tcpPeer [CLIENTTHREADHANDLER].");
                                sendStream.Close();
                                tcpPeer.Close();
                            }
                            catch(Exception error)
                            {
                                Debug.WriteLine("sendStream/tcpPeer close failed [CLIENTTHREADHANDLER].");
                            }
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

        public void ServerConnect(TcpClient tcpServer, string servAddress, int servPort)
        {
            // Connect to server
            tcpServer.Connect(servAddress, servPort);
            // Send IP address and file list
            Stream sendStream = tcpServer.GetStream();
            String ipString = GetIpAddress();
            ASCIIEncoding encoding = new ASCIIEncoding();

            /*
            Read the directory "C:\Clinet" for filenames and add them to a string array.
            Then add the contents of the string array to a single comman separated value,
            add it to the encoded stream and send it to the server for registration.
            */
            string[] filenameArray = Directory.GetFiles(@"C:\Clinet")
                .Select(path => Path.GetFileName(path))
                .ToArray();
            string fileString = "";
            foreach (string token in filenameArray)
            {
                fileString += (token + ',');
            }
            /*
            The 'REG' keyword is used by the server to identify that this is a registration call
            made by the client form and that it is to be registered in the serverside database.
            */
            byte[] streamBytesIp = encoding.GetBytes("REG," + ipString + ',' + fileString);
            sendStream.Write(streamBytesIp, 0, streamBytesIp.Length);

            Boolean loop = true;
            while (loop)
            {
                /*
                Reading a message from the server
                */
                byte[] streamBytesB = new byte[100];
                int i = sendStream.Read(streamBytesB, 0, 100);
                string dataString = "";

                for (int j = 0; j < i; j++)
                {
                    //Console.Write(Convert.ToChar(streamBytesB[j]));
                    dataString += Convert.ToChar(streamBytesB[j]);
                }

                if (dataString.Equals("SCL"))
                {
                    loop = false;
                }
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
