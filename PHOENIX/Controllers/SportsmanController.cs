using Microsoft.AspNetCore.Mvc;

namespace PHOENIX.Controllers
{
    public class SportsmanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
