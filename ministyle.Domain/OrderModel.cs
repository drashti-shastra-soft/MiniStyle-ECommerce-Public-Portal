using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministyle.Domain
{
    public class OrderModel
    {
        public string orderId { get; set; } = string.Empty;
        public string razorpayKey { get; set; } = string.Empty;
        public int amount { get; set; }
        public string currency { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Line1 { get; set; } = string.Empty;
        public string Line2 { get; set; } = string.Empty;
        public string LandMark { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string image { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
