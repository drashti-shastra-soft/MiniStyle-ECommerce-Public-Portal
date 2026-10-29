using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministyle.Infrastructure.IService
{
    public interface IProductDetailService
    {
        Task<List<Domain.ProductImage>> GetProductImages(int productId, int productColorId);
    }
}
