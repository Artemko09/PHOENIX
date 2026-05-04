using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PHOENIX.Models; // Твій простір імен

[Authorize(Roles = "Admin")] // Доступ лише для тебе
public class AdminController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AdminController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    // Сторінка зі списком усіх спортсменів
    public async Task<IActionResult> Users()
    {
        var currentUser = await _userManager.GetUserAsync(User);

        var athletes = _userManager.Users
            .Where(u => u.Id != currentUser.Id) 
            .OrderBy(u => u.Name)               
            .ToList();

        return View(athletes);
    }

    // Метод для зміни поясу
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateRank(string userId, Rank newRank)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            user.SportsRank = newRank;
            await _userManager.UpdateAsync(user);
        }
        return RedirectToAction(nameof(Users));
    }
}