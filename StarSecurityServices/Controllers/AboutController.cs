using Microsoft.AspNetCore.Mvc;

namespace StarSecurityServices.Controllers
{
	public class AboutController : Controller
	{
        public IActionResult Index()
        {
            ViewBag.Title = "About Us";
            return View();
        }
    }
}
