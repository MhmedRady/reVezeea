using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Data;
using System.Security.Claims;
using vezeeta.admin.Validations;
using vezeeta.BL;
using vezeeta.DBL;

namespace vezeeta.admin.Controllers
{
    public class AdminAuthController : Controller
    {
        private readonly IUnitOfManger _unitOfManger;
        private readonly IStringLocalizer<AdminAuthController> localizer;

        public AdminAuthController(VezeetaDB vezeetaDB, IUnitOfManger unitOfManger, IStringLocalizer<AdminAuthController> _localizer)
        {
            localizer = _localizer;
            _unitOfManger = unitOfManger;
        }
        public IActionResult Index()
        {
            List<AdminDTO>? adminDtos= _unitOfManger.AdminManager.Index();
            return View();
        }

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(AdminDTO admin)
        {
            AdminLoginValidation validations = new AdminLoginValidation(localizer);
            ValidationResult result = validations.Validate(admin);
            if (!result.IsValid)
            {
                foreach (var err in result.Errors)
                {
                    TempData[err.PropertyName] = err.ErrorMessage;
                }
                return View(admin);
            }
            var user = _unitOfManger.AdminManager.chickLogin(admin);

            if (user is not AdminDTO)
            {
                TempData["error_msg"] = "email or password does not correct!";
                return View(admin);
            }

            Claim c1 = new Claim("id", user.Id.ToString());
            Claim c2 = new Claim("name", user.userName);
            Claim c3 = new Claim(ClaimTypes.Role, "admin");

            ClaimsIdentity ci = new ClaimsIdentity("cookieAuth");
            ci.AddClaim(c1);
            ci.AddClaim(c2);
            ci.AddClaim(c3);

            ClaimsPrincipal cp = new ClaimsPrincipal(ci);
            await HttpContext.SignInAsync(cp);
            return RedirectToAction("index", "home");
        }

    }
}
