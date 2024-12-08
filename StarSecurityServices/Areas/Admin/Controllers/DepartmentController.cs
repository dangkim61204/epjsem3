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
    public class DepartmentController : Controller
    {
        private readonly ConnectDB _context;

        public DepartmentController(ConnectDB context)
        {
            _context = context;
        }

 
        public async Task<IActionResult> Index()
        {
            var dep = await _context.Departments.ToListAsync();
            return View(dep);
        }

   

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(department);
        }

      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.Id))
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
            return View(department);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(new { message = "Department ID is required" });
            }

            var dep = await _context.Departments
                .Include(d => d.Employees)
                .SingleOrDefaultAsync(d => d.Id == id);

            if (dep == null)
            {
                return NotFound(new { message = "Department not found" });
            }

            // Kiểm tra xem Department có nhân viên liên kết hay không
            if (dep.Employees != null && dep.Employees.Any())
            {
                return BadRequest(new { message = "Cannot delete department because it is associated with one or more employees" });
            }

            _context.Departments.Remove(dep);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }



        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
