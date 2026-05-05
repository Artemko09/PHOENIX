using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PHOENIX.Data;
using PHOENIX.Models;
using Microsoft.EntityFrameworkCore;

namespace PHOENIX.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public NewsController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var news = await _db.News.OrderByDescending(n => n.CreatedAt).ToListAsync();
            return View(news);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create() => View();

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(News news)
        {
            if (ModelState.IsValid)
            {
                news.AuthorId = int.Parse(_userManager.GetUserId(User));
                _db.News.Add(news);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var news = await _db.News.FindAsync(id);
            if (news == null) return NotFound();

            return View(news);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, News news)
        {
            if (id != news.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(news);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_db.News.Any(e => e.Id == news.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var news = await _db.News.FindAsync(id);
            if (news != null)
            {
                _db.News.Remove(news);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
