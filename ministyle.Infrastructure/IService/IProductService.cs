using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministyle.Infrastructure.IService
{
    public interface IProductService
    {
        Task<Domain.ProductLister> GetAllActiveProducts(Domain.ProductLister mLister);
        Task<Domain.ProductViewModel> GetProductDetail(int id);
    }
}
