using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using Console = System.Console;

namespace HelloWorld.ConsoleClient
{
    public class Program
    {
        public static void Main(string[] args)
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
                    var successResult = response.Result.Content.ReadAsAsync<MessageQueryResultModel>().Result;

                    if (successResult == null)
                    {
                        throw new Exception("Unable to deserialize response into MessageQueryResultModel");
                    }

                    if (successResult.ResultStatusCode == MessageQueryResultStatus.Error)
                    {
                        throw new Exception("An error was thrown at the API endpoint");
                    }

                    if (successResult.ResultStatusCode == MessageQueryResultStatus.NoResults)
                    {
                        throw new Exception("No message was found for the given API key");
                    }

                    if (successResult.Message == null)
                    {
                        throw new Exception("No error thrown by endpoint but message was missing");
                    }

                    Console.WriteLine($"Message received from endpoint: {successResult.Message.Message}");
                    Console.WriteLine($"Message Mode: {successResult.Message.Mode}");
                }
                else
                {
                    var failResult = response.Result.Content.ReadAsAsync<ErrorGetResultModel>().Result;

                    Console.WriteLine($"Request failed: {response.Result.ReasonPhrase} ({(int)response.Result.StatusCode})");

                    throw new Exception($"Remote failure message: {failResult.ExceptionMessage}");
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
