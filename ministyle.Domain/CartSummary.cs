namespace ministyle.Domain
{
    public class CartSummary
    {
        public decimal TotalPrice { get; set; }
        public decimal Discounted { get; set; }
        public decimal ShippingFee { get; set; }
        public decimal Total { get; set; }
        public string TotalPriceFormatted { get; set; } = string.Empty;
        public string DiscountedFormatted { get; set; } = string.Empty;
        public string ShippingFeeFormatted { get; set; } = string.Empty;
        public string TotalFormatted { get; set; } = string.Empty;
    }
}
