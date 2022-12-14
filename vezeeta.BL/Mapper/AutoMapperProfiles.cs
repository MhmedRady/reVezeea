using AutoMapper;
using vezeeta.BL.DTOs.Admin;
using vezeeta.BL.GenericDTOs;
using vezeeta.DBL.db.Models;
namespace vezeeta.BL.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, AdminDTO>();
        CreateMap<Department, DepartmentDTO>();
    }
}
