using Microsoft.AspNetCore.Mvc;
using TalabaMVC.Models;
using TalabaMVC.Services;

namespace TalabaMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthManager authManager;

        public AccountController(IAuthManager authManager)
        {
            this.authManager = authManager;
        }

        public IActionResult Login()
        {
            TempData["token"] = null;
            return View();
        }

        public IActionResult CheckUser(LoginDto dto)
        {
            if (authManager.ValidateUser(dto).GetAwaiter().GetResult())
            {
                var user = authManager.GetUserWithToken(dto.Username).Result;
                TempData["token"] = user.Token;
                return RedirectToAction("List", "Talaba");
            }
            return RedirectToAction("Login");
        }

        public IActionResult ReturnRegister()
        {
            return RedirectToAction("Registration");
        }

        public IActionResult Registration()
        {
            return View();
        }

        public async Task<IActionResult> RegisterUser(RegisterUserDto dto)
        {
            await authManager.AddUser(dto, "User");
            return RedirectToAction("Login");
        }
    }
}
