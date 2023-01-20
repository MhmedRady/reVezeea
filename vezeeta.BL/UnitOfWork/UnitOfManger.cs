using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.BL;
using vezeeta.BL.Managers.CenterManger;

namespace vezeeta.DBL;

public class UnitOfManger : IUnitOfManger
{
    public IAdminManager AdminManager { get; }
    public IDepartmentManager DepartmentManager { get; }
    public ICenterManager CenterManager { get; }

    public UnitOfManger(IAdminManager adminManager, IDepartmentManager departmentManager, ICenterManager centerManager)
    {
        AdminManager = adminManager;
        DepartmentManager = departmentManager;
        CenterManager = centerManager;
    }
}
