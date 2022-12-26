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
        public async Task<IActionResult> login(AdminDTO admin)
        {
            
            var user = _adminManager.chickLogin(admin);

            if (user is true)
            {
                Claim c1 = new Claim("id", admin.Id.ToString());
                Claim c2 = new Claim("name", admin.userName);
                Claim c3 = new Claim(ClaimTypes.Role, "admin");

                ClaimsIdentity ci = new ClaimsIdentity("cookieAuth");
                ci.AddClaim(c1);
                ci.AddClaim(c2);
                ci.AddClaim(c3);

                ClaimsPrincipal cp = new ClaimsPrincipal(ci);
                await HttpContext.SignInAsync(cp);
                return RedirectToAction("index", "home");
            }
            else
            {
                ModelState.AddModelError("", "username or password does notexists");
                return View(admin);
            }
            return View();
        }

    }
}
