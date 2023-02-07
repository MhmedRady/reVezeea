using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.BL;
using vezeeta.BL.Managers.CenterManger;
using vezeeta.BL.Managers.SpecialityManager;

namespace vezeeta.DBL;

public interface IUnitOfManger
{
    IAdminManager AdminManager { get; }
    IDepartmentManager DepartmentManager { get; }
    ICenterManager CenterManager { get; }
    ISpecialityManager SpecialityManager { get; }
}
