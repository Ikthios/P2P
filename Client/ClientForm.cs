﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientForm : Form
    {
        // TcpClient Variable
        TcpClient tcpClient = new TcpClient();
        Stream sendStream;

        public ClientForm()
        {
            InitializeComponent();
            // Set port combo box default value to 6000
            portComboBox.SelectedIndex = 0;
        }

        
        private void newClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            Create a new client window selection in menu list 'Client'
            */
            ClientForm newForm = new ClientForm();
            newForm.ShowDialog();
        }

        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            Exit selection in menu list 'Client'
            */
            this.Close();
        }

        
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            Disconnect selection in menu list 'Server'
            */
            tcpClient.Close();
            connStatBtn.Text = "Disconnected";
            connStatBtn.BackColor = Color.Red;
        }

        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            About dialog box in menu list '?'
            */
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }

        private void startInternalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ClientCore core = new ClientCore();

                // Internal check
                DisplayConnection("Starting internal server.");
                Debug.WriteLine("Starting internal server.");

                // Create and start threads
                Thread clientThread = new Thread(core.StartClientThread);
                clientThread.Start();

                downMonBtn.Text = "Accepting Requests";
                downMonBtn.BackColor = Color.Green;
            }
            catch (Exception error)
            {
                errorTextBox.AppendText(error.ToString());
                DisplayError(error.ToString());
                downMonBtn.Text = "Peer Connection Failed";
                downMonBtn.BackColor = Color.Red;
            }
        }

        /*
        Connection status button code
        */
        private void connStatBtn_Click(object sender, EventArgs e)
        {
            // Get server IP and port number
            string servAddress = addressTextBox.Text;
            string portString = portComboBox.GetItemText(portComboBox.SelectedItem);
            int servPort = int.Parse(portString);

            Cursor.Current = Cursors.WaitCursor;
            connStatBtn.Text = "Connected";
            connStatBtn.BackColor = Color.Green;

            try
            {
                // Connect to server
                tcpClient.Connect(servAddress, servPort);
                // Send IP address and file list
                sendStream = tcpClient.GetStream();
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
                foreach(string token in filenameArray)
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
                        // Print server message in peer listing text box
                        //peerListBox.AppendText(dataString + "\n");
                        loop = false;
                    }
                    else
                    {
                        // Print server message in peer listing text box
                        peerListBox.AppendText(dataString + "\n");
                    }
                }

            }
            catch (Exception error)
            {
                //errorTextBox.AppendText(DateTime.Now + "\n" + error.ToString());
                errorTextBox.AppendText(DateTime.Now + "\nSocket connection refused.");
                connStatBtn.Text = "Disconnected";
                connStatBtn.BackColor = Color.Red;
            }
        }

        /*
        File search button code
        */
        private void fileSearchBtn_Click(object sender, EventArgs e)
        {
            // User entered string to send to the server
            /*
            The 'CFR' keyword is used by the server to identify that this is a request call
            made by the client form for a file hosted by another client.
            */
            String sendString = "CFR," + fileSearchBox.Text;
            // Clear the textbox
            fileSearchBox.Text = "";

            try {
                /*
                Sending a message to the server
                */
                // Return the network stream used to send/receive data
                sendStream = tcpClient.GetStream();

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
                    byte[] streamBytesB = new byte[100];
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
                    */
                    string[] dataArray = dataString.Split(',');

                    if (dataArray[0].Equals("SCL"))
                    {
                        // Print server message in peer listing text box
                        //peerListBox.AppendText(dataString + "\n");
                        loop = false;
                    }
                    else if(dataArray[0].Equals("PPR"))
                    {
                        // PPR, Peer IP, Peer internal host port, File to be Requested
                        peerListBox.AppendText(dataString + "\n");

                        // Stage 1, connect to outside peer internal server
                        tcpClient.Connect(dataArray[1], int.Parse(dataArray[2]));
                        Debug.WriteLine("Stage 1 complete [CLIENTFORM].");

                        try
                        {
                            // Stage 2, Send file request to peer (dataString) is already formatted for this
                            sendStream = tcpClient.GetStream();
                            byte[] streamBytesData = encoding.GetBytes(dataString);
                            sendStream.Write(streamBytesData, 0, streamBytesData.Length);
                            Debug.WriteLine("Stage 2 complete [CLIENTFORM].");
                        }catch(Exception error)
                        {
                            Debug.WriteLine("Stage 2 error: " + error.ToString());
                        }
                        
                        
                    }
                    else
                    {
                        // Print server message in peer listing text box
                        peerListBox.AppendText(dataString + "\n");
                    }
                }
            }
            catch(Exception error)
            {
                errorTextBox.AppendText(DateTime.Now + "Data failed to send.");
            }
        }

        public string GetIpAddress()
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

        public void DisplayConnection(string message)
        {
            peerListBox.AppendText(message + "\n");
        }

        public void DisplayError(string sentError)
        {
            errorTextBox.AppendText(sentError);
        }
    }
}
