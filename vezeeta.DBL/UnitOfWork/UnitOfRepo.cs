using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL.Repos.CenterRepo;

namespace vezeeta.DBL.UnitOfWork;

public class UnitOfRepo : IUnitOfRepo
{
    public IUserRepo UserRepo { get; }
    public IDepartmentRepo DepartmentRepo { get; }
    public ICenterRepo CenterRepo { get; }
    public UnitOfRepo(IUserRepo userRepo, IDepartmentRepo departmentRepo, ICenterRepo centerRepo)
    {
        UserRepo = userRepo;
        DepartmentRepo = departmentRepo;
        CenterRepo = centerRepo;
    }
}
