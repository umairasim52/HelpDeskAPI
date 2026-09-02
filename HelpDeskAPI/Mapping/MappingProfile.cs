using AutoMapper;
using HelpDeskAPI.DTOs.DepartmentDTOs;
using HelpDeskAPI.DTOs.EmployeeDTOs;
using HelpDeskAPI.DTOs.TicketDTOs;
using HelpDeskAPI.Models;

namespace HelpDeskAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Department
            CreateMap<Department, DepartmentReadDto>();
            CreateMap<DepartmentCreateDto, Department>();

            // Employee
            CreateMap<Employee, EmployeeReadDto>();
            CreateMap<EmployeeCreateDto, Employee>();

            // Ticket
            CreateMap<Ticket, TicketReadDto>();
            CreateMap<TicketCreateDto, Ticket>();
        }
    }
}