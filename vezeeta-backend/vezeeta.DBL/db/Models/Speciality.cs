using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL.db.GenericModels;

namespace vezeeta.DBL.db.Models
{
    public class Speciality : BaseNamedEntity
    {
        public string logo { get; set; }
        public Guid? MainSpecialityId { get; set; }
        public virtual Speciality? MainSpeciality { get; set; }
        public virtual ICollection<Center> Centers { get; set; }

        public Speciality()
        {
            Centers = new HashSet<Center>();
        }
    }
}
