using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezeeta.DBL.UnitOfWork;

public class UnitOfRepo : IUnitOfRepo
{
    public IUserRepo UserRepo { get; }
    public IDepartmentRepo DepartmentRepo { get; }

    public UnitOfRepo(IUserRepo userRepo, IDepartmentRepo departmentRepo)
    {
        UserRepo = userRepo;
        DepartmentRepo = departmentRepo;
    }
}
