using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace vezeeta.DBL
{
    public interface IGenericActiveModel : IGenericModel
    {
        public bool is_active { get; set; }
    }
}
