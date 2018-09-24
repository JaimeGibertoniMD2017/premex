using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premex.API.Model
{
    interface IFizzBuzzSolver
    {
        int GuessNumber { get; set; }
        int FromNumber { get; set; }
        int ToNumber { get; set; }

        string RunFizzBuzz();
        string DoFizzBuzz();
        string DoFizzBuzzOneInteger();
        List<string> PerformFizzBuzzRange();
    }
}
