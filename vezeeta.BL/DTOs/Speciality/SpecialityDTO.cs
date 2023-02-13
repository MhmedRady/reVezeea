using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.BL.DTOs.Center;

namespace vezeeta.BL.DTOs.Speciality
{
    public class SpecialityDTO : GenericNameDTOs
    {
        public string? logo { get; set; }
        public Guid? MainSpecialityId { get; set; }
        public virtual SpecialityDTO? MainSpeciality { get; set; }
        public virtual ICollection<CenterDTO> Centers { get; set; }
        public SpecialityDTO()
        {
            Centers = new HashSet<CenterDTO>();
        }


    }
}
