using System;
using System.Text.Json.Serialization;
using vezeeta.BL.DTOs.Center;
using vezeeta.BL.DTOs.Doctor;
using vezeeta.BL.DTOs.User;


namespace vezeeta.BL
{
    [JsonDerivedType(typeof(AdminDTO))]
    [JsonDerivedType(typeof(DoctorDto))]
    
    public class GenericUserDTOs: IGenericUserDTOs
    {
        public Guid Id { get; set; }
        public string? userName { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? mobile { get; set; }
        public string? profile_image { get; set; }
        
        public bool is_active { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
