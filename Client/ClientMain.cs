using System;
using System.Diagnostics;
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

            ClientForm form = new ClientForm();
            ClientCore core = new ClientCore();
            /*
            try
            {
                Thread.Sleep(5000);

                // Internal check
                form.DisplayConnection("Starting internal server.");
                Debug.WriteLine("Starting internal server.");

                // Create and start threads
                Thread clientThread = new Thread(core.StartClientThread);
                clientThread.Start();
            }
            catch (Exception error)
            {
                //errorTextBox.AppendText(error.ToString());
                form.DisplayError(error.ToString());
            }
            */
        }
    }
}
