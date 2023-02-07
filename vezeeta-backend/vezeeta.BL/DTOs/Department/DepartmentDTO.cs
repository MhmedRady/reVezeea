using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using vezeeta.BL;

namespace vezeeta.BL;

public class DepartmentDTO : GenericNameDTOs
{
    private int uid { get; set; }
}