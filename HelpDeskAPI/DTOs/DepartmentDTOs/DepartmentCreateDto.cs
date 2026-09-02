using System.ComponentModel.DataAnnotations;

namespace HelpDeskAPI.DTOs.DepartmentDTOs
{
    public class DepartmentCreateDto
    {
        [Required]
        public string DepartmentName { get; set; } = string.Empty;
    }
}