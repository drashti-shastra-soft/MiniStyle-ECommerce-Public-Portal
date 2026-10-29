using Microsoft.AspNetCore.Mvc;

namespace ministyle.Controllers
{
    public class BabyProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
