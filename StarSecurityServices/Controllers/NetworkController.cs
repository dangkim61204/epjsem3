using Business_BLL.BrancheSrv;
using Business_BLL.DepartmentSrv;
using Business_BLL.VacancieSrv;
using Microsoft.AspNetCore.Mvc;

namespace StarSecurityServices.Controllers
{
	public class NetworkController : Controller
	{
		private readonly IBranche _brancheService;
		public NetworkController( IBranche brancheService)
		{
			_brancheService = brancheService;
		}
		public async Task<IActionResult> Index()
		{
            ViewBag.Title = "Our Network";
			var branche = await _brancheService.GetAll();
			return View(branche);
        }
	}
}
