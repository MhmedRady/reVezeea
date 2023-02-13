using FluentValidation;
using Microsoft.Extensions.Localization;
using vezeeta.admin.Controllers;
using vezeeta.BL.DTOs.Speciality;

namespace vezeeta.admin.Validations
{
    public class SpecialityValidation : AbstractValidator<SpecialityDTO>
    {
        private readonly IStringLocalizer<SpecialityController> localizer;
        public SpecialityValidation(IStringLocalizer<SpecialityController> _localizer)
        {
            RuleFor(c => c.name_en).NotNull()
                .WithMessage("Speciality English Name Can't Be Empty")
                .MinimumLength(2).WithMessage("Speciality English Name length Can't Be less than 2 characters");
            RuleFor(c => c.name_ar)
                .NotNull()
                .WithMessage("Speciality Arabic Name Can't Be Empty")
                .MinimumLength(2).WithMessage("Speciality Arabic Name length Can't Be less than 2 characters");

           }
    }
}
