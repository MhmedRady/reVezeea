using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL.db.GenericModels;
using vezeeta.DBL.db;
using Microsoft.EntityFrameworkCore;

namespace vezeeta.DBL
{
    public class Center : BaseNamedEntity {

        [ForeignKey("DepartmentId")]
        public Guid? DepartmentId { get; set; }
        [ForeignKey("UserId")]
        [Comment("Owner Doctor UserId Where User Is Doctor")]
        public Guid? UserId { get; set; }
        public string? logo { get; set; }
        public string? email { get; set; }
        public string? mobile { get; set; }
        public string? phone { get; set; }
        [DefaultValue(0)]
        public int views { get; set; }
        [DefaultValue(0)]
        public int visitors { get; set; }
        [DefaultValue(0.0)]
        public float? amount { get; set; }
        public Department? Department { get; set; }
        public User? User { get; set; }
        public Center() { 

        }
    }
}
