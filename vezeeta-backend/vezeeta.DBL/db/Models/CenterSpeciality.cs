using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezeeta.DBL.db.Models
{
    public class CenterSpeciality : IGenericModel
    {
        
        [ForeignKey("CenterId")]
        public Guid? CenterId { get; set; }
        [ForeignKey("SpecialityId")]
        public Guid? SpecialityId { get; set; }

        public Center? Center { get; set; }
        public Speciality? Speciality { get; set; }
        public Guid Id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
