using System.ComponentModel.DataAnnotations;

namespace CRUDusingADO.Models
{
    public class Student
    {
        public int RollNo { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double Percentage { get; set; }
        [Required]
        public string? City { get; set; }
    }
}
