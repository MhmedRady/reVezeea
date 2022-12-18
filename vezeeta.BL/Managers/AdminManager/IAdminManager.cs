using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezeeta.BL;

public interface IAdminManager
{
    public List<AdminDTO> Index();
    public AdminDTO? GetByID(Guid id);
    public void Add(AdminDTO admin);
    public void Update(AdminDTO admin);
    public AdminDTO Delete(Guid id);
    public bool IsAdmin(AdminDTO admin);
    public AdminDTO? GetByUserName(string userName);
}
