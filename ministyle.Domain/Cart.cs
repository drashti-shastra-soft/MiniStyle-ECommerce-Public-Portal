using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministyle.Domain
{
    public class Cart
    {
        public int Id { get; set; }
        public string SessionId { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public string ImageBase64String { get; set; } = string.Empty;
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountedPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string UnitPriceFormatted => string.Format(new CultureInfo("en-IN"), "{0:C2}", UnitPrice);
        public string DiscountedPriceFormatted => string.Format(new CultureInfo("en-IN"), "{0:C2}", DiscountedPrice);
    }
}
