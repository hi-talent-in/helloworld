using Microsoft.AspNetCore.Mvc;

namespace HelloWorldProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string GetName(string Name)
        {
            return Name == null ? "Hello World" : "Hello" + Name;
        }
    }
}
