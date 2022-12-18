using AutoMapper;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.BL;
using vezeeta.DBL;

namespace vezeeta.BL
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentRepo departmentRepo;
        private readonly IMapper mapper;

        public DepartmentManager(IDepartmentRepo departmentRepo, IMapper mapper)
        {
            this.departmentRepo = departmentRepo;
            this.mapper = mapper;
        }

        public List<DepartmentDTO> Index()
        {
            return mapper.Map<List<DepartmentDTO>>(departmentRepo.Index());
        }

        public void Activate(DepartmentDTO department)
        {
            throw new NotImplementedException();
        }

        public void Add(DepartmentDTO department)
        {
            var dept = mapper.Map<Department>(department);
            departmentRepo.Add(dept);
            departmentRepo.SaveChanges();
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

        public void Update(DepartmentDTO department)
        {

            throw new NotImplementedException();
        }
    }
}
