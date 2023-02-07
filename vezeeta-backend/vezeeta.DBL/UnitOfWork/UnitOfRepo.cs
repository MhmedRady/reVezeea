using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL.Repos.CenterRepo;
using vezeeta.DBL.Repos.SpecialityRepo;

namespace vezeeta.DBL.UnitOfWork;

public class UnitOfRepo : IUnitOfRepo
{
    public IUserRepo UserRepo { get; }
    public IDepartmentRepo DepartmentRepo { get; }
    public ICenterRepo CenterRepo { get; }
    public ISpecialityRepo SpecialityRepo { get; }

    public UnitOfRepo(IUserRepo userRepo, IDepartmentRepo departmentRepo, ICenterRepo centerRepo, ISpecialityRepo specialityRepo)
    {
        UserRepo = userRepo;
        DepartmentRepo = departmentRepo;
        CenterRepo = centerRepo;
        SpecialityRepo = specialityRepo;
    }
}
