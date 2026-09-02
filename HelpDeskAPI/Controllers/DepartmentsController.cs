using AutoMapper;
using HelpDeskAPI.Data;
using HelpDeskAPI.DTOs.DepartmentDTOs;
using HelpDeskAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentReadDto>>> GetDepartments()
        {
            var departments = await _context.Departments.ToListAsync();

            return Ok(_mapper.Map<List<DepartmentReadDto>>(departments));
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentReadDto>> GetDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
                return NotFound();

            return Ok(_mapper.Map<DepartmentReadDto>(department));
        }

        // POST: api/Departments
        [HttpPost]
        public async Task<ActionResult<DepartmentReadDto>> CreateDepartment(DepartmentCreateDto dto)
        {
            var department = _mapper.Map<Department>(dto);

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetDepartment),
                new { id = department.Id },
                _mapper.Map<DepartmentReadDto>(department));
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, DepartmentCreateDto dto)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
                return NotFound();

            _mapper.Map(dto, department);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
                return NotFound();

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}