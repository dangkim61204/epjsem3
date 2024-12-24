using Microsoft.AspNetCore.Mvc;

namespace StarSecurityServices.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Contact";
            return View();
        }
    }
}
