using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentRegistration.Infrastructure;
using StudentRegistration.Services.IRepository;
using StudentRegistration.WebPortal.Controllers.AuthorizeSession;

namespace StudentRegistration.WebPortal.Controllers
{          
    public class AdminController : Controller
    {
        //dependecy
        private readonly ApplicationDbContext _DbContext;
        private readonly IStuRegistration _stuRegistration;
        private readonly ILogger<AdminController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISendSMS _sendSMS;
        public AdminController(ApplicationDbContext dbContext, IStuRegistration stuRegistration, ISendSMS sendSMS, ILogger<AdminController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _stuRegistration = stuRegistration;
            _DbContext = dbContext;
            _logger = logger;
            _sendSMS = sendSMS;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        [AuthorizeAction]
        public IActionResult DashBoard()
        {
            return View();
        }
        public IActionResult LogOut()
        {
            _httpContextAccessor.HttpContext.Session.Remove("user");//to remove current session
            _httpContextAccessor.HttpContext.Session.Clear();//to remove all session 
            return RedirectToAction("Login", "Home");
        }
        
    }
}