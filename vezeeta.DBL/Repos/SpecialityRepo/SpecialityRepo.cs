using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL.db.Models;

namespace vezeeta.DBL.Repos.SpecialityRepo
{
    public class SpecialityRepo : GenericRepo<Speciality>, ISpecialityRepo
    {
        private VezeetaDB _vezeetaDB;
        public SpecialityRepo(VezeetaDB _vezeetaDB) : base(_vezeetaDB)
        {
            _vezeetaDB = _vezeetaDB;

        }

        public override IEnumerable<Speciality>? LoadData()
        {
            return _vezeetaDB.specialities.Include(c => c.MainSpeciality).ToList();
        }
        public bool Find(Speciality speciality, bool checkName = true)
        {
            if(checkName is true)
            {
                bool speciality_found = _Any().Any(c => c.name_ar == speciality.name_ar || c.name_en == speciality.name_en);
                return speciality_found;
            }

            return _Any().Any(c => c.Id == speciality.Id);
        }

    }
}
