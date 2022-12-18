using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL;

namespace vezeeta.DBL;

public class UserRepo : GenericRepo<User>, IUserRepo
{
    private VezeetaDB vezeetaDB;
    public UserRepo(VezeetaDB _vezeetaDB) : base(_vezeetaDB)
    {
        vezeetaDB = _vezeetaDB;
    }
}
