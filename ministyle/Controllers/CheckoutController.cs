using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ministyle.Domain;
using ministyle.Infrastructure.IService;
using Razorpay.Api;
using System.Dynamic;
using static ministyle.Infrastructure.Enums;

namespace ministyle.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        private readonly Domain.AppSettings _settings;
        public CheckoutController(IOrderService orderService, ICartService cartService, IOptions<Domain.AppSettings> settings)
        {
            _orderService = orderService;
            _cartService = cartService;
            _settings = settings.Value;
        }

        public IActionResult Index()
        {
            return View(new Domain.CartViewModel());
        }

        [HttpGet]
        public IActionResult List()
        {
            var mOrder = new List<Domain.Cart>();
            try
            {
                mOrder = _cartService.GetAllCartItems(Request.Cookies["CartSession"]).GetAwaiter().GetResult();
            }
            catch
            {
                throw;
            }
            return View("_List", mOrder);
        }

        [HttpGet]
        public IActionResult GetCartSummary()
        {
            var mOrder = new Domain.CartSummary();
            try
            {
                mOrder = _cartService.CartSummary(Request.Cookies["CartSession"]).GetAwaiter().GetResult();
            }
            catch
            {
                throw;
            }
            return View("_Summary", mOrder);
        }

        [HttpPost]
        public IActionResult SaveDetails([FromBody] Domain.Order mOrder)
        {
            dynamic resultDate = new ExpandoObject();
            try
            {
                mOrder = _orderService.Post(mOrder).GetAwaiter().GetResult();
                if (mOrder != null && mOrder.Id > 0)
                {
                    resultDate = new { NotificationType = "success", NotificationMsg = "Congratulation, Your order has been placed, please wait until shipping teams connect with you!" };
                }
            }
            catch (Exception)
            {
                resultDate = new { NotificationType = "error", NotificationMsg = "An error occured while saving!" };
            }
            return Json(mOrder);
        }


        public ActionResult CreateOrder(string mAddress, string mFullName, string mMobile, string mLine1, string mLine2, string LandMark, string zipCode, string city, string state,string shippingStatus, string paymentStatus)
        {
            var mOrder = new Domain.CartSummary();
            try
            {
                Random randomObj = new Random();
                string transactionId = randomObj.Next(10000000, 100000000).ToString();

                mOrder = _cartService.CartSummary(Request.Cookies["CartSession"]).GetAwaiter().GetResult();


                Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient(_settings.RazorKey, _settings.RazorSecret);
                Dictionary<string, object> options = new Dictionary<string, object>();
                options.Add("amount", mOrder.Total * 100);
                options.Add("receipt", transactionId);
                options.Add("currency", "INR");
                options.Add("payment_capture", "0"); // 1 - automatic   , 2 - manual
                                                     //options.Add("notes", "-- You can put any notes here --");

                Razorpay.Api.Order orderResponse = client.Order.Create(options);
                string orderId = orderResponse["id"].ToString();

                // Create order model for return on view
                Domain.Order order = new Domain.Order
                {
                    OrderId = orderResponse.Attributes["id"],
                    razorpayKey = _settings.RazorKey,
                    TotalAmount = (int)(mOrder.Total * 100),
                    FullName = mFullName,
                    MobileNumber = mMobile,
                    Line1 = mLine1,
                    Line2 = mLine2,
                    Landmark = LandMark,
                    ZipCode = zipCode,
                    City = city,
                    State = state,
                    Address = mAddress,
                    //image = "https://ministyle.in/images/ministyle.png"
                };

                return PartialView("PaymentPage", order);
            }
            catch
            {
                throw;
            }

        }
        [HttpPost]
        public IActionResult CompletePayment()
        {
            // This is orderId
            string paymentId = Convert.ToString(Request.Form["razorpay_payment_id"]);
            string orderId = Convert.ToString(Request.Form["razorpay_order_id"]);
            decimal Amount = Convert.ToDecimal(Request.Form["rzp_amount"]) / 100;
            string Name = Convert.ToString(Request.Form["rzp_FullName"]);
            string Mobile = Convert.ToString(Request.Form["rzp_MobileNumber"]);
            string Address = Convert.ToString(Request.Form["rzp_Address"]);
            string Line1 = Convert.ToString(Request.Form["rzp_Line1"]);
            string Line2 = Convert.ToString(Request.Form["rzp_Line2"]);
            string LandMark = Convert.ToString(Request.Form["rzp_Landmark"]);
            string ZipCode = Convert.ToString(Request.Form["rzp_ZipCode"]);
            string City = Convert.ToString(Request.Form["rzp_City"]);
            string State = Convert.ToString(Request.Form["rzp_State"]);

            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient(_settings.RazorKey, _settings.RazorSecret);
            Razorpay.Api.Payment payment = client.Payment.Fetch(paymentId);

            // This code is for capture the payment 
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", payment.Attributes["amount"]);
            Razorpay.Api.Payment paymentCaptured = payment.Capture(options);

            var roots = payment.Attributes;

            if (paymentCaptured.Attributes["status"] == "captured")
            {
                //Call Create Order API
                Domain.Order mOrder = new Domain.Order();
                mOrder.FullName = Name;
                mOrder.MobileNumber = Mobile;
                mOrder.Line1 = Line1;
                mOrder.Line2 = Line2;
                mOrder.ZipCode = ZipCode;
                mOrder.Landmark = LandMark;
                mOrder.City = City;
                mOrder.State = State;
                mOrder.RazorpayOrderId = orderId;
                mOrder.RazorpayPaymentId = paymentId;
                mOrder.TotalAmount = Amount;
                mOrder.PaymentStatus = PaymentStatus.Completed.ToString();
                mOrder.ShippingStatus = Convert.ToString(ShippingStatus.Not_Shipped).Replace("_"," ");
                mOrder.SessionId = Request.Cookies["CartSession"];

                _orderService.Post(mOrder).GetAwaiter().GetResult();

                return RedirectToAction("Success");
            }
            else
            {
                return RedirectToAction("Failed");
            }
        }

        public IActionResult Success()
        {
            return PartialView();
        }
        public IActionResult Failure()
        {
            return PartialView();
        }
    }
}
