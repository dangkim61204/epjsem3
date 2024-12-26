using Business_BLL.ClientSrv;
using Business_BLL.ServiceSrv;
using Data_DAL.Entities;
using Microsoft.AspNetCore.Mvc;

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

            var clients = await _clientService.GetAll() ?? new List<Client>();

            return View("Index", PaginateClients(clients.ToList(), pageNumber, pageSize, Titlee));
        }

        public async Task<IActionResult> Search(string Titlee, int pageNumber = 1, int pageSize = 6)
        {
            ViewBag.Title = "Search Clients";
            var clients = await _clientService.GetAll() ?? new List<Client>();

            var filteredClients = string.IsNullOrEmpty(Titlee)
                ? clients
                : clients.Where(x => x.Name.Contains(Titlee, StringComparison.OrdinalIgnoreCase)).ToList();

            return View("Index", PaginateClients(filteredClients.ToList(), pageNumber, pageSize, Titlee));
        }

        private object PaginateClients(List<Client> clients, int pageNumber, int pageSize, string Title)
        {
            var totalPages = (int)Math.Ceiling(clients.Count / (double)pageSize);
            var clientsPage = clients.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.PageNumber = pageNumber;
            ViewBag.TotalPages = totalPages;
            ViewBag.PageSize = pageSize;
            ViewBag.valueTitlee = Title;

            return clientsPage;
        }
    }
}
