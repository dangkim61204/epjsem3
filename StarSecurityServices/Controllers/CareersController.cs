using Business_BLL.BrancheSrv;
using Business_BLL.VacancieSrv;
using Data_DAL.Entities;
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

		public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 7, string sort = "A to Z", string Titlee = "")
		{
			ViewBag.Title = "Careers";
			ViewBag.valueTitlee = Titlee;
			ViewBag.Sort = sort;

			// Fetch all vacancies first
			var vacancies = await _vacancieService.GetAll();

			// If there's a search query, filter vacancies based on the Titlee
			if (!string.IsNullOrEmpty(Titlee))
			{
				vacancies = vacancies.Where(x => x.Title.Contains(Titlee, StringComparison.OrdinalIgnoreCase)).ToList();
			}

			// Apply sorting based on the selected option
			vacancies = ApplySorting(vacancies.ToList(), sort);

			// Pagination logic
			var totalVacancies = vacancies.Count();
			var totalPages = (int)Math.Ceiling(totalVacancies / (double)pageSize);

			// Ensure that the page number is within valid range
			if (pageNumber < 1)
				pageNumber = 1;
			if (pageNumber > totalPages)
				pageNumber = totalPages;

			// Get the vacancies for the current page
			var currentPageVacancies = vacancies
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToList();

			// Pass pagination info, search query, and sort options to the view
			ViewBag.PageNumber = pageNumber;
			ViewBag.TotalPages = totalPages;
			ViewBag.TotalVacancies = totalVacancies;
			ViewBag.PageSize = pageSize;

			return View(currentPageVacancies);
		}

		private List<Vacancie> ApplySorting(List<Vacancie> vacancies, string sort)
		{
			switch (sort)
			{
				case "Newest":
					return vacancies.OrderByDescending(v => v.EndDate).ToList();
				case "Oldest":
					return vacancies.OrderBy(v => v.EndDate).ToList();
				case "Random":
					var rand = new Random();
					return vacancies.OrderBy(v => rand.Next()).ToList();
				case "A to Z":
				default:
					return vacancies.OrderBy(v => v.Title).ToList();
			}
		}

		public async Task<IActionResult> Details(int id)
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
			var vacancies = await _vacancieService.GetAll();
			ViewBag.firstFiveVacancies = vacancies.Take(4);
			// Return the Vacancie object directly to the View
			return View(vacancie);
		}
		public async Task<IActionResult> Browse(int pageNumber = 1, int pageSize = 7)
		{
			ViewBag.Title = "Browse Companies";

			// Fetch all vacancies first
			var vacancies = await _vacancieService.GetAll();

			// Pagination logic
			var totalVacancies = vacancies.Count();
			var totalPages = (int)Math.Ceiling(totalVacancies / (double)pageSize);

			// Ensure that the page number is within valid range
			if (pageNumber < 1)
				pageNumber = 1;
			if (pageNumber > totalPages)
				pageNumber = totalPages;

			// Get the vacancies for the current page
			var currentPageVacancies = vacancies
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToList();

			// Pass pagination info to the view
			ViewBag.PageNumber = pageNumber;
			ViewBag.TotalPages = totalPages;
			ViewBag.TotalVacancies = totalVacancies;
			ViewBag.PageSize = pageSize;

			return View(currentPageVacancies);
		}

		// Update the Search method to handle GET requests
		[HttpGet]
		public async Task<IActionResult> Search(string Titlee, string sort, int pageNumber = 1, int pageSize = 7)
		{
			ViewBag.Title = "Careers";
			ViewBag.valueTitlee = Titlee;
			ViewBag.Sort = sort;

			// Fetch all vacancies first
			var vacancies = await _vacancieService.GetAll();

			// If there's a search query, filter vacancies based on the Titlee
			if (!string.IsNullOrEmpty(Titlee))
			{
				vacancies = vacancies.Where(x => x.Title.Contains(Titlee, StringComparison.OrdinalIgnoreCase)).ToList();
			}

			// Apply sorting based on the selected option
			switch (sort)
			{
				case "Newest":
					vacancies = vacancies.OrderByDescending(v => v.EndDate).ToList();
					break;
				case "Oldest":
					vacancies = vacancies.OrderBy(v => v.EndDate).ToList();
					break;
				case "Random":
					var rand = new Random();
					vacancies = vacancies.OrderBy(v => rand.Next()).ToList();
					break;
				case "A to Z":
				default:
					vacancies = vacancies.OrderBy(v => v.Title).ToList();
					break;
			}

			// Pagination logic
			var totalVacancies = vacancies.Count();
			var totalPages = (int)Math.Ceiling(totalVacancies / (double)pageSize);

			// Ensure that the page number is within a valid range
			if (pageNumber < 1)
				pageNumber = 1;
			if (pageNumber > totalPages)
				pageNumber = totalPages;

			// Get the vacancies for the current page
			var currentPageVacancies = vacancies
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToList();

			// Pass pagination info, search query, and sort options to the view
			ViewBag.PageNumber = pageNumber;
			ViewBag.TotalPages = totalPages;
			ViewBag.TotalVacancies = totalVacancies;
			ViewBag.PageSize = pageSize;

			return View("Index", currentPageVacancies);
		}




		// Update the Sort method to handle GET requests
		[HttpGet]
		public async Task<IActionResult> Sort(string sort, int pageNumber = 1, int pageSize = 7)
		{
			ViewBag.Title = "Careers";

			// Fetch all vacancies first
			var vacancies = await _vacancieService.GetAll();

			// Apply sorting based on the selected option
			switch (sort)
			{
				case "Newest":
					vacancies = vacancies.OrderByDescending(v => v.EndDate).ToList();
					break;
				case "Oldest":
					vacancies = vacancies.OrderBy(v => v.EndDate).ToList();
					break;
				case "Random":
					var rand = new Random();
					vacancies = vacancies.OrderBy(v => rand.Next()).ToList();
					break;
				case "A to Z":
				default:
					vacancies = vacancies.OrderBy(v => v.Title).ToList();
					break;
			}

			// Pagination logic
			var totalVacancies = vacancies.Count();
			var totalPages = (int)Math.Ceiling(totalVacancies / (double)pageSize);
			var currentPageVacancies = vacancies
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToList();

			// Set up ViewBag for pagination
			ViewBag.PageNumber = pageNumber;
			ViewBag.TotalPages = totalPages;
			ViewBag.TotalVacancies = totalVacancies;
			ViewBag.PageSize = pageSize;

			return View("Index", currentPageVacancies);
		}
	}
}
