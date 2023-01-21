using System.ComponentModel.DataAnnotations;

namespace SchoolEventWeb.Data
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Range(9, 12, ErrorMessage = "Grade should be between 9 to 12")]
        public int Grade { get; set; } = 9;
    }
}
