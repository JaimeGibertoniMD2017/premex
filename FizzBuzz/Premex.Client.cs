using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Premex.API.Exceptions;
using System;
using System.Net;

namespace Premex.Client
{
    public class Client : IDisposable
    {
        private static int guessNumber;
        static DateTime startingTime = DateTime.Now;
        static DateTime exitTime = DateTime.Now;
        private static int countServerRequests = 0;
        private static int countServerResponses = 0;
        private static bool serviceListeningKeyboard;

        public void RunAsync(int guess)
        {
            serviceListeningKeyboard = true;
            while (serviceListeningKeyboard)
            {
                guessNumber = guess;
                Console.WriteLine("Please enter a value to check: \n\r[Enter \"0\" to continue with a predetermine series (from 1 to 100)]");
                string inputFromConsole = Console.ReadLine();

                try
                {
                    int.TryParse(inputFromConsole, out guessNumber);
                    countServerRequests++;
                    if (guessNumber == 0)
                        using (var client = new WebClient())
                        {
                            GetClientHeaders(client);

                            var result = client.DownloadString("http://localhost:5500/api/fizzbuzz/");
                            var resultList = (JToken)JsonConvert.DeserializeObject(result);

                            foreach (var element in resultList)
                            {
                                Console.WriteLine(element.Value<string>());
                            }
                        }
                    else
                        using (var client = new WebClient())
                        {
                            GetClientHeaders(client);
                            var result = client.DownloadString("http://localhost:5500/api/fizzbuzz/" + guessNumber);
                            Console.WriteLine(Environment.NewLine + result);
                        }
                    countServerResponses++;

                }
                catch (FizzBuzzExceptions e)
                {
                    Console.WriteLine(e.ToString() + " \\n\\rRetry?(Y/n)");
                    ValidateInput();

                    Console.WriteLine(e.Message);
                    Console.Read();
                }
                catch (Exception)
                {
                    Console.WriteLine("An unknown Exception have occurred... \\n\\r Do you want to exit the application (N/y)");
                    ValidateInput();
                }
                finally
                {
                    if (!serviceListeningKeyboard)
                    {
                        ShowServerStats();
                    }
                }
            }
        }

        private static void GetClientHeaders(WebClient client)
        {
            client.Headers.Add("Content-Type:application/json");
            client.Headers.Add("Accept:application/json");
        }

        private static void ShowServerStats()
        {
            Console.WriteLine("Successful Server shutdown at " + DateTime.Now + @" ...\n\r\n\");
            Console.WriteLine("Server finalisation at: \t " + startingTime);
            Console.WriteLine("Server finalisation at: \t " + exitTime);
            string serverTimeUp = ServerTimeUp();
            Console.WriteLine("Server time up: \t" + serverTimeUp);
            Console.WriteLine("Server requests: \t" + countServerRequests);
            Console.WriteLine("Server responses: \t" + countServerResponses);
            Console.WriteLine("Server total operations: \t" + countServerRequests + countServerResponses);
            Console.WriteLine("\n\rServer total successfull operations: \t" + countServerResponses);
        }
        protected static void ValidateInput()
        {
            if (Console.ReadKey().Key != ConsoleKey.Y)
                serviceListeningKeyboard = false;
        }
        protected static string ServerTimeUp()
        {
            string _serverTimeUp = exitTime.Subtract(startingTime).TotalDays.ToString() +
                                                      exitTime.Subtract(startingTime).TotalHours.ToString() +
                                                      exitTime.Subtract(startingTime).TotalMinutes.ToString() +
                                                      exitTime.Subtract(startingTime).TotalSeconds.ToString();
            return _serverTimeUp;
        }
        public void InitConsole()
        {
            Console.Title = "Premex - FizzBuzz Application";
            Console.WindowTop = 0;
            Console.WindowLeft = 0;
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Beep();
            Console.Clear();
        }
        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
