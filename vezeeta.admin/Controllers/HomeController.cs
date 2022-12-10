using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using vezeeta.admin.Models;

namespace vezeeta.admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        #region Language
        //dependancy injection
        private readonly IStringLocalizer<HomeController> localizer;
        public HomeController(IStringLocalizer<HomeController> _localizer)
        {
            localizer = _localizer;
        }

        [HttpPost]
        public IActionResult SelectLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append
                (
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
            //return RedirectToAction(returnUrl);
        }
        #endregion
        public IActionResult Index()
        {
            TempData["success_msg"] = "error";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        /*login
        
        Claim a1 = new Claim("id", _user.Id.ToString());
        Claim a2 = new Claim("name", _user.username);
        Claim a3 = new Claim(ClaimTypes.Role, "admin");
        ClaimsIdentity claimsIdentity = new ClaimsIdentity("userAuth");
        claimsIdentity.AddClaim(a1);
        claimsIdentity.AddClaim(a2);
        claimsIdentity.AddClaim(a3);
        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        HttpContext.SignInAsync(claimsPrincipal);

         */

    }
}