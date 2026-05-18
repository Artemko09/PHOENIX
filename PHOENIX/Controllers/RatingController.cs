using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PHOENIX.Data;
using PHOENIX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PHOENIX.Controllers
{
    [Authorize]
    public class RatingController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RatingController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string targetGroup, string activeTab = "general")
        {
            var currentUser = await _userManager.GetUserAsync(User);
            ViewBag.CurrentUserId = currentUser?.Id;
            ViewBag.ActiveTab = activeTab;

            var ageGroups = new List<string>
            {
                "Дівчата 06-09 років",
                "Дівчата 10-13 років",
                "Дівчата 14-17 років",
                "Жінки 18+ років",
                "Хлопці 06-09 років",
                "Хлопці 10-13 років",
                "Хлопці 14-17 років",
                "Чоловіки 18+ років"
            };
            ViewBag.AgeGroups = ageGroups;

            var allUsers = await _userManager.Users
                .Include(u => u.Achievements)
                .Include(u => u.Category)
                .ToListAsync();

            var generalRating = allUsers
                .OrderByDescending(u => u.Achievements?.Sum(a => a.PointsEarned) ?? 0)
                .ThenBy(u => u.Name)
                .ToList();
            ViewBag.GeneralRating = generalRating;

            string GetUserAgeGroup(ApplicationUser user)
            {
                if (user.BirthDate == default || user.BirthDate.Year >= 2026)
                {
                    return user.Gender == Gender.Female ? "Жінки 18+ років" : "Чоловіки 18+ років";
                }

                DateTime today = DateTime.Today; 
                int age = today.Year - user.BirthDate.Year;

                if (user.BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }

                if (user.Gender == Gender.Female)
                {
                    if (age >= 6 && age <= 9) return "Дівчата 06-09 років";
                    if (age >= 10 && age <= 13) return "Дівчата 10-13 років";
                    if (age >= 14 && age <= 17) return "Дівчата 14-17 років";
                    return "Жінки 18+ років";
                }
                else
                {
                    if (age >= 6 && age <= 9) return "Хлопці 06-09 років";
                    if (age >= 10 && age <= 13) return "Хлопці 10-13 років";
                    if (age >= 14 && age <= 17) return "Хлопці 14-17 років";
                    return "Чоловіки 18+ років";
                }
            }

            if (string.IsNullOrEmpty(targetGroup))
            {
                targetGroup = GetUserAgeGroup(currentUser);
                if (!ageGroups.Contains(targetGroup)) targetGroup = ageGroups.First();
            }

            ViewBag.TargetGroup = targetGroup;

            var categoryRating = allUsers
                .Where(u => GetUserAgeGroup(u) == targetGroup)
                .OrderByDescending(u => u.Achievements?.Sum(a => a.PointsEarned) ?? 0)
                .ThenBy(u => u.Name)
                .ToList();

            ViewBag.CategoryRating = categoryRating;

            return View();
        }
    }
}