using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSys.Data;
using StudentManagementSys.Models;
using System.Diagnostics;

namespace StudentManagementSys.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext studentBD;
        public HomeController(ApplicationDbContext studentBD)
        {
            this.studentBD = studentBD;
        }

        public async Task<IActionResult> Index()
        {
            var stdData = await studentBD.Students.ToListAsync();
            return View(stdData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
                await studentBD.Students.AddAsync(std);
                await studentBD.SaveChangesAsync();
                TempData["insert_success"] = "Data has been Inserted..";
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || studentBD.Students == null)
            {
                return NotFound();
            }
            var stdData = await studentBD.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || studentBD.Students == null)
            {
                return NotFound();
            }
            var stdData = await studentBD.Students.FindAsync(id);
            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Student std)
        {
            if (id != std.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                studentBD.Update(std);
                await studentBD.SaveChangesAsync();
                TempData["update_success"] = "Data has been Updated..";
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || studentBD.Students == null)
            {
                return NotFound();
            }

            var stdData = await studentBD.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            var stdData = await studentBD.Students.FindAsync(id);
            if (stdData != null)
            {
                studentBD.Students.Remove(stdData);
            }
            await studentBD.SaveChangesAsync();
            TempData["delete_success"] = "Data has been Deleted..";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}