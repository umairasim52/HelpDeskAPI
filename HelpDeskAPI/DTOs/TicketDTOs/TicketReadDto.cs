namespace HelpDeskAPI.DTOs.TicketDTOs
{
    public class TicketReadDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Priority { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public int EmployeeId { get; set; }
    }
}