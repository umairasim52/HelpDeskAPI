using System.ComponentModel.DataAnnotations;

namespace HelpDeskAPI.DTOs.EmployeeDTOs
{
    public class EmployeeCreateDto
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public int DepartmentId { get; set; }
    }
}