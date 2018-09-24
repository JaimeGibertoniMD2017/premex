using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Xunit;

namespace Premex.Tests
{
    public class Client
    {

        int[] valuesToTest = new int[4];

        [Fact]
        public void HttpServerAlive()
        {
            bool value = PingHost("127.0.0.1", 5500);
            Assert.True(value);
        }

        [Fact]
        public void RunAsynchronousCallsFrom1To100()
        {
            var clientRangeFrom1To100 = GetClientRange();

            Assert.Contains("Fizz", clientRangeFrom1To100[3 - 1]);
            Assert.Contains("Buzz", clientRangeFrom1To100[5 - 1]);
            Assert.Contains("FizzBuzz", clientRangeFrom1To100[15 - 1]);
            Assert.Contains("7", clientRangeFrom1To100[7 - 1]);
        }

        [Fact]
        public void RunAsynchronousCallForOneNumber()
        {
            var clientOneNumberFizz = GetClientOne(3);
            var clientOneNumberBuzz = GetClientOne(5);
            var clientOneNumberFizzBuzz = GetClientOne(15);
            var clientOneNumberInRange = GetClientOne(17);

            Assert.Contains("Fizz", clientOneNumberFizz);
            Assert.Contains("Buzz", clientOneNumberBuzz);
            Assert.Contains("FizzBuzz", clientOneNumberFizzBuzz);
            Assert.Contains("17", clientOneNumberInRange );
        }


        private static bool PingHost(string hostUri, int portNumber)
        {
            try
            {
                using (Ping webAPIHost = new Ping())
                {
                    PingReply reply = webAPIHost.Send(hostUri, portNumber);
                }
                return true;
            }
            catch (SocketException)
            {
                return false;
            }
        }
        private static List<string> GetClientRange()
        {
            using (var client = new WebClient())
            {
                GetClientHeaders(client);

                var result = client.DownloadString("http://localhost:5500/api/fizzbuzz/");
                var resultList = (JToken)JsonConvert.DeserializeObject(result);

                List<string> toReturn = new List<string>() { };
                foreach (var element in resultList)
                {
                    toReturn.Add(element.Value<string>());
                }
                return toReturn;
            }
        }
        private static string GetClientOne(int guessNumber)
        {
            using (var client = new WebClient())
            {
                GetClientHeaders(client);
                var result = client.DownloadString("http://localhost:5500/api/fizzbuzz/" + guessNumber);
                return result;
            }                     
        }
        private static void GetClientHeaders(WebClient client)
        {
            client.Headers.Add("Content-Type:application/json");
            client.Headers.Add("Accept:application/json");
        }
    }
}
