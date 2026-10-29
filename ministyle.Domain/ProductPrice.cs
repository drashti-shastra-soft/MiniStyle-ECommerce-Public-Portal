using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministyle.Domain
{
    public class ProductPrice
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public int? DiscountPercentage { get; set; }
        public string SellPriceFormatted => string.Format(new CultureInfo("en-IN"), "{0:C2}", SellPrice);
        public string DiscountedPriceFormatted => string.Format(new CultureInfo("en-IN"), "{0:C2}", DiscountedPrice);
    }
}
