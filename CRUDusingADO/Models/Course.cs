using System.ComponentModel.DataAnnotations;

namespace CRUDusingADO.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Fees { get; set; }
        [Required]
        public string? Duration { get; set; }
    }
}
