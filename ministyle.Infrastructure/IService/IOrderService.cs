using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministyle.Infrastructure.IService
{
    public interface IOrderService
    {
        Task<Domain.Order> GetAll(Domain.Order mOrder);
        Task<Domain.Order> Get(int id);
        Task<Domain.Order> Post(Domain.Order mOrder);
    }
}
