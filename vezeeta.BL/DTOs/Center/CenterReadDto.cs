using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace vezeeta.BL.DTOs.Center
{
    
    public class CenterReadDto : GenericNameDTOs
    {
        public string? email { get; set; }
        public string? mobile { get; set; }
        public string? phone { get; set; }
        public string? logo { get; set; }
        public DepartmentDTO? department { get; set; }
        public string? department_name { get => this.department.name; }


    }
}
