using FluentValidation;
using Microsoft.Extensions.Localization;
using vezeeta.admin.Controllers;
using vezeeta.BL;

namespace vezeeta.admin.Validations;

public class AdminLoginValidation : AbstractValidator<AdminDTO>
{
    private readonly IStringLocalizer<AdminAuthController> localizer;
    public AdminLoginValidation(IStringLocalizer<AdminAuthController> _localizer)
    {
        RuleFor(a => a.email).NotNull()
            .WithMessage("Email Can't Be Empty")
            .EmailAddress()
            .WithMessage("Emaill Address is not a Correct!");
        RuleFor(a => a.password).NotNull()
            .WithMessage("Password Can't Be Empty");
    }
}
