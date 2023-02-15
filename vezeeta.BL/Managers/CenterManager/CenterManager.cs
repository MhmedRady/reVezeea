using AutoMapper;
using vezeeta.BL.DTOs.Center;
using vezeeta.DBL;
using vezeeta.DBL.Repos.CenterRepo;
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
        return mapper.Map<ICollection<CenterDTO>>(_workRepo.CenterRepo.Index());
    }

    public CenterDTO? GetByID(Guid id)
    {
        var center = _workRepo.CenterRepo.GetByID(id);
        if (center is null) return null;
        return mapper.Map<CenterDTO>(center);
    }

    public void Add(CenterDTO entity)
    {
        entity.created_at = DateTime.Now;
        var centerRepo= mapper.Map<Center>(entity);
        _workRepo.CenterRepo.Add(centerRepo);
        _workRepo.CenterRepo.SaveChanges();
    }

    public bool Update(CenterDTO entity)
    {
        //check on entity if null???????
        entity.updated_at = DateTime.Now;
        var centerRepo= _workRepo.CenterRepo.GetByID(entity.Id);
        if(centerRepo == null) return false;
        var centerDto= mapper.Map(entity,centerRepo);
        _workRepo.CenterRepo.Update(centerRepo);
        _workRepo.CenterRepo.SaveChanges();
        return true;
    }

    public bool Delete(Guid id)
    {
        var center = _workRepo.CenterRepo.GetByID(id);
        bool center_found = _workRepo.CenterRepo.Find(center, false);
        if(center_found==false) return false;
        _workRepo.CenterRepo.Delete(center);
        _workRepo.CenterRepo.SaveChanges();
        return true;
    }

    public bool IsActive(Guid id)
    {
       var centerRepo= _workRepo.CenterRepo.GetByID(id);
        //centerRepo is null what happend 
        if( centerRepo.is_active == false) return false;
        return true;
    }

    public bool Activate(Guid id)
    {
        var centerRepo = _workRepo.CenterRepo.GetByID(id);
        if(centerRepo==null)return false;
        centerRepo.is_active=!centerRepo.is_active;
        _workRepo.CenterRepo.Update(centerRepo);
        _workRepo.CenterRepo.SaveChanges();
        return true;
    }
    public bool Find(CenterDTO entity)//search any thing except id
    {
        var centerRepo = mapper.Map<Center>(entity);
        return _workRepo.CenterRepo.Find(centerRepo);
    }

    public IEnumerable<CenterReadDto>? LoadData()
    {
        return mapper.Map<ICollection<CenterReadDto>>((_workRepo.CenterRepo.LoadData()));
    }

    public IEnumerable<CenterDTO>? _Any()
    {
        return mapper.Map<ICollection<CenterDTO>>(_workRepo.CenterRepo._Any());
    }

    IEnumerable<CenterDTO>? IGenericManager<CenterDTO>.LoadData()
    {
        throw new NotImplementedException();
    }

}