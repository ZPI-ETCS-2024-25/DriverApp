using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq.Expressions;

namespace DriverETCSApp {
    internal class SenderHTTP : Sender {
        public SenderHTTP(string ip) : base(ip) {
        }

        public override async Task<string> SendMessage(string msg, Port destination) {
            string url = "http://" + ip + ":" + (int)destination + "/";

            using (HttpClient client = new HttpClient()) {
                try {
                    var content = new StringContent(msg, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode) {
                        string responseMessage = await response.Content.ReadAsStringAsync();
                        return responseMessage;
                        //Console.WriteLine("Response: " + responseMessage);
                    }
                    else {
                        Console.WriteLine("Failed to send message: " + response.StatusCode);
                    }
                }
                catch (Exception e) {
                    Console.WriteLine("error while sending a message");
                }
                return null;
            }
        }
    }
}
