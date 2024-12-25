using Microsoft.AspNetCore.Mvc;

namespace StarSecurityServices.Controllers
{
	public class ClientsController : Controller
	{
		public IActionResult Index()
		{
            ViewBag.Title = "Clients";
            return View();
        }
	}
}
