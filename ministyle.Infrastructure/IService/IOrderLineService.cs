using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministyle.Infrastructure.IService
{
    public interface IOrderLineService
    {
        Task<Domain.OrderLine> Get(int id);
    }
}
