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
    public void Add(DepartmentDTO department);
    public void Update(DepartmentDTO department);
    public DepartmentDTO Delete(Guid id);
    public bool IsActive(DepartmentDTO department);
    public void Activate(DepartmentDTO department);
}
