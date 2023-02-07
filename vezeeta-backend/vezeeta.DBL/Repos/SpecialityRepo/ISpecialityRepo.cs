using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL.db.Models;

namespace vezeeta.DBL.Repos.SpecialityRepo
{
    public interface ISpecialityRepo : IGenericRepo<Speciality>
    {
        public bool Find(Speciality speciality, bool checkName = true);

    }
}
