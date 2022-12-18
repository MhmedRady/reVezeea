using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using vezeeta.BL;
using vezeeta.DBL;

namespace vezeeta.admin.Controllers
{
    public class AdminAuthController : Controller
    {
        private readonly IAdminManager _adminManager;

        public AdminAuthController(IAdminManager adminManager)
        {
            _adminManager = adminManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _adminManager.GetByUserName(model.UserName);
            if (user != null)
            {
                Claim c1 = new Claim("id", user.Id.ToString());
                Claim c2 = new Claim("name", user.userName);
                Claim c3 = new Claim(ClaimTypes.Role, "admin");

                ClaimsIdentity ci = new ClaimsIdentity("cookieAuth");
                ci.AddClaim(c1);
                ci.AddClaim(c2);
                ci.AddClaim(c3);

                //foreach (Roles R in user.Roles)
                //{
                //    ci.AddClaim(new Claim(ClaimTypes.Role, R.Name));
                //}

                ClaimsPrincipal cp = new ClaimsPrincipal(ci);
                await HttpContext.SignInAsync(cp);
                return RedirectToAction("index", "home");
            }
            else
            {
                ModelState.AddModelError("", "username or password does notexists");
                return View(model);
            }
            return View();
        }

    }
}
