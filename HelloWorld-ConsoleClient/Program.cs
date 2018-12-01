using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

namespace HelloWorld_ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var endpoint = ConfigurationManager.AppSettings["apiEndpoint"];
                var apiKey = ConfigurationManager.AppSettings["apiKey"];

                if (string.IsNullOrWhiteSpace(endpoint))
                {
                    throw new ConfigurationErrorsException($"Configuration missing: {nameof(endpoint)}");
                }

                if (string.IsNullOrWhiteSpace(apiKey))
                {
                    throw new ConfigurationErrorsException($"Configuration missing: {nameof(apiKey)}");
                }

                var client = new HttpClient();
                var requestUri = new Uri($"{endpoint}/{apiKey}");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(requestUri.AbsoluteUri);

                if (response.Result.IsSuccessStatusCode)
                {
                    var result = response.Result.Content.ReadAsAsync<MessageGetResultModel>().Result;

                    if (result == null)
                    {
                        throw new Exception("Unable to deserialize response into MessageGetResultModel");
                    }

                    if (result.ResultStatusCode == MessageGetResultStatus.Error)
                    {
                        throw new Exception("An error was thrown at the API endpoint");
                    }

                    if (result.ResultStatusCode == MessageGetResultStatus.NoResults)
                    {
                        throw new Exception("No message was found for the given API key");
                    }

                    if (result.Message == null)
                    {
                        throw new Exception("No error thrown by endpoint but message was missing");
                    }

                    Console.WriteLine($"Message received from endpoint: {result.Message.Message}");
                    Console.WriteLine($"Message Mode: {result.Message.Mode}");
                }
                else
                {
                    throw new Exception($"Request failed: {response.Result.ReasonPhrase} ({response.Result.StatusCode})");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write(ex.StackTrace);
            }
        }
    }
}
