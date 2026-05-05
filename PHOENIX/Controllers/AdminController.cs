using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PHOENIX.Data;
using PHOENIX.Models;
using PHOENIX.Services;

namespace PHOENIX.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly ICalculatePointsService _pointsService;

        public AdminController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            ICalculatePointsService pointsService)
        {
            _userManager = userManager;
            _context = context;
            _pointsService = pointsService;
        }

        // 1. ВИПРАВЛЕНО: Додано .Include, щоб бали НЕ були нулями
        public async Task<IActionResult> Users()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var athletes = await _userManager.Users
                .Include(u => u.Achievements) // КРИТИЧНО ВАЖЛИВО ДЛЯ БАЛІВ
                .Where(u => u.Id != currentUser.Id)
                .OrderBy(u => u.Name)
                .ToListAsync(); // Асинхронне завантаження

            return View(athletes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRank(int userId, Rank newRank)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                user.SportsRank = newRank;
                await _userManager.UpdateAsync(user);
            }
            return RedirectToAction(nameof(Users));
        }

        [HttpGet]
        public async Task<IActionResult> AddAchievement(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return NotFound();

            ViewBag.UserName = user.Name;
            return View(new Achievement { UserId = userId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAchievement(Achievement achievement)
        {
            // Розраховуємо бали перед збереженням
            achievement.PointsEarned = _pointsService.Calculate(
                achievement.Status,
                achievement.Place,
                achievement.ParticipantsCount
            );

            // Додаємо в контекст і зберігаємо
            _context.Achievements.Add(achievement);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Users));
        }
    }
}