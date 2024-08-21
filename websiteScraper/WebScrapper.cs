using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace WebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to your CSV file containing URLs
            string csvFilePath = "urls.txt";

            // Read URLs from the CSV file
            var urls = readCSV(csvFilePath);

            foreach (var url in urls)
            {
                try
                {
                    // Send GET request to each URL
                    var httpClient = new HttpClient();
                    var html = httpClient.GetStringAsync(url).Result;
                    var htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(html);

                    // Get the Dean's message
                    var MessageElement = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"content\"]/article/div[3]/div/div[1]/div/div/div/div[2]/div[2]/p");
                    if (MessageElement != null)
                    {
                        var message = MessageElement.InnerText.Trim();
                        Console.WriteLine("Chairman Message from Ucp: " + message);

                        // Write the message to a file
                        writeCSV(message);
                    }
                    else
                    {
                        Console.WriteLine("Message element not found for URL: " + url);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        public static List<string> readCSV(string filePath)
        {
            var urls = new List<string>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            urls.Add(line.Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading CSV file: " + ex.Message);
            }

            return urls;
        }

        private static void writeCSV(string message)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(@"output.txt", true))
                {
                    file.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
            }
        }
    }
}
