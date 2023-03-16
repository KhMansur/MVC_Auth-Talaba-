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
            return View();
        }

        public IActionResult CheckUser(LoginDto dto)
        {
            if (authManager.ValidateUser(dto).Result)
            {
                var user = authManager.GetUserWithToken(dto.Username).Result;
                string code = "Create New";
                return RedirectToAction("List", "Talaba", new { token = user.Token, code = code });
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
            await authManager.AddUser(dto);
            return RedirectToAction("Login");
        }
    }
}
