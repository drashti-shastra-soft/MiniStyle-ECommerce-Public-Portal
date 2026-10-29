using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministyle.Domain
{
    public class CartViewModel
    {
        public List<Cart> CartItems { get; set; } = new List<Cart>();
        public CartSummary CartSummary { get; set; } = new CartSummary();
    }
}
