using AutoMapper;
using System;
using System.Diagnostics;
using vezeeta.DBL;
using vezeeta.DBL.UnitOfWork;

namespace vezeeta.BL;

public class AdminManager : IAdminManager
{
    private readonly IUnitOfRepo _workRepo;
    private readonly IMapper _mapper;

    public AdminManager(IUnitOfRepo workRepo, IMapper mapper)
    {
        this._workRepo = workRepo;
        this._mapper = mapper;
    }

    public List<AdminDTO> Index()
    {
        var adminRepoList = _workRepo.UserRepo.Index();
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

    public AdminDTO? chickLogin(AdminDTO admin)
    {
        var _admin = _workRepo.UserRepo._Any();

        return this._mapper.Map<AdminDTO>(
            _admin.Where(
                a => a.email == admin.email &&
                a.password == admin.password &&
                a.is_active is true
            ).FirstOrDefault()
        );
    }

    public bool Find(AdminDTO admin, bool checkUnique = true)
    {
        var _admin = _mapper.Map<User>(admin);
        if (checkUnique)
        {
            return _workRepo.UserRepo._Any().Any(
                   a => a.username == admin.userName ||
                   a.email == admin.email);
        }
        return _workRepo.UserRepo._Any().Any(a => a.Id == admin.Id);
    }
}
