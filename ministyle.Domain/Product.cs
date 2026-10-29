using System.Globalization;

namespace ministyle.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ShortInfo { get; set; } = string.Empty;
        public int SubCategoryId { get; set; }
        public int ProductColorId { get; set; }
        public int? MicroCategoryId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int? LastModifiedBy { get; set; }
        public string SubCategory { get; set; } = string.Empty;
        public string MicroCategory { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string ImageBase64String { get; set; } = string.Empty;
        public string ImageFileName { get; set; } = string.Empty;
        public decimal SellPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string SellPriceFormatted => string.Format(new CultureInfo("en-IN"), "{0:C2}", SellPrice);
        public string DiscountedPriceFormatted => string.Format(new CultureInfo("en-IN"), "{0:C2}", DiscountedPrice);
    }
}
