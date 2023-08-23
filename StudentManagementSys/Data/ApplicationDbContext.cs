using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagementSys.Models;

namespace StudentManagementSys.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentExam> StudentExams { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
    }
   
    
}