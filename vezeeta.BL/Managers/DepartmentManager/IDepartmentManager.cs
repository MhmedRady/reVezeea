using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.BL;

namespace vezeeta.BL;

public interface IDepartmentManager
{
    public List<DepartmentDTO> Index();
    public DepartmentDTO? GetByID(Guid id);
    public void Add(SetDepartmentDTO department);
    public void Update(SetDepartmentDTO department);
    public DepartmentDTO Delete(Guid id);
    public bool IsActive(DepartmentDTO department);
    public void Activate(SetDepartmentDTO department);
    public bool Find(DepartmentDTO department);
}
