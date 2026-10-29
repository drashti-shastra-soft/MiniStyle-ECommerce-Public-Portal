using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministyle.Domain
{
    public class ProductDetail
    {
        public int ProductDetailId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Specification { get; set; } = string.Empty;
        public int FabricId { get; set; }
        public string Fabric { get; set; } = string.Empty;
    }
}
