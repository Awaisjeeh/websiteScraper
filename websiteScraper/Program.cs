//using HtmlAgilityPack;
//using System;
//using System.Net.Http;
//using System.IO;
//using System.Security.Cryptography.X509Certificates;
//namespace WebScraper
//{
//    class Program
//    {
//        static void Main(String[] args)
//        {
//            // Send get request to ucp.edu.pk
//            String url = "https://ucp.edu.pk/";
//            var httpClient = new HttpClient();
//            var html = httpClient.GetStringAsync(url).Result;
//            var htmlDocument = new HtmlDocument();
//            htmlDocument.LoadHtml(html);

//            // Get the dean message
//            var MessageElement = htmlDocument.DocumentNode.SelectSingleNode("//*[@id=\"content\"]/article/div[3]/div/div[1]/div/div/div/div[2]/div[2]/p/text()");
//            var message = MessageElement.InnerText.Trim();

//            Console.WriteLine("Chairman Message from Ucp: " + message);
//            writeCSV(message);

//        }
//        public static string[] readCSV(string url)
//        {

//        }

//        private static void writeCSV(string message)
//        {

//            try
//            {

//                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"filepath.txt", true))
//                {
//                    file.WriteLine(message);
//                }
//            }
//            catch (Exception ex) {
//                throw new Exception("Error in file: ", ex);
//            }
//            }
//    }
//}