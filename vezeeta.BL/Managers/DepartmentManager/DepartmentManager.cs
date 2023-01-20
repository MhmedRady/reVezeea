using AutoMapper;
using Azure.Core;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.BL;
using vezeeta.DBL;
using vezeeta.DBL.UnitOfWork;

namespace vezeeta.BL
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IUnitOfRepo _workRepo;
        private readonly IMapper mapper;

        public DepartmentManager(IUnitOfRepo _workRepo, IMapper mapper)
        {
            this._workRepo = _workRepo;
            this.mapper = mapper;
        }

        public IEnumerable<DepartmentDTO> Index()
        {
            return mapper.Map<IEnumerable<DepartmentDTO>>(_workRepo.DepartmentRepo.Index());
        }

        public bool Activate(Guid id)
        {
            var dept = _workRepo.DepartmentRepo.GetByID(id);
            if(dept is null) { return false; }
            dept.is_active = !dept.is_active;
            _workRepo.DepartmentRepo.Update(dept);
            _workRepo.DepartmentRepo.SaveChanges();
            return true;
        }

        public void Add(DepartmentDTO department)
        {
            department.created_at = DateTime.Now;
            var dept = mapper.Map<Department>(department);
            _workRepo.DepartmentRepo.Add(dept);
            _workRepo.DepartmentRepo.SaveChanges();
        }

        public bool Delete(Guid id)
        {
            var dept = _workRepo.DepartmentRepo.GetByID(id);
            if(dept is null) { return false; }
            _workRepo.DepartmentRepo.Delete(dept);
            _workRepo.DepartmentRepo.SaveChanges();
            return true;
        }

        public DepartmentDTO? GetByID(Guid id)
        {
            var dept = _workRepo.DepartmentRepo.GetByID(id);
            if(dept is null) { return null; }
            return mapper.Map<DepartmentDTO>(dept);
        }

        public bool IsActive(Guid id)
        {
            var dept = _workRepo.DepartmentRepo.GetByID(id);
            if(dept is null || dept.is_active is false) { return false; }
            return true;
        }

        public bool Update(DepartmentDTO department)
        {
            var dept = _workRepo.DepartmentRepo.GetByID(department.Id);
            if(dept is null) { return false; }
            var _dept = mapper.Map(department, dept);
            dept.updated_at = DateTime.Now;
            dept.created_at = department.created_at;
            this._workRepo.DepartmentRepo.Update(dept);
            this._workRepo.DepartmentRepo.SaveChanges();
            return true;
        }

        public bool Find(DepartmentDTO? department)
        {
            var dept = mapper.Map<Department>(department);
            return _workRepo.DepartmentRepo.Find(dept);
        }

        public IEnumerable<DepartmentDTO>? LoadData()
        {
            return mapper.Map<ICollection<DepartmentDTO>>(_workRepo.DepartmentRepo.LoadData());
        }
    }
}
