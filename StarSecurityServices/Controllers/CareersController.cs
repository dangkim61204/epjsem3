using Business_BLL.BrancheSrv;
using Business_BLL.VacancieSrv;
using Microsoft.AspNetCore.Mvc;

namespace StarSecurityServices.Controllers
{
	public class CareersController : Controller
	{
		private readonly ILogger<CareersController> _logger;
		private readonly IVacancie _vacancieService;
		private readonly IBranche _brancheService;
		public CareersController(ILogger<CareersController> logger, IVacancie vacancieService, IBranche brancheService)
		{
			_logger = logger;
			_vacancieService = vacancieService;
			_brancheService = brancheService;
		}

		public async Task<IActionResult> Index(int page =1)
		{
			ViewBag.Title = "Careers";
			return View(await _vacancieService.GetAll(page));
		}

		public async Task<IActionResult> Details(int id, int page =1)
		{
			ViewBag.Title = "Details";

			// If id is invalid, return NotFound()
			if (id == 0)
			{
				return NotFound();
			}

			// Fetch the Vacancie object by ID
			var vacancie = await _vacancieService.GetById(id);

			// If no vacancie is found, return NotFound()
			if (vacancie == null)
			{
				return NotFound();
			}
			var vacancies = await _vacancieService.GetAll(page =1);
			ViewBag.firstFiveVacancies = vacancies.Take(4);
			// Return the Vacancie object directly to the View
			return View(vacancie);
		}
		public async Task<IActionResult> Browse(int page =1)
		{
			ViewBag.Title = "Browse Companies";
			return View(await _vacancieService.GetAll(page));
		}
		[HttpPost]
		public async Task<IActionResult> Search(string Title, int pageNumber = 1, int pageSize = 10, int page =1)
		{
			ViewBag.Title = "Careers";

			// If the title is null or empty, show all vacancies
			if (string.IsNullOrEmpty(Title))
			{
				return RedirectToAction("Index", new { pageNumber });
			}

			// Fetch all vacancies first
			var vacancies = await _vacancieService.GetAll(page);

			// Filter vacancies based on the title
			var filteredVacancies = vacancies
				.Where(x => x.Title.Contains(Title, StringComparison.OrdinalIgnoreCase))
				.ToList();

			// Pagination logic
			var totalVacancies = filteredVacancies.Count;
			var totalPages = (int)Math.Ceiling(totalVacancies / (double)pageSize);
			var currentPageVacancies = filteredVacancies
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToList();

			// Set up ViewBag for pagination
			ViewBag.PageNumber = pageNumber;
			ViewBag.TotalPages = totalPages;
			ViewBag.TotalVacancies = totalVacancies;
			ViewBag.PageSize = pageSize;

			// Return the filtered and paginated vacancies to the Index view
			return View("Index", currentPageVacancies);
		}


	}
}
