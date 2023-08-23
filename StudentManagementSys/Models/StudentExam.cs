using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSys.Models
{
    public class StudentExam
    {
        [Key]
        public int ExamId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        [Column("CourseName", TypeName = "varchar(200)")]
        public string CourseName { get; set; }

        [Required]
        public DateTime ExamDate { get; set; }

        [Column("Mark", TypeName = "varchar(10)")]
        public string Mark { get; set; }
    }
}
