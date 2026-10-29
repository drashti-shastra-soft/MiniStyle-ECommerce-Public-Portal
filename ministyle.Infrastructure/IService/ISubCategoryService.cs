using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministyle.Infrastructure.IService
{
    public interface ISubCategoryService
    {
        Task<List<Domain.SubCategory>> GetActiveSubCategoriesByCategoryAsync(int categoryId);
    }
}
