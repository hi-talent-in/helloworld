using Hello_World.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hello_World.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        

        
    }
}