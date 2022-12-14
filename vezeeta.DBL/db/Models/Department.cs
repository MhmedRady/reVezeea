﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL.db.GenericModels;

namespace vezeeta.DBL.db.Models;


public class Department
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

    public ICollection<Center> Centers { get; set; }

    public Department() { 
        Centers = new HashSet<Center>();
    }
}
