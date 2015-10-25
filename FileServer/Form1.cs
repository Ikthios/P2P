using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace FileServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Global variables
        string rd;
        byte[] b1;
        string v;
        int m;
        TcpListener list;
        Int32 port = 5000;
        Int32 port1 = 5500;

        private void Btn_filedest_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Txt_destpath.Text = folderBrowserDialog1.SelectedPath;
                list = new TcpListener(port1);
                list.Start();
                TcpClient client = list.AcceptTcpClient();
                Stream s = client.GetStream();
                b1 = new byte[m];
                s.Read(b1, 0, b1.Length);
                File.WriteAllBytes(Txt_destpath.Text + "\\" + rd.Substring(0, rd.LastIndexOf('.')), b1);
                list.Stop();
                client.Close();
                label1.Text = "File received.";
            }
        }
    }
}
