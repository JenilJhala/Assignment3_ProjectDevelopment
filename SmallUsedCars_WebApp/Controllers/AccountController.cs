using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmallUsedCars_WebApp.Entities;
using SmallUsedCars_WebApp.Models;

namespace SmallUsedCars_WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;

        public AccountController(UserManager<Employee> userManager, SignInManager<Employee> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Employee
                {
                    UserName = model.Email,  // IdentityUser uses Email as UserName
                    Email = model.Email,
                    EmployeeName = model.FullName  // Custom Full Name Field
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Registration successful. You can now log in.";
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        public IActionResult Login()
        {
            ViewBag.Message = TempData["SuccessMessage"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    TempData["ErrorMessage"] = "No account found. Please register first.";
                    return RedirectToAction("Login");
                }

                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid login attempt.";
                    return RedirectToAction("Login");
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["SuccessMessage"] = "You have been logged out successfully.";
            return RedirectToAction("Login");
        }
    }
}
