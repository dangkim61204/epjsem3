using Microsoft.AspNetCore.Mvc;
using StarSecurityServices.Models;
using System.Diagnostics;

namespace StarSecurityServices.Controllers
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
            ViewBag.Title = "Home";
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        public IActionResult Business()
        {
            ViewBag.Title = "Our Business";
            return View();
        }

        public IActionResult Careers()
        {
            ViewBag.Title = "Careers";
            return View();
        }

        public IActionResult Clients()
        {
            ViewBag.Title = "Clients";
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Title = "Contact";
            return View();
        }

        public IActionResult Network()
        {
            ViewBag.Title = "Our Network";
            return View();
        }

        public IActionResult Testimonials()
        {
            ViewBag.Title = "Testimonials";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.Title = "Privacy";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
