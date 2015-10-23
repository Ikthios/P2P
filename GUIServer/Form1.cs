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
using System.Threading;

namespace GUIServer
{
    public partial class Form1 : Form
    {
        TcpListener tl;
        Socket skt;
        NetworkStream ns;
        StreamReader sr;
        Thread th;

        void ReceiveImage()
        {
            try
            {
                tl = new TcpListener(6000);
                tl.Start();
                skt = tl.AcceptSocket();
                ns = new NetworkStream(skt);
                pic_ImageBox.Image = Image.FromStream(ns);
                tl.Stop();
                if (skt.Connected == true)
                {
                    while (true)
                    {
                        ReceiveImage();
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Form1()
        {
            InitializeComponent();
            th = new Thread(new ThreadStart(ReceiveImage));
            th.Start();
        }
    }
}
