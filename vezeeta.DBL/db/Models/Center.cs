using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL.db.GenericModels;

namespace vezeeta.DBL
{
    public class Center : GenericNamedModel {

        [ForeignKey("DepartmentId")]
        public Guid? DepartmentId { get; set; }
        [ForeignKey("UserId")]
        public Guid? UserId { get; set; }
        public string? logo { get; set; }
        public string? email { get; set; }
        public string? mobile { get; set; }
        public string? phone { get; set; }
        public string? views { get; set; }
        public string? visitors { get; set; }

        public Department? Department { get; set; }    

        public User? User { get; set; } 

        public Center() { 

        }
    }
}
