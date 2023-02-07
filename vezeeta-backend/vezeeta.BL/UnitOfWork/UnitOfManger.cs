using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.BL;
using vezeeta.BL.Managers.CenterManger;
using vezeeta.BL.Managers.SpecialityManager;

namespace vezeeta.DBL;

public class UnitOfManger : IUnitOfManger
{
    public IAdminManager AdminManager { get; }
    public IDepartmentManager DepartmentManager { get; }
    public ICenterManager CenterManager { get; }
    public ISpecialityManager SpecialityManager { get; }

    public UnitOfManger(IAdminManager adminManager, IDepartmentManager departmentManager, ICenterManager centerManager, ISpecialityManager specialityManager)
    {
        AdminManager = adminManager;
        DepartmentManager = departmentManager;
        CenterManager = centerManager;
        SpecialityManager = specialityManager;
    }
}
