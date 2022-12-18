using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using vezeeta.admin.Controllers;
using vezeeta.BL;

namespace vezeeta.admin.Validations;

public class DepartmentValidation : AbstractValidator<DepartmentDTO>
{
    private readonly IStringLocalizer<DepartmentController> localizer;
    public DepartmentValidation(IStringLocalizer<DepartmentController> _localizer)
    {
        RuleFor(c => c.name_ar).NotNull()
            .WithMessage("Department English Name Can't Be Empty")
            .MinimumLength(2).WithMessage("Department English Name length Can't Be less than 2 characters");
        RuleFor(c => c.name_en)
            .NotNull()
            .WithMessage("Department Arabic Name Can't Be Empty")
            .MinimumLength(2).WithMessage("Department Arabic Name length Can't Be less than 2 characters");
    }
}
