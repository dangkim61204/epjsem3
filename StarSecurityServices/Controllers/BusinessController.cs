using Microsoft.AspNetCore.Mvc;

namespace StarSecurityServices.Controllers
{
    public class BusinessController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Our Business";
            return View();
        }
    }
}
