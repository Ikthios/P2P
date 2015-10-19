using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    static class ClientMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ClientForm());

            // Check for file storage directory in the C: drive.
            if (!Directory.Exists(@"C:\Clinet")){
                Directory.CreateDirectory(@"C:\Clinet");
            }
        }
    }
}
