using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace GUIClient
{
    public partial class Form1 : Form
    {
        MemoryStream ms;
        TcpClient tc;
        NetworkStream ns;
        BinaryWriter bw;

        string GetIpAddress()
        {
            IPHostEntry host;
            string localIp = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach(IPAddress address in host.AddressList)
            {
                if(address.AddressFamily.ToString() == "InterNetwork")
                {
                    localIp = address.ToString();
                }
            }
            return localIp;
        }

        public Form1()
        {
            InitializeComponent();
            txt_ServerIp.Text = GetIpAddress();
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;
            pic_ImageBox.Image = Image.FromFile(path);
            txt_ImagePath.Text = path;
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            try
            {
                ms = new MemoryStream();
                pic_ImageBox.Image.Save(ms, pic_ImageBox.Image.RawFormat);
                byte[] buffer = ms.GetBuffer();
                ms.Close();
                tc = new TcpClient(txt_ServerIp.Text, 6000);
                ns = tc.GetStream();
                bw = new BinaryWriter(ns);
                bw.Write(buffer);
                bw.Close();
                ns.Close();
                tc.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
