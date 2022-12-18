using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace vezeeta.BL
{
    public class GenericNameDTOs: IGenericNameDTOs
    {
        public Guid Id { get; set; }
        public string? name_ar { get; set; }
        public string? name_en { get; set; }
        public bool is_active { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string? name
        {
            get => Helper.getLnag() == "ar" ? name_ar : name_en;
        }
    }
}
