using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL.db.context;
using vezeeta.DBL.db.Models;

namespace vezeeta.DBL.Repos.UserRepo;

public class DepartmentRepo : GenericRepo<User>, IDepartmentRepo
{
    private VezeetaDB vezeetaDB;
    public DepartmentRepo(VezeetaDB _vezeetaDB) : base(_vezeetaDB)
    {
        vezeetaDB = _vezeetaDB;
    }
}
