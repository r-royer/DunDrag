using Microsoft.AspNetCore.Mvc;

namespace DunDrag.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}