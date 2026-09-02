using System.ComponentModel.DataAnnotations;

namespace HelpDeskAPI.DTOs.TicketDTOs
{
    public class TicketCreateDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public string Priority { get; set; } = "Medium";

        public string Status { get; set; } = "Open";

        public int EmployeeId { get; set; }
    }
}