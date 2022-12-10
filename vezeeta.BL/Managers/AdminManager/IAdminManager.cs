using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.BL.DTOs.Admin;

namespace vezeeta.BL.Managers;

public interface IAdminManager
{
    public List<AdminDTO> Index();
    public AdminDTO? GetByID(Guid id);
    public void Add(AdminDTO admin);
    public void Update(AdminDTO admin);
    public AdminDTO Delete(Guid id);
    public bool IsAdmin(AdminDTO admin);
}
