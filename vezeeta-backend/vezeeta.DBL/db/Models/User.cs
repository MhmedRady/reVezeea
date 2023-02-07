using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezeeta.DBL;

namespace vezeeta.DBL;

[Index(nameof(username), IsUnique = true)]
[Index(nameof(email), IsUnique = true)]

public class User : BaseEntity
{
    public string? username { get; set; }
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
    [Comment("User Date Of Barth")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? dob { get; set; }
    public string? gender { get; set; }
    [DefaultValue(false)]
    public bool is_admin { get; set; }
    [DefaultValue(false)]
    public bool is_doctor { get; set; }
    public ICollection<Center> Centers { get; set; }

    public User()
    {
        Centers = new HashSet<Center>();
    }
}
