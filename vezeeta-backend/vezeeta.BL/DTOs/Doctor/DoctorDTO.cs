using vezeeta.BL;
namespace vezeeta.BL.DTOs.Doctor;
class DoctorDto : GenericUserDTOs
{
    public string? firstName { get; set; }
    public string? middleName { get; set; }
    public string? lastName { get; set; }
    public bool is_doctor { get; set; } = true;

    public string? fullname
    {
        get => string.Concat(this.firstName, " ",this.middleName, " ",this.lastName);
    }
}