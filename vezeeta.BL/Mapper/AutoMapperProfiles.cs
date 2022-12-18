using AutoMapper;
<<<<<<< HEAD
using vezeeta.BL;
using vezeeta.DBL;


namespace vezeeta.BL;
=======
using vezeeta.BL.DTOs.Admin;
using vezeeta.BL.GenericDTOs;
using vezeeta.DBL.db.Models;
namespace vezeeta.BL.Mapper;
>>>>>>> 42e4b882a6f1e0897ee8c0078089dc66a0f264d5

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, AdminDTO>();
<<<<<<< HEAD
        //CreateMap<AdminDTO, User>();
=======
        CreateMap<Department, DepartmentDTO>();
>>>>>>> 42e4b882a6f1e0897ee8c0078089dc66a0f264d5
    }
}
