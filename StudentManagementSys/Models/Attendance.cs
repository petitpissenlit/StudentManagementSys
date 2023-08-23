using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSys.Models
{
    public class Attendance
    {
        [Key]
        public int Att_Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public Boolean IsPresent { get; set; }

        [Column("Remark", TypeName = "varchar(500)")]
        public string Remark { get; set; }
    }
}
