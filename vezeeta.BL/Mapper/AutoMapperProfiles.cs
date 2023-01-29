using AutoMapper;
using vezeeta.BL;
using vezeeta.BL.DTOs.Center;
using vezeeta.DBL;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, AdminDTO>();
        /*CreateMap<User, AdminDTO>().ReverseMap();*/
        CreateMap<Department, DepartmentDTO>().ReverseMap();
        CreateMap<Center, CenterDTO>().ReverseMap();
        CreateMap<Center, CenterReadDto>().ReverseMap();

    }
}
