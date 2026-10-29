using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministyle.Infrastructure.IService
{
    public interface IProductSizeChartService
    {
        Task<List<Domain.ProductSizeChart>> GetSizeChart(int productId, string unitType);
    }
}
