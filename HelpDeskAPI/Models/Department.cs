using System.ComponentModel.DataAnnotations;

namespace HelpDeskAPI.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; } = string.Empty;

        public ICollection<Employee>? Employees { get; set; }
    }
}