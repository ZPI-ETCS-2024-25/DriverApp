using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using System.ComponentModel;

namespace DriverETCSApp.Communication
{
    public class SenderHTTP : Sender
    {
        public SenderHTTP(string ip) : base(ip)
        {
        }

        public override async Task<string> SendMessage(string msg, Port destination)
        {
            string url = "http://" + ip + ":" + (int)destination + "/";

            using (HttpClient client = new HttpClient())
            {
                //client.Timeout = TimeSpan.FromSeconds(3);
                try
                {
                    var content = new StringContent(msg, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseMessage = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Response: " + responseMessage);
                        return responseMessage;
                    }
                    else
                    {
                        Console.WriteLine("Failed to send message: " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("error while sending a message");
                }
                return null;
            }
        }

        public override async Task<string> SendMessageToEndpoint(string msg, Port destination, string endpoint)
        {
            string url = "http://" + ip + ":" + (int)destination + "/" + endpoint + "/";

            using (HttpClient client = new HttpClient())
            {
                //client.Timeout = TimeSpan.FromSeconds(3);
                try
                {
                    //var content = new StringContent(msg, Encoding.UTF8, "application/json");
                    var contentObj = new { Content = msg };
                    var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(contentObj), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseMessage = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Response: " + responseMessage);
                        return responseMessage;
                    }
                    else
                    {
                        Console.WriteLine("Failed to send message: " + response.StatusCode);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("error while sending a message");
                }
                return "";
            }
        }
    }
}
