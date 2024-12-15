using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_BLL.DepartmentSrv;
using Business_BLL.EmployeeSrv;
using Business_BLL.RoleSrv;
using Data_DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarSecurityServices.Models;


namespace StarSecurityServices.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    // [Authorize(Policy = "AdminStar")]
    //[Authorize(Policy = "ManagerStar")]
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeService;
        private readonly IDepartment _departmentService;
        private readonly IRole _roleService;


        public EmployeeController(IEmployee employeeService, IDepartment departmentService, IRole roleService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _roleService = roleService;


        }

        // GET: Admin/Employees
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                var emp = await _employeeService.GetAll();
                return View(emp);
            }
           return View("View404");
        }

        // GET: Admin/Employees/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Staff"))
            {
                if (id == null)
                {
                    return NotFound();
                }

                var employee = await _employeeService.GetById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                ViewBag.dep = new SelectList(await _departmentService.GetAll(), "Id", "Name");
                ViewBag.role = new SelectList(await _roleService.GetAll(), "Id", "Name");

                return View(employee);
            }
            return View("View404");
           
        }

        // GET: Admin/Employees/Create
        public async Task<IActionResult> Create()
        {
            if (User.IsInRole("Admin") )
            {
                ViewBag.dep = new SelectList(await _departmentService.GetAll(), "Id", "Name");
                ViewBag.role = new SelectList(await _roleService.GetAll(), "Id", "Name");

                return View();
            }
            return View("View404");
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee, IFormFile? filePicture)
        {
            if (User.IsInRole("Admin"))
            {
                if (filePicture != null && filePicture.Length > 0)
                {
                    try
                    {

                        string pathfile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filePicture.FileName);


                        using (var stream = new FileStream(pathfile, FileMode.Create))
                        {
                            await filePicture.CopyToAsync(stream);
                        }


                        employee.Avata = "/images/" + filePicture.FileName;
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", $"Lỗi khi lưu ảnh: {ex.Message}");
                    }
                }
                else
                {
                    ModelState.AddModelError("filePicture", "Ảnh không được trống");
                }

                if (ModelState.IsValid)
                {
                    try
                    {

                        await _employeeService.Add(employee);
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", $"Lỗi khi thêm nhân viên: {ex.Message}");
                    }
                }
                ViewBag.dep = new SelectList(await _departmentService.GetAll(), "Id", "Name");
                ViewBag.role = new SelectList(await _roleService.GetAll(), "Id", "Name");
                return View(employee);
            }
            return View("View404");

          
        }

  
        // GET: Admin/Employees/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (User.IsInRole("Admin"))
            {
                var employee = await _employeeService.GetById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                ViewBag.dep = new SelectList(await _departmentService.GetAll(), "Id", "Name");
                ViewBag.role = new SelectList(await _roleService.GetAll(), "Id", "Name");

                return View(employee);
            }
            return View("View404");

            
          
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormFile? filePicture, Employee employee)
        {
            if (User.IsInRole("Admin"))
            {
                if (id != employee.Code)
                {
                    return NotFound();
                }

                if (filePicture != null && filePicture.Length > 0)
                {
                    string pathfile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filePicture.FileName);
                    using (var stream = System.IO.File.Create(pathfile))
                    {
                        await filePicture.CopyToAsync(stream);
                    }
                    employee.Avata = "/images/" + filePicture.FileName;
                }

                if (ModelState.IsValid)
                {

                    await _employeeService.Update(employee);
                    return RedirectToAction("Index");

                }
                ViewBag.dep = new SelectList(await _departmentService.GetAll(), "Id", "Name");
                ViewBag.role = new SelectList(await _roleService.GetAll(), "Id", "Name");
                return View(employee);
            }
            return View("View404");
            
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (User.IsInRole("Admin"))
            {
                await _employeeService.Delete(id);
                return RedirectToAction("Index");
            }
            return View("View404");
           
        }



    }
}
