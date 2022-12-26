using AutoMapper;
using vezeeta.BL;
using vezeeta.DBL;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        /*CreateMap<User, AdminDTO>();*/
        CreateMap<User, AdminDTO>().ReverseMap();
        CreateMap<Department, DepartmentDTO>();
        CreateMap<SetDepartmentDTO, Department>();
    }
}
