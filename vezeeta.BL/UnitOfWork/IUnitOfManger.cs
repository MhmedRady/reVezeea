using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.BL;

namespace vezeeta.DBL;

public interface IUnitOfManger
{
    IAdminManager AdminManager { get; }
    IDepartmentManager DepartmentManager { get; }

}
