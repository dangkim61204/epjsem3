using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarSecurityServices.Models;

namespace StarSecurityServices.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClientController : Controller
    {
        private readonly ConnectDB _context;

        public ClientController(ConnectDB context)
        {
            _context = context;
        }

        // GET: Admin/Client
        public async Task<IActionResult> Index()
        {
            var connectDB = _context.Clients.Include(c => c.Service).Include(c => c.ClientEmployees)
            .ThenInclude(ce => ce.Employee);
            return View(await connectDB.ToListAsync());
        }

        // GET: Admin/Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Admin/Client/Create
        public IActionResult Create()
        {
            // Lấy danh sách nhân viên từ cơ sở dữ liệu
            var employees = _context.Employees.Select(e => new SelectListItem
            {
                Value = e.Code.ToString(),
                Text = e.Name // Hoặc hiển thị thuộc tính khác, ví dụ: $"{e.Name} ({e.Position})"
            }).ToList();

            // Gắn danh sách vào ViewBag
            ViewBag.Employees = employees;
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "ServiceName");


            return View();
        }

        // POST: Admin/Client/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Client client)
        {

            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                // Xử lý các EmployeeId được chọn (nếu cần lưu vào bảng trung gian)
                foreach (var employeeId in client.EmployeeIds)
                {
                    // Ví dụ: Lưu vào bảng trung gian ClientEmployee
                    var clientEmployee = new ClientEmployee
                    {
                        ClientId = client.Id,
                        EmployeeId = employeeId
                    };
                    _context.clientEmployees.Add(clientEmployee);
                    _context.SaveChanges();
                }

                //_context.SaveChanges();
                //return RedirectToAction(nameof(Index));

              
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "ServiceName", client.ServiceId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", client.ServiceId);
            return View(client);
        }

        // GET: Admin/Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "ServiceName", client.ServiceId);
            return View(client);
        }

        // POST: Admin/Client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Id", client.ServiceId);
            return View(client);
        }

        // GET: Admin/Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Client = await _context.Clients.SingleOrDefaultAsync(x => x.Id == id);
            _context.Clients.Remove(Client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
