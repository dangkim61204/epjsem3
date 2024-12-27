using Business_BLL.ClientSrv;
using Business_BLL.ServiceSrv;
using Data_DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace StarSecurityServices.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClient _clientService;
        private readonly IService _serviceSrv;

        public ClientsController(IClient clientService, IService serviceSrv)
        {
            _clientService = clientService;
            _serviceSrv = serviceSrv;
        }

        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 6, string Titlee = "")
        {
            ViewBag.Title = "Clients";
            ViewBag.valueTitlee = Titlee;

            // Fetch all clients
            var clients = await _clientService.GetAll(pageNumber);

            // Apply filter for title search if it's provided
            if (!string.IsNullOrEmpty(Titlee))
            {
                clients = clients.Where(x => x.Name.Contains(Titlee, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Pagination logic
            var totalClients = clients.Count();
            var totalPages = (int)Math.Ceiling(totalClients / (double)pageSize);

            // Ensure that the page number is within a valid range
            if (pageNumber < 1) pageNumber = 1;
            if (pageNumber > totalPages) pageNumber = totalPages;

            // Get the clients for the current page
            var currentPageClients = clients
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Pass pagination info to the view
            ViewBag.PageNumber = pageNumber;
            ViewBag.TotalPages = totalPages;
            ViewBag.TotalClients = totalClients;
            ViewBag.PageSize = pageSize;

            return View("Index", currentPageClients);
        }

        // Handle GET request for search with pagination
        [HttpGet]
        public async Task<IActionResult> Search(string Titlee, int pageNumber = 1, int pageSize = 6)
        {
            ViewBag.Title = "Clients";
            ViewBag.valueTitlee = Titlee;

            var clients = await _clientService.GetAll(pageNumber);

            if (!string.IsNullOrEmpty(Titlee))
            {
                clients = clients.Where(x => x.Name.Contains(Titlee, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            var totalClients = clients.Count();
            var totalPages = (int)Math.Ceiling(totalClients / (double)pageSize);

            if (pageNumber < 1) pageNumber = 1;
            if (pageNumber > totalPages) pageNumber = totalPages;

            var currentPageClients = clients
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.PageNumber = pageNumber;
            ViewBag.TotalPages = totalPages;
            ViewBag.TotalClients = totalClients;
            ViewBag.PageSize = pageSize;

            return View("Index", currentPageClients);
        }
    }
}
