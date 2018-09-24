using Microsoft.AspNetCore.Mvc;
using Premex.API.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Premex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        // GET api/fizzbuzz/
        [HttpGet()]
        public List<string> Get()
        {
            var InitialSet = new FizzBuzz(0, 1, 100) { };
            return InitialSet.PerformFizzBuzzRange();
        }

        // GET api/fizzbuzz/{id}
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var InitialSet = new FizzBuzz(id, 0, 0) { };
           
            return InitialSet.RunFizzBuzz();
        }
    }
}
