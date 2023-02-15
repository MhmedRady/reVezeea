using AutoMapper;
using vezeeta.BL.DTOs.Speciality;
using vezeeta.DBL.db.Models;
using vezeeta.DBL.Repos.CenterRepo;
using vezeeta.DBL.UnitOfWork;

namespace vezeeta.BL.Managers.SpecialityManager
{
    public class SpecialityManager : ISpecialityManager
    {
        private readonly IUnitOfRepo _workRepo;
        private readonly IMapper mapper;
        public SpecialityManager(IUnitOfRepo _workRepo, IMapper mapper)
        {
            this._workRepo = _workRepo;
            this.mapper = mapper;
        }
        public bool Activate(Guid id)
        {
            var specialityRepo = _workRepo.SpecialityRepo.GetByID(id);
            if (specialityRepo == null) return false;
            specialityRepo.is_active = !specialityRepo.is_active;
            _workRepo.SpecialityRepo.Update(specialityRepo);
            _workRepo.SpecialityRepo.SaveChanges();
            return true;
        }

        public void Add(SpecialityDTO entity)
        {
            entity.created_at = DateTime.Now;
            var specialityRepo = mapper.Map<Speciality>(entity);
            _workRepo.SpecialityRepo.Add(specialityRepo);
            _workRepo.SpecialityRepo.SaveChanges();
        }

        public bool Delete(Guid id)
        {
            var speciality = _workRepo.SpecialityRepo.GetByID(id);
            bool speciality_found = _workRepo.SpecialityRepo.Find(speciality, false);
            if(!speciality_found) return false;
            _workRepo.SpecialityRepo.Delete(speciality);
            _workRepo.SpecialityRepo.SaveChanges();
            return true;
        }

        public bool Find(SpecialityDTO entity)
        {
            var specialityRepo = mapper.Map<Speciality>(entity);
            return _workRepo.SpecialityRepo.Find(specialityRepo);
        }

        public SpecialityDTO? GetByID(Guid id)
        {
            var speciality = _workRepo.SpecialityRepo.GetByID(id);
            if (speciality is null) return null;
            return mapper.Map<SpecialityDTO>(speciality);
        }

        public IEnumerable<SpecialityDTO> Index()
        {
            return mapper.Map<ICollection<SpecialityDTO>>(_workRepo.SpecialityRepo.Index());
        }

        public bool IsActive(Guid id)
        {
            var specialityRepo = _workRepo.SpecialityRepo.GetByID(id);
            if (specialityRepo.is_active == false) return false;
            return true;
        }

        public IEnumerable<SpecialityDTO>? LoadData()
        {
            return mapper.Map<ICollection<SpecialityDTO>>((_workRepo.SpecialityRepo.LoadData()));
        }

        public IEnumerable<SpecialityDTO>? _Any()
        {
            return mapper.Map<ICollection<SpecialityDTO>>(_workRepo.SpecialityRepo._Any());
        }

        public bool Update(SpecialityDTO entity)
        {
            entity.updated_at = DateTime.Now;
            var specialityRepo = _workRepo.SpecialityRepo.GetByID(entity.Id);
            if(specialityRepo == null) return false;
            var specialityDto = mapper.Map(entity, specialityRepo);
            _workRepo.SpecialityRepo.Update(specialityRepo);
            _workRepo.SpecialityRepo.SaveChanges();
            return true;
        }
    }
}
