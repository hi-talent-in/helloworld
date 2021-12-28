using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.Infrastructure;
using StudentRegistration.Property;
using StudentRegistration.Services.IRepository;
using StudentRegistration.WebPortal.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using SMSSENDER;
using Microsoft.AspNetCore.Routing;
using System.Security.Cryptography;

namespace StudentRegistration.WebPortal.Controllers
{
    public class HomeController : Controller
    {
        //dependecy
        private readonly ApplicationDbContext _DbContext;
        private readonly IStuRegistration _stuRegistration;
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISendSMS _sendSMS;
        public HomeController(ApplicationDbContext dbContext, IStuRegistration stuRegistration, ISendSMS sendSMS, ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _stuRegistration = stuRegistration;
            _DbContext = dbContext;
            _logger = logger;
            _sendSMS = sendSMS;
        }
        [NonAction]
        public void ddlTypeOfOrganization()
        {
            ViewBag.TypeOfOrganization = _stuRegistration.GetTypeOfOrganizations();
        }
        [NonAction]
        public void ddlCountry()
        {
            ViewBag.Country = _stuRegistration.GetCountries();
        }
        [HttpGet]
        public JsonResult GetState(string CountryId)
        {
            List<State> Statelist = _stuRegistration.GetState(CountryId);
            return new JsonResult(Statelist);
        }
        [HttpGet]
        public JsonResult GetCity(string StateId)
        {
            List<City> Citylist = _stuRegistration.GetCity(StateId);
            return new JsonResult(Citylist);
        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            //firt logout after that login 
            //logout();
            //login start here
            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };
            var u = GetCookie("u");
            var p = GetCookie("p");
            if (u != null && p != null)
            {
                model.UserId = u;
                model.Password = p;
                model.RememberMe = true;
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var User = _stuRegistration.GetLogin(model.UserId, model.Password);
                    if (User != null)
                    {
                        if (User.IsActive == true)
                        {
                            if (model.RememberMe)
                            {
                                SetCookie("u", model.UserId, 600);
                                SetCookie("p", model.Password, 600);
                                ViewBag.msg = "Your are login successfully.";
                            }
                            else
                            {
                                RemoveCookie("u");
                                RemoveCookie("p");
                            }
                            //add session variable here 
                            _httpContextAccessor.HttpContext.Session.SetString("user", model.UserId);
                            _logger.LogInformation("LogUserloggedin");
                            return RedirectToAction("dashboard", "Admin");
                        }
                    }
                    else
                    {
                        ViewBag.msg = "Invalid Userid or Password.";
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login credential.");
                }
            }
            catch (Exception ex)
            {
                ViewBag.msg = "Due to some technical problem,We are unable to process your request.";
            }
            return View(model);
        }
        public void SetCookie(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
            {
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            }
            else
            {
                option.Expires = DateTime.Now.AddMilliseconds(10);
                _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, option);
            }
        }
        public void RemoveCookie(string key)
        {
            Response.Cookies.Delete(key);
        }
        public string GetCookie(string key)
        {
            return _httpContextAccessor.HttpContext.Request.Cookies[key];
        }
        [HttpGet]
        public IActionResult Index()
        {
            //to bind dropdown list
            ddlCountry();
            ddlTypeOfOrganization();
            return View();
        }

        [NonAction]
        public string GenerateOTP()
        {
            Random randobj = new Random();
            return randobj.Next(1000, 9999).ToString();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(RegisterStudent Model)
        {
            try
            {
                var otp = GenerateOTP();
                bool b = _stuRegistration.AddRegistration(Model, otp);
                if (b == true)
                {
                    SMSSend.SENDSMS(Model.Mobile, otp.ToString());
                    ViewBag.massage = "You have been registered successfully.";
                }
                else
                {
                    ViewBag.massage = "Sorry! you are unable to registered.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.massage = "Due to some technical problem,We are unable to process your request.";
            }
            //to bind dropdown list
            ddlCountry();
            ddlTypeOfOrganization();
            return RedirectToAction("VerifyOTP", new RouteValueDictionary(new
            {
                Action = "VerifyOTP",
                Controller = "HOME",
                mobno = Model.Mobile
            }
            ));

        }
        [HttpGet]
        public IActionResult SendSMS()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendSMS(string OTP)
        {
            return View();
        }
        [HttpGet]
        public IActionResult VerifyOTP(string mobno)
        {
            if (mobno != "" || !string.IsNullOrEmpty(mobno))
            {
                ViewBag.mobno = mobno;
            }
            return View();
        }
        [HttpPost]
        public IActionResult VerifyOTP(string mobno, string otp)
        {
            if (mobno != "" || !string.IsNullOrEmpty(mobno))
            {
                ViewBag.mobno = mobno;
            }
            //verify from database           
            if (!string.IsNullOrEmpty(otp) && !string.IsNullOrEmpty(mobno))
            {
                bool b = _stuRegistration.VerifyOTP(mobno, otp);
                if (b == true)
                {
                    //verify successfully.
                    ViewBag.error = "VerifyOTP Successfully.";
                }
                else
                {
                    //unable to varify.
                    ViewBag.error = "Sorry!Unable VerifyOTP";
                }
            }
            else
            {
                ViewBag.error = "Please Enter OTP";
            }
            return RedirectToAction("Login", "Home");
        }
        public IActionResult GetAllRecord()
        {
            var list = _stuRegistration.RegisterStudentList();
            return View(list);
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
