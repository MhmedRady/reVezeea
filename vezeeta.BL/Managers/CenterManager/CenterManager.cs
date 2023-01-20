using AutoMapper;
using vezeeta.BL.DTOs.Center;
using vezeeta.DBL;
using vezeeta.DBL.UnitOfWork;

namespace vezeeta.BL.Managers.CenterManger;

public class CenterManager : ICenterManager
{
    private readonly IUnitOfRepo _workRepo;
    private readonly IMapper mapper;

    public CenterManager(IUnitOfRepo _workRepo, IMapper mapper)
    {
        this._workRepo = _workRepo;
        this.mapper = mapper;
    }

    public IEnumerable<CenterDTO> Index()
    {
        throw new NotImplementedException();
    }

    public CenterDTO? GetByID(Guid id)
    {
        var center = _workRepo.DepartmentRepo.GetByID(id);
        if (center is null) return null;
        return mapper.Map<CenterDTO>(center);
    }

    public void Add(CenterDTO entity)
    {
        entity.created_at = DateTime.Now;
        throw new NotImplementedException();
    }

    public bool Update(CenterDTO entity)
    {
        entity.updated_at = DateTime.Now;
        throw new NotImplementedException();
    }

    public bool Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool IsActive(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool Activate(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool Find(CenterDTO entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<CenterDTO>? LoadData()
    {
        throw new NotImplementedException();
    }
}