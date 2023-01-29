using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using vezeeta.admin.Controllers;
using vezeeta.BL;
using vezeeta.BL.DTOs.Center;

namespace vezeeta.admin.Validations;

public class CenterValidation : AbstractValidator<CenterDTO>
{
    private readonly IStringLocalizer<CenterController> localizer;
    public CenterValidation(IStringLocalizer<CenterController> _localizer)
    {
        RuleFor(c => c.name_ar).NotNull()
            .WithMessage("Department English Name Can't Be Empty")
            .MinimumLength(2).WithMessage("Department English Name length Can't Be less than 2 characters");
        RuleFor(c => c.name_en)
            .NotNull()
            .WithMessage("Department Arabic Name Can't Be Empty")
            .MinimumLength(2).WithMessage("Department Arabic Name length Can't Be less than 2 characters");
        RuleFor(c => c.email)
            .NotNull().WithMessage("Email can't be empty")
            .EmailAddress().WithMessage("Email not valid");
        RuleFor(c => c.phone)
             .NotNull().WithMessage("Phone can't be empty")
             .MaximumLength(8).WithMessage("Phone must consist of 8 number");
        RuleFor(c => c.mobile)
            .NotNull().WithMessage("Phone can't be empty")
             .MaximumLength(11).WithMessage("Mobile must consist of 11 number");
             //.Matches("/^(01)(0|1|2|5)\\d[0-9]{8}$/").WithMessage("Mobile must start with 01");


        /*RuleFor(x => x.logo).Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                .WithMessage("File type is larger than allowed");*/
    }
}
