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

    public virtual bool IsActive(User user)
    {
        return _Any().Where(a=>a.is_active == true && a.Id == user.Id).Any();
    }
    public bool Find(User user, bool checkName = true)
    {
        if (checkName is true)
        {
            return _Any().Any(d => d.username == user.username);
        }
        return _Any().Any(d => d.Id == user.Id);
    }
}
