using Microsoft.AspNetCore.Mvc;

namespace ProjectTai.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
