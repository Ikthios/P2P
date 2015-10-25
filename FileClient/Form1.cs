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

namespace FileClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Global variables
        string n;
        byte[] b1;
        OpenFileDialog op;

        private void Btn_browse_Click(object sender, EventArgs e)
        {
            op = new OpenFileDialog();
            if(op.ShowDialog() == DialogResult.OK)
            {
                string t = Txt_filepath.Text;
                t = op.FileName;
                FileInfo fi = new FileInfo(Txt_filepath.Text = op.FileName);
                n = fi.Name + "." + fi.Length;
                TcpClient client = new TcpClient("192.168.0.65", 5000);
                StreamWriter sw = new StreamWriter(client.GetStream());
                sw.WriteLine(n);
                sw.Flush();
            }
        }

        private void Btn_send_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient("192.168.0.65", 5000);
            Stream s = client.GetStream();
            b1 = File.ReadAllBytes(op.FileName);
            s.Write(b1, 0, b1.Length);
            client.Close();
        }
    }
}
