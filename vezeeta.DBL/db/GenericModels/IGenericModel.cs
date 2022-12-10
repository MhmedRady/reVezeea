using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace vezeeta.DBL.db.GenericModels
{
    public interface IGenericModel
    {
        [Key]
        public Guid Id { get; set; }
        [DefaultValue("getdate()")]
        [Comment("Created DateTime")]
        public DateTime? created_at { get; set; }
        [Comment("Last Update DateTime")]
        public DateTime? updated_at { get; set; }
    }
}
