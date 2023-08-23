using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSys.Data;
using StudentManagementSys.Models;
using System.Data;

namespace StudentManagementSys.Controllers
{
    [Authorize(Roles = "Teacher,Student")]
    public class AttendancesController : Controller
    {
        private readonly ApplicationDbContext studentBD;

        public AttendancesController(ApplicationDbContext studentBD)
        {
            this.studentBD = studentBD;
        }

        // GET: Attendances
        public async Task<IActionResult> Index()
        {
            var stdData = await studentBD.Attendances.ToListAsync();
            return View(stdData);
        }

        // GET: Attendances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attendances/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Attendance attn)
        {
            if (ModelState.IsValid)
            {
                await studentBD.Attendances.AddAsync(attn);
                await studentBD.SaveChangesAsync();
                TempData["insert_success"] = "Data has been Inserted..";
                return RedirectToAction("Index", "Attendances");
            }
            return View(attn);
        }

        // GET: Attendances/Details/
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || studentBD.Attendances == null)
            {
                return NotFound();
            }
            var stdData = await studentBD.Attendances.FirstOrDefaultAsync(x => x.Att_Id == id);
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }

        // GET: Attendances/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || studentBD.Attendances == null)
            {
                return NotFound();
            }
            var stdData = await studentBD.Attendances.FindAsync(id);
            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData);
        }

        // POST: Attendances/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Attendance attn)
        {
            if (id != attn.Att_Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                studentBD.Update(attn);
                await studentBD.SaveChangesAsync();
                TempData["update_success"] = "Data has been Updated..";
                return RedirectToAction("Index", "Attendances");
            }
            return View(attn);
        }

        // GET: Attendances/Delete/
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || studentBD.Attendances == null)
            {
                return NotFound();
            }

            var stdData = await studentBD.Attendances.FirstOrDefaultAsync(x => x.Att_Id == id);

            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData);
        }

        // POST: Attendances/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            var stdData = await studentBD.Attendances.FindAsync(id);
            if (stdData != null)
            {
                studentBD.Attendances.Remove(stdData);
            }
            await studentBD.SaveChangesAsync();
            TempData["delete_success"] = "Data has been Deleted..";
            return RedirectToAction("Index", "Attendances");
        }


        private bool AttendanceExists(int id)
        {
            return (studentBD.Attendances?.Any(e => e.Att_Id == id)).GetValueOrDefault();
        }
    }
}
