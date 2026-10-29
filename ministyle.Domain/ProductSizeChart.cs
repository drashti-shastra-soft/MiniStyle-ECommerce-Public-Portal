using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministyle.Domain
{
    public class ProductSizeChart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AgeGroupId { get; set; }
        public string AgeGroup { get; set; } = string.Empty;
        public int UnitTypeId { get; set; }
        public string UnitType { get; set; } = string.Empty;
        public string Shoulder { get; set; } = string.Empty;
        public string TopLength { get; set; } = string.Empty;
        public string Chest { get; set; } = string.Empty;
        public string BottomLength { get; set; } = string.Empty;
        public string Waist { get; set; } = string.Empty;
    }
}
