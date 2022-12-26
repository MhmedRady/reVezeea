using AutoMapper;
using System;
using vezeeta.DBL;

namespace vezeeta.BL;

public class AdminManager : IAdminManager
{
    private readonly IUserRepo _adminRepo;
    private readonly IMapper _mapper;

    public AdminManager(IUserRepo adminRepo, IMapper mapper)
    {
        this._adminRepo = adminRepo;
        this._mapper = mapper;
    }

    public List<AdminDTO> Index()
    {
        var adminRepoList = _adminRepo.Index();
        return _mapper.Map<List<AdminDTO>>(adminRepoList);
    }

    public void Add(AdminDTO admin)
    {
        throw new NotImplementedException();
    }

    public AdminDTO Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public AdminDTO? GetByID(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool IsAdmin(AdminDTO admin)
    {
        throw new NotImplementedException();
    }

    public void Update(AdminDTO admin)
    {
        throw new NotImplementedException();
    }

    public bool chickLogin(AdminDTO admin)
    {
        var _admin = _adminRepo._Any();
        return this._mapper.Map<Boolean>(_admin.Any(a=>a.is_active is false));
    }

    public bool Find(AdminDTO admin, bool checkUnique = true)
    {
        var _admin = _mapper.Map<User>(admin);
        if (checkUnique)
        {
            return _adminRepo._Any().Any(
                   a => a.userName == admin.userName ||
                   a.email == admin.email);
        }
        return _adminRepo._Any().Any(a => a.Id == admin.Id);
    }
}
