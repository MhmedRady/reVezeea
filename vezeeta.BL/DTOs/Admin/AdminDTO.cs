using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezeeta.BL.DTOs.Admin
{
    public class AdminDTO
    {
        public Guid Id { get; set; }
        public string? userName { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? mobile { get; set; }
        public string? profile_image { get; set; }
        [DefaultValue(false)]
        public bool is_admin { get; set; } = true;
        public bool is_active { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

        /*public string? firstName { get; set; }
        public string? middleName { get; set; }
        public string? lastName { get; set; }*/

    }
}
