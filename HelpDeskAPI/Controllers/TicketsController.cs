using AutoMapper;
using HelpDeskAPI.Data;
using HelpDeskAPI.DTOs.TicketDTOs;
using HelpDeskAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TicketsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketReadDto>>> GetTickets()
        {
            var tickets = await _context.Tickets
                .Include(t => t.Employee)
                .ThenInclude(e => e.Department)
                .ToListAsync();

            return Ok(_mapper.Map<List<TicketReadDto>>(tickets));
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketReadDto>> GetTicket(int id)
        {
            var ticket = await _context.Tickets
                .Include(t => t.Employee)
                .ThenInclude(e => e.Department)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (ticket == null)
                return NotFound();

            return Ok(_mapper.Map<TicketReadDto>(ticket));
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<TicketReadDto>> CreateTicket(TicketCreateDto dto)
        {
            var ticket = _mapper.Map<Ticket>(dto);

            _context.Tickets.Add(ticket);

            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<TicketReadDto>(ticket));
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, TicketCreateDto dto)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
                return NotFound();

            _mapper.Map(dto, ticket);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
                return NotFound();

            _context.Tickets.Remove(ticket);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}