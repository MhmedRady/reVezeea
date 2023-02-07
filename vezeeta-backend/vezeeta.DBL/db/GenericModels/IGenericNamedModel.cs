using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vezeeta.DBL;


public interface IGenericNamedModel : IGenericActiveModel
{

    public string? name_ar { get; set; }
    public string? slug_ar { get; set; }
    public string? name_en { get; set; }
    public string? slug_en { get; set; }
}
