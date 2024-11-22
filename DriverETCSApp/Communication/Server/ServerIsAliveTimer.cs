using DriverETCSApp.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DriverETCSApp.Communication.Server
{
    public class ServerIsAliveTimer
    {
        ServerSender ServerSender;
        MainForm MainForm;
        private Thread Thread;

        public ServerIsAliveTimer(ServerSender serverSender, MainForm mainForm)
        {
            ServerSender = serverSender;
            MainForm = mainForm;
        }

        public void Stop()
        {
            Thread?.Abort();
        }

        public void Start()
        {
            Thread = new Thread(Run);
            Thread.Start();
        }

        private async void Run()
        {
            while (true)
            {
                Thread.Sleep(30000);
                bool isAlive = false;
                while (!isAlive)
                {
                    isAlive = await ServerSender.SendIsAliveRequest();
                    if (!isAlive)
                    {
                        MainForm.ShowMessage();
                    }
                }
            }
        }
    }
}
