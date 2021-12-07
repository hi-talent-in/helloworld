using Microsoft.AspNetCore.Mvc;

namespace HelloWorldProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet(Name = "GetString")]

        public String GET()
        {
            return "Hello World";

        }
    }
}
