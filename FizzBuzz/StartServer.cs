using System;

namespace Premex.Client
{
    public class StartServer
    {
        public static void Main(string[] args)
        {
            int guessNumber = 0;
            bool up = true;
            while (up)
            {
                Client client = new Client();         
                client.InitConsole();

                client.RunAsync(guessNumber);

                Console.WriteLine("Do you want to close this application? (Y/n");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Y)
                    up = false;
                client.Dispose();
            }
        }
    }
}
