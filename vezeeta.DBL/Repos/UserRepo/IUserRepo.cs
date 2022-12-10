using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL.db.Models;

namespace vezeeta.DBL.Repos.UserRepo
{
    public interface IUserRepo : IGenericRepo<User>
    {
        public virtual void ActivateUser(User user) { }
    }
}
