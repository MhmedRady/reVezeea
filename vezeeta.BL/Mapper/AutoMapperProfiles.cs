using AutoMapper;
using vezeeta.BL.DTOs.Admin;
using vezeeta.DBL.db.Models;
namespace vezeeta.BL.Mapper;

public class AutoMapperProfile : Profile
{
    protected AutoMapperProfile()
    {
        CreateMap<User, AdminDTO>();
    }
}
