using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezeeta.DBL.db.GenericModels;

[Index(nameof(name_ar), IsUnique = true)]
[Index(nameof(name_en), IsUnique = true)]
public class GenericNamedModel 
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string? name_ar { get; set; }
    [Required]
    public string? name_en { get; set; }
    [DefaultValue(0)]
    [Comment("Entity Row activate status [True, False]")]
    public bool is_active { get; set; }
    [DefaultValue("getdate()")]
    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set; }
}
