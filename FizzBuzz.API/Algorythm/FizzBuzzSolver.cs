using Newtonsoft.Json;
using Premex.API.Exceptions;
using System;
using System.Collections.Generic;

namespace Premex.API.Model
{
    public class FizzBuzz : IFizzBuzzSolver
    {
        public int GuessNumber
        {
            get;
            set;
        }
        public int FromNumber
        {
            get;
            set;
        }
        public int ToNumber
        {
            get;
            set;
        }

        public FizzBuzz(int guessNumber, int fromNumber, int toNumber)
        {
            GuessNumber = guessNumber;
            FromNumber = fromNumber;
            ToNumber = toNumber;

        }

        public string RunFizzBuzz()
        {
            if (Math.Abs(ToNumber - FromNumber) < 0)
                throw new FizzBuzzExceptions();

            if (GuessNumber == 0)
                return DoFizzBuzz();
            return DoFizzBuzzOneInteger();
        }
        public string DoFizzBuzz()
        {
            return JsonConvert.SerializeObject(PerformFizzBuzzRange());
        }
        public string DoFizzBuzzOneInteger()
        {
            var oneInteger = PerformFizzBuzzRange().ToArray()[0];
            return oneInteger;
        }
        public List<string> PerformFizzBuzzRange()
        {
            if (GuessNumber != 0)
            {
                FromNumber = ToNumber = GuessNumber;
            }
            List<string> fizzBuzzResult = new List<string>();
            string temporaryValue;
            for (int i = FromNumber; i <= ToNumber; i++)
            {
                temporaryValue = String.Empty;
                if (i % 3 != 0 && i % 5 != 00)
                {
                    fizzBuzzResult.Add(i.ToString());
                    continue;
                }

                if (i % 3 == 0)
                    temporaryValue = "Fizz";
                if (i % 5 == 0)
                    temporaryValue += "Buzz";

                fizzBuzzResult.Add(temporaryValue);
            }
            return fizzBuzzResult;
        }
    }
}



