using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministyle.Infrastructure.IService
{
    public interface IDropdownService
    {
        Task<dynamic> GetAllActiveSubCategoriesByAsync(int categoryId);
    }
}
