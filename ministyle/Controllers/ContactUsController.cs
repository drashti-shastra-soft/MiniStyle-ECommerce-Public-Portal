using Microsoft.AspNetCore.Mvc;

namespace ministyle.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
