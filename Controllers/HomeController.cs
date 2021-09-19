using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspnetCoreSecurity1 {
    public class HomeController : Controller {
        public IActionResult Index () {
            return View ();
        }
        public IActionResult About () {
            return View ();
        }
        public IActionResult Contact () {
            return View ();
        }
        public IActionResult Error () {
            return View ();
        }

        [Authorize]
        public IActionResult Secret () {
            return View ();
        }

        public IActionResult Authenticate () {

            var grandmaClaims = new List<Claim> () {
                new Claim (ClaimTypes.Name, "Volkan"),
                new Claim (ClaimTypes.Email, "volkan@gmail.com"),
                new Claim ("Granma.Says", "Very nice boi.")
            };

            var licenseClaims = new List<Claim> () {
                new Claim (ClaimTypes.Name, "Bob K Foo"),
                new Claim ("DrivingLicense", "A+") 
            };

            var grandmaIdentity = new ClaimsIdentity (grandmaClaims, "Grandma Identity");
            var licenceIdentity = new ClaimsIdentity(licenseClaims,"Goverment");

            var userPrincipal = new ClaimsPrincipal (new [] { grandmaIdentity,licenceIdentity });
              // HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction ("Index");

        }

    }
}