using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL.Repos.CenterRepo;

namespace vezeeta.DBL.UnitOfWork;

public interface IUnitOfRepo
{
    IUserRepo UserRepo { get; }
    IDepartmentRepo DepartmentRepo { get; }
    ICenterRepo CenterRepo { get; }
    
}
