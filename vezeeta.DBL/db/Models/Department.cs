using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL.db.GenericModels;

namespace vezeeta.DBL.db.Models;

[Index(nameof(name_ar), IsUnique = true)]
[Index(nameof(name_en), IsUnique = true)]
public class Department : IGenericNamedModel
{
    public Guid Id { get; set; }
    public string? name_ar { get; set; }
    public string? name_en { get; set; }
    [MinLength(14)]
    [Comment("Doctor User National ID")]
    public bool is_active { get; set; }
    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set; }
}
