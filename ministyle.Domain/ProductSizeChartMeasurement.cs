using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministyle.Domain
{
    public class ProductSizeChartMeasurement
    {
        public int Id { get; set; }
        public int ProductSizeChartRowId { get; set; }
        public string MeasurementType { get; set; } = string.Empty; 
        public decimal Value { get; set; }
    }
}
