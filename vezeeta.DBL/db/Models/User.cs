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

public class User : IGenericActiveModel
{
    public Guid Id { get; set; }
    public string? userName { get; set; }
    public string? firstName { get; set; }
    public string? middleName { get; set; }
    public string? lastName { get; set; }
    public string? email { get; set; }
    public string? password { get; set; }
    public string? mobile { get; set; }
    public string? phone { get; set; }
    public string? profile_image { get; set; }
    [MinLength(14)]
    [Comment("Doctor User National ID")]
    public string? N_ID { get; set; }
    [DefaultValue(false)]
    public bool is_admin { get; set; }
    [DefaultValue(false)]
    public bool is_doctor { get; set; }    
    public bool is_active { get; set; }
    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set; }
}
