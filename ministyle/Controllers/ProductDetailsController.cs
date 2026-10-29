using Microsoft.AspNetCore.Mvc;
using ministyle.Infrastructure.IService;
using System.Dynamic;
using System.Text.Json;

namespace ministyle.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductDetailService _productDetailService;
        private readonly ICartService _cart;
        private readonly IProductSizeChartService _sizeChartService;

        public ProductDetailsController(IProductService productService, ICartService cart, IProductDetailService productDetail, IProductSizeChartService sizeChartService)
        {
            _productService = productService;
            _cart = cart;
            _productDetailService = productDetail;
            _sizeChartService = sizeChartService;
        }

        public IActionResult Index(int id)
        {
            var mProductDetail = new Domain.ProductViewModel();
            try
            {
                mProductDetail = _productService.GetProductDetail(id).GetAwaiter().GetResult();

                if (mProductDetail == null)
                    mProductDetail = new Domain.ProductViewModel();

                if (mProductDetail.Product == null)
                    mProductDetail.Product = new Domain.Product();

                if (mProductDetail.ProductPrice == null)
                    mProductDetail.ProductPrice = new Domain.ProductPrice();

                if (mProductDetail.ProductDetail == null)
                    mProductDetail.ProductDetail = new Domain.ProductDetail();

                if (mProductDetail.AgeGroup == null)
                    mProductDetail.AgeGroup = new List<Domain.ProductAgeGroup>();

                if (mProductDetail.ProductImages == null)
                    mProductDetail.ProductImages = new List<Domain.ProductImage>();
            }
            catch
            {
                throw;
            }
            return View(mProductDetail);
        }

        [HttpPost]
        public IActionResult AddToCart([FromBody] Domain.Cart mCart)
        {
            dynamic resultDate = new ExpandoObject();
            try
            {
                mCart.SessionId = Request.Cookies["CartSession"];
                if (string.IsNullOrEmpty(mCart.SessionId) || string.IsNullOrWhiteSpace(mCart.SessionId))
                    mCart.SessionId = CreateSession();

                mCart = _cart.AddToCart(mCart).GetAwaiter().GetResult();
                if (mCart != null && mCart.Id > 0)
                {
                    resultDate = new { NotificationType = "success", NotificationMsg = "Item has been added to cart" };
                }
            }
            catch (Exception)
            {
                resultDate = new { NotificationType = "error", NotificationMsg = "Error Occur While Item added to cart" };
            }
            return Json(resultDate);
        }

        [HttpGet]
        public JsonResult GetProductImages(int productId, int productColorId)
        {
            dynamic jsonResult = new ExpandoObject();
            try
            {
                var mProductImages = _productDetailService.GetProductImages(productId, productColorId).GetAwaiter().GetResult();

                jsonResult = new JsonResult(mProductImages.Select(img => new
                {
                    FileName = img.FileName,
                    MimeType = img.MimeType,
                    Base64String = img.Base64String
                }), new JsonSerializerOptions
                {
                    MaxDepth = 0, // Optional: set to 0 for unlimited depth
                    WriteIndented = false // Optional: compact output
                });
            }
            catch
            {
                throw;
            }
            return Json(jsonResult);
        }

        [HttpGet]
        public IActionResult GetProductChart()
        {
            return PartialView("_SizeChart");
        }

        [HttpGet]
        public IActionResult GetSizeChartRows(int productId, string unitType)
        {
            var mSizeChartRows = new List<Domain.ProductSizeChart>();
            try
            {
                if (string.IsNullOrEmpty(unitType))
                    unitType = "cm";
                
                mSizeChartRows = _sizeChartService.GetSizeChart(productId, unitType).GetAwaiter().GetResult();
            }
            catch
            {
                throw;
            }
            return PartialView("_SizeChartRows", mSizeChartRows);
        }

        private string CreateSession()
        {
            var cartId = Guid.NewGuid().ToString();
            Response.Cookies.Append("CartSession", cartId, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(7),
                HttpOnly = true,
                Secure = true
            });
            return cartId;
        }

    }
}
