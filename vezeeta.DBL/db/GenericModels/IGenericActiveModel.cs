using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace vezeeta.DBL.db.GenericModels
{
    public interface IGenericActiveModel : IGenericModel
    {
        [DefaultValue(0)]
        [Comment("User activate status [True, False]")]
        public bool is_active { get; set; }
    }
}
