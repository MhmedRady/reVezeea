using AutoMapper;
using vezeeta.BL;
using vezeeta.DBL;


namespace vezeeta.BL;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, AdminDTO>();
        //CreateMap<AdminDTO, User>();
    }
}
