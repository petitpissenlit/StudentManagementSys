using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSys.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Column("StudentName", TypeName = "varchar(100)")]
        [Required]
        public string Name { get; set; }

        [Column("StudentGender", TypeName = "varchar(20)")]
        [Required]
        public string Gender { get; set; }

        [Required]
        public int? Age { get; set; }

        [Column("StudentClass", TypeName = "varchar(30)")]
        [Required]
        public string StudentClass { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Column("EmailAddress", TypeName = "varchar(30)")]
        public string EmailAddress { get; set; }

        [Column("Status", TypeName = "varchar(20)")]
        public string Status { get; set; }
    }
}
