using Microsoft.AspNetCore.Mvc;

namespace ministyle.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
