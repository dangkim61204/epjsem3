using Business_BLL.BrancheSrv;
using Business_BLL.DepartmentSrv;
using Business_BLL.VacancieSrv;
using Data_DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using StarSecurityServices.Models;
using System.Diagnostics;

namespace StarSecurityServices.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IDepartment _departmentService;
		private readonly IVacancie _vacancieService;
		private readonly IBranche _brancheService;
		public HomeController(ILogger<HomeController> logger, IDepartment departmentService, IVacancie vacancieService, IBranche brancheService)
        {
            _logger = logger;
			_departmentService = departmentService;
			_vacancieService = vacancieService;
            _brancheService = brancheService;
		}

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Home";
			ViewBag.listbranche = await _brancheService.GetAll();
            var branche = await _brancheService.GetAll();
			ViewBag.BrancheCount = branche.Count();
			var vacancies = await _vacancieService.GetAll();
			ViewBag.VacancyCount = vacancies.Count();
			ViewBag.TotalQuantity = vacancies.Sum(v => v.Quantity);
			return View(vacancies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
		[HttpPost]
		public async Task<IActionResult> Search(string Title)
		{
			ViewBag.Title = "Home";

			// If the title is null or empty, show all vacancies
			if (string.IsNullOrEmpty(Title))
			{
				return RedirectToAction("Index");
			}
			
			// Fetch all vacancies first
			var vacancies = await _vacancieService.GetAll();
			ViewBag.listbranche = await _brancheService.GetAll();
			var branche = await _brancheService.GetAll();
			ViewBag.BrancheCount = branche.Count();

			ViewBag.VacancyCount = vacancies.Count();
			ViewBag.TotalQuantity = vacancies.Sum(v => v.Quantity);
			// Filter vacancies based on the title
			var filteredVacancies = vacancies.Where(x => x.Title.Contains(Title, StringComparison.OrdinalIgnoreCase)).ToList();

			// Return the filtered vacancies to the Index view
			return View("Index", filteredVacancies);
		}
	}
}
