using DriverETCSApp.Communication.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DriverETCSApp.Communication {
    internal class ReceiverHTTP : Receiver {

        private HttpListener listener;
        private Thread listenerThread;
        private ServerReceiver serverReceiver;
        private UnityReceiver unityReceiver;

        public ReceiverHTTP(string ip) : base(ip) 
        {
            serverReceiver = new ServerReceiver();
            unityReceiver = new UnityReceiver();
        }

        private bool IsServerSource(HttpListenerRequest request)
        {
            return request.RemoteEndPoint.Port == (int)Port.Server;
        }

        protected override void HandleIncomingConnection() {
            while (listener.IsListening) {
                try {
                    // Wait for a request
                    HttpListenerContext context = listener.GetContext();
                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;

                    if (request.HttpMethod == "POST") {
                        using (var reader = new System.IO.StreamReader(request.InputStream, request.ContentEncoding)) {
                            string receivedMessage = reader.ReadToEnd();
                            Console.WriteLine("Message received from client: " + receivedMessage);
                            //serverReceiver.Proccess(receivedMessage);
                            unityReceiver.Proccess(receivedMessage);
                            /*if (IsServerSource(request))
                            {
                                serverReceiver.Proccess(receivedMessage);
                            }
                            else
                            {
                                unityReceiver.Proccess(receivedMessage);
                            }*/
                        }
                        
                        string responseMessage = "Driver received your message!";
                        byte[] buffer = Encoding.UTF8.GetBytes(responseMessage);
                        response.ContentLength64 = buffer.Length;
                        response.OutputStream.Write(buffer, 0, buffer.Length);
                        response.OutputStream.Close();
                    }
                }
                catch (Exception e) {
                    Console.WriteLine("Error in HTTP listener: " + e.Message);
                }
            }
        }

        public override void StartListening() {
            listener = new HttpListener();
            listener.Prefixes.Add("http://"+this.ip+":"+(int)this.port+ "/");
            listener.Start();
            Console.WriteLine("Driver HTTP Server started, listening on " + this.ip + ":" +(int)this.port+"/");

            // Start a background thread to listen for incoming requests
            listenerThread = new Thread(HandleIncomingConnection);
            listenerThread.Start();
        }

        public override void StopListening()
        {
            listener.Stop();
            listenerThread.Abort();
            listener.Close();
        }

        /*~ReceiverHTTP() {
            // Stop the connection when the receiver is the destroyed
            if (listener != null && listenerThread != null)
            {
                listener.Stop();
                listenerThread.Abort();
                listener.Close();
            }
        }*/
    }
}
