using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL;

namespace vezeeta.DBL;

public class DepartmentRepo : GenericRepo<User>, IDepartmentRepo
{
    private VezeetaDB vezeetaDB;
    public DepartmentRepo(VezeetaDB _vezeetaDB) : base(_vezeetaDB)
    {
        vezeetaDB = _vezeetaDB;
    }

    public User? GetByUserName(string userName)
    {
        return vezeetaDB.users.FirstOrDefault(u => u.userName == userName);
    }
}
