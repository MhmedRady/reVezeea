using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vezeeta.DBL;


public interface IGenericNamedModel : IGenericActiveModel
{
    [Required] 
    public string? name_ar { get; set; }
    [Required]
    public string? name_en { get; set; }
}
