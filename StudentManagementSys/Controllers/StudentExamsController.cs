using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSys.Data;
using StudentManagementSys.Models;
using System.Data;

namespace StudentManagementSys.Controllers
{
    [Authorize(Roles = "Teacher,Student")]
    public class StudentExamsController : Controller
    {
        private readonly ApplicationDbContext studentBD;

        public StudentExamsController(ApplicationDbContext studentBD)
        {
            this.studentBD = studentBD;
        }

        // GET: StudentExams
        public async Task<IActionResult> Index()
        {
            var stdData = await studentBD.StudentExams.ToListAsync();
            return View(stdData);
        }

        // GET: StudentExams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentExams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentExam stdExam)
        {
            if (ModelState.IsValid)
            {
                await studentBD.StudentExams.AddAsync(stdExam);
                await studentBD.SaveChangesAsync();
                TempData["insert_success"] = "Data has been Inserted..";
                return RedirectToAction("Index", "StudentExams");
            }
            return View(stdExam);
        }

        // GET: StudentExams/Details/
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || studentBD.StudentExams == null)
            {
                return NotFound();
            }
            var stdData = await studentBD.StudentExams.FirstOrDefaultAsync(x => x.ExamId == id);
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }

        // GET: StudentExams/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || studentBD.StudentExams == null)
            {
                return NotFound();
            }
            var stdData = await studentBD.StudentExams.FindAsync(id);
            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData);
        }

        // POST: StudentExams/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, StudentExam stdExam)
        {
            if (id != stdExam.ExamId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                studentBD.Update(stdExam);
                await studentBD.SaveChangesAsync();
                TempData["update_success"] = "Data has been Updated..";
                return RedirectToAction("Index", "StudentExams");
            }
            return View(stdExam);
        }

        // GET: StudentExams/Delete/
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || studentBD.StudentExams == null)
            {
                return NotFound();
            }

            var stdData = await studentBD.StudentExams.FirstOrDefaultAsync(x => x.ExamId == id);

            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData);
        }

        // POST: StudentExams/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            var stdData = await studentBD.StudentExams.FindAsync(id);
            if (stdData != null)
            {
                studentBD.StudentExams.Remove(stdData);
            }
            await studentBD.SaveChangesAsync();
            TempData["delete_success"] = "Data has been Deleted..";
            return RedirectToAction("Index", "StudentExams");
        }



        private bool StudentExamExists(int id)
        {
            return (studentBD.StudentExams?.Any(e => e.ExamId == id)).GetValueOrDefault();
        }
    }
}
