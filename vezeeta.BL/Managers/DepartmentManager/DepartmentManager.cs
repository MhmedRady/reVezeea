using AutoMapper;
using Azure.Core;
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

        public List<DepartmentDTO> Index()
        {
            return mapper.Map<List<DepartmentDTO>>(_workRepo.DepartmentRepo.Index());
        }

        public void Activate(SetDepartmentDTO department)
        {
            throw new NotImplementedException();
        }

        public void Add(SetDepartmentDTO department)
        {
            department.created_at = DateTime.Now;
            var dept = mapper.Map<Department>(department);
            _workRepo.DepartmentRepo.Add(dept);
            _workRepo.DepartmentRepo.SaveChanges();
        }

        public DepartmentDTO Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public DepartmentDTO? GetByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool IsActive(DepartmentDTO department)
        {
            throw new NotImplementedException();
        }

        public void Update(SetDepartmentDTO department)
        {
            department.updated_at = DateTime.Now;
            throw new NotImplementedException();
        }

        public bool Find(DepartmentDTO department)
        {
            var dept = mapper.Map<Department>(department);
            return _workRepo.DepartmentRepo.Find(dept);
        }
    }
}
