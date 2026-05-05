using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PHOENIX.Data;
using PHOENIX.Models;
using PHOENIX.ViewModel;
using PHOENIX.ViewModels;

namespace PHOENIX.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Categories = _db.Categories.ToList(); 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                    BirthDate = model.BirthDate,
                    Gender = model.Gender,
                    CategoryId = model.CategoryId 
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors) ModelState.AddModelError("", error.Description);
            }
            ViewBag.Categories = await _db.Categories.ToListAsync();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);

                    if (user != null)
                    {
                        if (user.Email == "fedotov.dmytro@gmail.com")
                        {
                            if (!await _userManager.IsInRoleAsync(user, "Admin"))
                            {
                                await _userManager.AddToRoleAsync(user, "Admin");
                            }
                        }
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Невірний логін або пароль");
            }

            return View(model);
        }

        [Authorize] 
        public async Task<IActionResult> Profile()
        {
            var userId = _userManager.GetUserId(User);

            var user = await _db.Users
                .Include(u => u.Category)
                .Include(u => u.Achievements)
                .FirstOrDefaultAsync(u => u.Id == int.Parse(userId));

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound();

            var model = new EditProfileViewModel
            {
                Name = user.Name,
                Weight = user.Weight,
                Gender = user.Gender,
                CategoryId = user.CategoryId
            };

            ViewBag.Categories = await _db.Categories.ToListAsync();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound();

            if (ModelState.IsValid)
            {
                user.Name = model.Name;
                user.Weight = model.Weight;
                user.Gender = model.Gender;
                user.CategoryId = model.CategoryId;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Profile");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            ViewBag.Categories = await _db.Categories.ToListAsync();
            return View(model);
        }
    }
}
