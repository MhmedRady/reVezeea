using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.BL;

namespace vezeeta.DBL;

public class UnitOfManger : IUnitOfManger
{
    public IAdminManager AdminManager { get; }
    public IDepartmentManager DepartmentManager { get; }

    public UnitOfManger(IAdminManager adminManager, IDepartmentManager departmentManager)
    {
        AdminManager = adminManager;
        DepartmentManager = departmentManager;
    }
}
