using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HELLO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        // GET api/HelloWorld?id=value
        //[HttpGet]
        //public string Get()
        //{
        //    return  "Hello world";
        //}
        //// GET api/helloworld/yourname
        //[HttpGet("{id}")]
        //public string Get(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        return "Hello World.";
        //    }
        //    else {
        //        return "Hello World "+id;
        //    }
        //}

        //GET api/HelloWorld? id = value

        [HttpGet]
        public string Get([FromQuery]string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return $"Hello World";
            }
            else
            {
                return $"Hello {id}";
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
