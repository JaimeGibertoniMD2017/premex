using System;
using Xunit;
using Premex.API;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Premex.Tests
{
    public class Server
    {
        [Fact]
        public void WebAPI_HTTP_Verb_Get_Call()
        {
            string GetOneValueFizz = GetClientOne(9);
            string GetOneValueBuzz = GetClientOne(25);
            string GetOneValueFizzBuzz = GetClientOne(45);
            string GetOneValue = GetClientOne(97);
            List<string> Get100ValuesWithFizzBuzz = GetClientRange();

            Assert.Contains("Fizz", GetOneValueFizz);
            Assert.Contains("Buzz", GetOneValueBuzz);
            Assert.Contains("FizzBuzz", GetOneValueFizzBuzz);
            Assert.Contains("97", GetOneValue);          
        }

        [Fact]
        public void WebAPI_HTTP_Verb_GetbyId_Call()
        {
            string GetOneValueFizz = GetClientOne(3);
            string GetOneValueBuzz = GetClientOne(5);
            string GetOneValueFizzBuzz = GetClientOne(15);
            string GetOneValue = GetClientOne(17);

            Assert.Contains("Fizz", GetOneValueFizz);
            Assert.Contains("Buzz", GetOneValueBuzz);
            Assert.Contains("FizzBuzz", GetOneValueFizzBuzz);
            Assert.Contains("17", GetOneValue);
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
