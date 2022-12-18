using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL;

namespace vezeeta.DBL
{
    public interface IDepartmentRepo : IGenericRepo<Department>
    {
        public User? GetByUserName(string userName);

    }
}
