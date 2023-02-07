using AutoMapper;
using vezeeta.BL;
using vezeeta.BL.DTOs.Center;
using vezeeta.BL.DTOs.Speciality;
using vezeeta.DBL;
using vezeeta.DBL.db.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, AdminDTO>();
        /*CreateMap<User, AdminDTO>().ReverseMap();*/
        CreateMap<Department, DepartmentDTO>().ReverseMap();
        CreateMap<Center, CenterDTO>().ReverseMap();
        CreateMap<Center, CenterReadDto>().ReverseMap();
        CreateMap<Speciality, SpecialityDTO>().ReverseMap();
        CreateMap<Speciality, SetSpecialityDTO>().ReverseMap();

    }
}
