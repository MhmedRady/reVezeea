using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.BL;

namespace vezeeta.BL;

public interface IDepartmentManager
{
    public IEnumerable<DepartmentDTO> Index();
    public DepartmentDTO? GetByID(Guid id);
    public void Add(DepartmentDTO department);
    public bool Update(DepartmentDTO department);
    public bool Delete(Guid id);
    public bool IsActive(Guid id);
    public bool Activate(Guid id);
    public bool Find(DepartmentDTO department);
    public IEnumerable<DepartmentDTO>? LoadData();
}
