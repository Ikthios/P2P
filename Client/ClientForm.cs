using System;
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
        TcpClient tcpServer = new TcpClient();
        TcpClient tcpPeer = new TcpClient();

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
            tcpServer.Close();
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
                // Internal check
                DisplayConnection = ("Starting internal server.");
                Debug.WriteLine("Starting internal server.");

                // Create and start threads
                ClientCore core = new ClientCore();
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

        private void connStatBtn_Click(object sender, EventArgs e)
        {
            /*
            Connection status button code
            */
            // Get server IP and port number
            string servAddress = addressTextBox.Text;
            string portString = portComboBox.GetItemText(portComboBox.SelectedItem);
            int servPort = int.Parse(portString);

            Cursor.Current = Cursors.WaitCursor;
            connStatBtn.Text = "Connected";
            connStatBtn.BackColor = Color.Green;

            try
            {
                ClientThreadHandler cth = new ClientThreadHandler();
                cth.ServerConnect(tcpServer, servAddress, servPort);
            }
            catch (Exception error)
            {
                //errorTextBox.AppendText(DateTime.Now + "\n" + error.ToString());
                errorTextBox.AppendText(DateTime.Now + "\nSocket connection refused.");
                connStatBtn.Text = "Disconnected";
                connStatBtn.BackColor = Color.Red;
            }
        }

        private void fileSearchBtn_Click(object sender, EventArgs e)
        {
            /*
            File search button code
            */
            ClientThreadHandler cth = new ClientThreadHandler();

            /*
            (C)lient (F)ile (R)equest
            The 'CFR' keyword is used by the server to identify that this is a request call
            made by the client form for a file hosted by another client.
            */
            String sendString = "CFR," + fileSearchBox.Text + "," + GetIpAddress();

            // Clear the textbox
            fileSearchBox.Text = "";

            cth.FileSearch(tcpServer, sendString);
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

        public string DisplayConnection
        {
            get { return peerListBox.Text; }
            set { peerListBox.AppendText(value); }
        }

        public void DisplayError(string sentError)
        {
            errorTextBox.AppendText(sentError);
        }
    }
}
