using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot be more than 50 characters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+$", ErrorMessage = "Invalid Email format")]
        [Display(Name= "Office Email")]
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set; }
    
        public string PhotoPath { get; set; }

    }
}