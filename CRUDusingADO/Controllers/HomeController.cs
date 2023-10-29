using CRUDusingADO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUDusingADO.Controllers
{
    public class HomeController : Controller
    {
        UserDAL dal;
        IConfiguration configuration;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            this.configuration = configuration;
            dal = new UserDAL(configuration);
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Users user)
        {
            try {
                int result = dal.Register(user);
                if (result >= 1)
                {
                  return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Error = "something wend wrong";
                    return View();
                }

            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
            
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Users user)
        {
            try
            {
                int result = dal.Login(user);
                if (result >= 1)
                {
                    return RedirectToAction("Index","Book");
                }
                else
                {
                    ViewBag.Error = "Username or Password is Wrong";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
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