using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace Client
{
    class ClientMethods
    {
        public void SendFile(string port, string file, string peerIp)
        {
            // Internal check
            Debug.WriteLine("Constructing file [CLIENTTHREADHANDLER]");
            // Create the requested file
            string filePath = @"C:\Clinet\";
            string fileName = file;
            byte[] fnByte = Encoding.ASCII.GetBytes(fileName);
            byte[] fileData = File.ReadAllBytes(filePath + fileName);
            byte[] clientData = new byte[4 + fnByte.Length + fileData.Length];
            byte[] fileNameLength = BitConverter.GetBytes(fnByte.Length);
            fileNameLength.CopyTo(clientData, 0);
            fnByte.CopyTo(clientData, 4);
            fileData.CopyTo(clientData, 4 + fnByte.Length);

            try
            {
                Socket TcpPeerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Connect to the peer
                TcpPeerSocket.Connect(peerIp, int.Parse(port));
                // Send the file to the requesting peer
                Debug.WriteLine("Sending file " + file + " to " + peerIp + ":" + port + " [CLIENTTHREADHANDLER]");
                TcpPeerSocket.Send(clientData);
                try
                {
                    // Close the peer socket after the data has been sent
                    Debug.WriteLine("Killing TcpPeerSocket [CLIENTTHREADHANDER].");
                    TcpPeerSocket.Close();
                }
                catch (Exception error)
                {
                    Debug.WriteLine("TcpPeerSocket.Close() error [CLIENTTHREADHANDLER] " + error.ToString());
                }
            }
            catch (Exception error)
            {
                Debug.WriteLine("Sending file error: " + error.ToString() + " [CLIENTTHREADHANDLER]");
            }
        }

        public void ReceiveFile(Socket TcpClientSocket, byte[] dataArray, int csr)
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

                string receivedPath = @"C:/Clinet/";
                int fileNameLen = BitConverter.ToInt32(dataArray, 0);
                string fileName = Encoding.ASCII.GetString(dataArray, 4, fileNameLen);
                BinaryWriter bWrite = new BinaryWriter(File.Open(receivedPath + fileName, FileMode.Create/*FileMode.Append, FileAccess.Write*/));
                bWrite.Write(dataArray, 4 + fileNameLen, csr - 4 - fileNameLen);

                try
                {
                    // Kill the BinaryWriter and close the socket after the file has been received.
                    Debug.WriteLine("Killing the BinaryWriter [CLIENTTHREADHANDER].");
                    bWrite.Close();
                    TcpClientSocket.Close();
                    //loop = false;
                }
                catch (Exception error)
                {
                    Debug.WriteLine("BinaryWriter kill error [CLIENTTHREADHANDLER] " + error.ToString());
                }
            }
            catch (Exception error)
            {
                Debug.WriteLine("File receive error [CLIENTTHREADHANDLER] " + error.ToString());
            }
        }
    }
}
