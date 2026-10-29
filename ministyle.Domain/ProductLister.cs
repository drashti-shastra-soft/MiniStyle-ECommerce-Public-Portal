using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministyle.Domain
{
    public class ProductLister
    {
        public List<Domain.Product> List { get; set; } = new List<Domain.Product>();

        public Domain.Product SearchCriteria { get; set; } = new Domain.Product();
    }
}
