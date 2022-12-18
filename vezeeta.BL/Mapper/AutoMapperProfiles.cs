using AutoMapper;
using vezeeta.BL;
using vezeeta.DBL;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, AdminDTO>();
        //CreateMap<AdminDTO, User>();
        CreateMap<Department, DepartmentDTO>();
    }
}
