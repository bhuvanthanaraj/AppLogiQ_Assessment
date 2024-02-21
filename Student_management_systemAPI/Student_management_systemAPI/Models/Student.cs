using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_management_systemAPI.Models
{
    public class Student
    {
        public Guid StudentId  { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Positive integer")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Grade is required")]
        public string? Grade { get; set; }


    }
}
