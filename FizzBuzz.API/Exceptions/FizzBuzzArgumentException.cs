using System;
using System.Runtime.Serialization;

namespace Premex.API.Exceptions
{    
    [Serializable]
    public class FizzBuzzExceptions : ArgumentException
    {
        public FizzBuzzExceptions()
        {
                                                                            
        }
        public FizzBuzzExceptions(string message) : base(message)
        {
            Console.WriteLine("The input provided isn't valid");
        }
    }          
}
