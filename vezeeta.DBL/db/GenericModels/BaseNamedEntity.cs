﻿using Microsoft.EntityFrameworkCore;
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
public class BaseNamedEntity : IGenericNamedModel
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string? name_ar { get; set; }
    [Required]
    public string? name_en { get; set; }
    [DefaultValue(0)]
    public bool is_active { get; set; }
    [Comment("Created At DateTime")]
    [DefaultValue("getdate()")]
    public DateTime? created_at { get; set; }
    [Comment("Last Update DateTime")]
    public DateTime? updated_at { get; set; }
    
}
