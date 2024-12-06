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
    public class RoleController : Controller
    {
        private readonly ConnectDB _context;

        public RoleController(ConnectDB context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var role = await _context.Roles.ToListAsync();
            return View(role);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Role role)
        {
            var role1 = await _context.Roles.FirstOrDefaultAsync(x=>x.Name.Equals(role.Name));
            if (role1 != null)
            {
                ViewBag.msg = "Tên role đã tồn tại";
                return View(role);
            }
           
            if (ModelState.IsValid)
            {
                _context.Add(role);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
           
            return View(role);
        }

        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.Roles.SingleOrDefaultAsync(x => x.Id == id);
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RoleExists(int id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }
    }
}
