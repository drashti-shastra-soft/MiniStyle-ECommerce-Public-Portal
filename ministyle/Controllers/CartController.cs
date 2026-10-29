using Microsoft.AspNetCore.Mvc;
using ministyle.Infrastructure.IService;

namespace ministyle.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            return View(new Domain.CartViewModel());
        }


        public IActionResult List()
        {
            var mCartItems = new List<Domain.Cart>();
            try
            {
                mCartItems = _cartService.GetAllCartItems(Request.Cookies["CartSession"]).GetAwaiter().GetResult();
            }
            catch
            {
                throw;
            }
            return View("_List", mCartItems);
        }

        [HttpGet]
        public IActionResult GetCartSummary()
        {
            var mCartSummary = new Domain.CartSummary();
            try
            {
                mCartSummary = _cartService.CartSummary(Request.Cookies["CartSession"]).GetAwaiter().GetResult();
            }
            catch
            {
                throw;
            }
            return View("_Summary", mCartSummary);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _cartService.Delete(id).GetAwaiter().GetResult();
                return Json(new { type = "success", msg = "Item deleted successfully." });
            }
            catch (Exception)
            {
                return Json(new { type = "error", msg = "Failed to delete item." });
            }
        }

        [HttpPatch]
        public IActionResult UpdateQty(int id, int qty)
        {
            try
            {
                _cartService.UpdateQty(id, qty).GetAwaiter().GetResult();
                return Json(new { type = "success", msg = "Quantity has been updated." });
            }
            catch (Exception)
            {
                return Json(new { type = "error", msg = "Failed to delete item." });
            }
        }
    }
}
