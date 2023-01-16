using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezeeta.DBL.UnitOfWork;

public interface IUnitOfRepo
{
    IUserRepo UserRepo { get; }
    IDepartmentRepo DepartmentRepo { get; }
    
}
