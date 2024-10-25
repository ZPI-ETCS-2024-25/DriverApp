﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace DriverETCSApp {
    internal class SenderHTTP : Sender {
        public SenderHTTP(string ip) : base(ip) {
        }

        public override async Task<string> SendMessage(string msg, Port destinationm, string endpoint) {
            string url = "http://" + ip + ":" + (int)destination + "/" + endpoint + "/";

            using (HttpClient client = new HttpClient()) {
                try {
                    var content = new StringContent(msg, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode) {
                        string responseMessage = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Response: " + responseMessage);
                        return responseMessage;
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
