using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PHOENIX.Data;
using PHOENIX.Interface;
using PHOENIX.Models;
using System.Diagnostics;

namespace PHOENIX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISportsmanValidation _sportsmanValidation;

        public HomeController(ApplicationDbContext context, ISportsmanValidation sportsmanValidation) 
        {
            _context = context;
            _sportsmanValidation = sportsmanValidation;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
