using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace vezeeta.DBL
{
    public class BaseEntity :IGenericModel
    {
        [Key]
        public Guid Id { get; set; }
        [DefaultValue(false)]
        public bool is_active { get; set; }
        [Comment("Created At DateTime")]
        [DefaultValue("getdate()")]
        public DateTime? created_at { get; set; }
        [Comment("Last Update DateTime")]
        public DateTime? updated_at { get; set; }
    }
}
