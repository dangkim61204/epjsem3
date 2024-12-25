using Microsoft.AspNetCore.Mvc;

namespace StarSecurityServices.Controllers
{
	public class TestimonialsController : Controller
	{
		public IActionResult Index()
		{
            ViewBag.Title = "Testimonials";
            return View();
        }
	}
}
