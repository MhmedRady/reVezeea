using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezeeta.BL
{
    public class AdminDTO : GenericUserDTOs
    {
        [DefaultValue(true)]
        public bool is_admin { get => true; }

        /*public string? firstName { get; set; }
        public string? middleName { get; set; }
        public string? lastName { get; set; }*/

    }
}
