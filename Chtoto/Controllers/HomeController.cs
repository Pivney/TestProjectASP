using Microsoft.AspNetCore.Mvc;

namespace Chtoto.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
