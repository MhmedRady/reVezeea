using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using vezeeta.DBL;

namespace vezeeta.BL.DTOs.Center;

public class CenterDTO : GenericNameDTOs
{
    public Guid? DepartmentId { get; set; }
    public Guid? UserId { get; set; }
    public string? logo { get; set; }
    public string? email { get; set; }
    public string? mobile { get; set; }
    public string? phone { get; set; }
    [DefaultValue(0)]
    public int views { get; set; }
    [DefaultValue(0)]
    public int visitors { get; set; }
    [DefaultValue(0.0)]
    public float? amount { get; set; }
    public DepartmentDTO? Department { get; set; }
    
}