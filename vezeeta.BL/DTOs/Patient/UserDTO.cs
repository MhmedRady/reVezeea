using vezeeta.BL;
namespace vezeeta.BL.DTOs.User;
class PatientDto : GenericUserDTOs
{
    public string? firstName { get; set; }
    public string? middleName { get; set; }
    public string? lastName { get; set; }
    
    public string? fullname
    {
        get => string.Concat(this.firstName, " ",this.middleName, " ",this.lastName);
    }
}