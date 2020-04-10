using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Tasky2.Models;
using Tasky2.Repository;

namespace Tasky2.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUserRepository _userRepository;
        public RegistrationController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("Register");

            var userId = await _userRepository.Create(viewModel);

            if (userId > 0)
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, viewModel.FirstName));
                identity.AddClaim(new Claim(ClaimTypes.Email, viewModel.Email));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true });

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Email Address already exist in our system.");
            return View("Register");
        }

       
    }
}