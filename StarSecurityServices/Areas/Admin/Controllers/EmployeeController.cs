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
    public class EmployeeController : Controller
    {
        private readonly ConnectDB _context;

        public EmployeeController(ConnectDB context)
        {
            _context = context;
        }

        // GET: Admin/Employees
        public async Task<IActionResult> Index()
        {
            var connectDB = _context.Employees.Include(e => e.Department).Include(e => e.Role);
            var emp = await connectDB.ToListAsync();
            return View(emp);
        }

        // GET: Admin/Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Role)
                .FirstOrDefaultAsync(m => m.Code == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Admin/Employees/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        // POST: Admin/Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Employee employee, IFormFile filePicture)
        {
            if (filePicture != null && filePicture.Length > 0)
            {
                string pathfile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filePicture.FileName);
                using (var stream = System.IO.File.Create(pathfile))
                {
                    await filePicture.CopyToAsync(stream);
                }
                employee.Avata = "/images/" + filePicture.FileName;
            }
            else
            {
                ViewBag.msg = "Ảnh không được trống";
                ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", employee.DepartmentId);
                ViewData["RoleId"] = new SelectList(_context.Departments, "Id", "Name", employee.RoleId);
                return View(employee);
            }


            //if (ModelState.IsValid)
            //{
            Console.WriteLine(Utilitie.GetMD5HashData(employee.Password), "////");
            employee.Password = Utilitie.GetMD5HashData(employee.Password);
           
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            //}
          
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", employee.DepartmentId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", employee.RoleId);
            return View(employee);
        }



        // GET: Admin/Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", employee.DepartmentId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", employee.RoleId);
            return View(employee);
        }

        // POST: Admin/Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Code,Name,Avata,Address,Phone,Email,Education,Grade,Achievements,Username,Password,DepartmentId,RoleId")] Employee employee)
        {
            if (id != employee.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Code))
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
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", employee.DepartmentId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", employee.RoleId);
            return View(employee);
        }

        // GET: Admin/Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Role)
                .FirstOrDefaultAsync(m => m.Code == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Admin/Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Code == id);
        }
    }
}
