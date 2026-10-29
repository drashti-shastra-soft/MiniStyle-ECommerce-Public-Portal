using Microsoft.AspNetCore.Mvc;
using ministyle.Infrastructure;
using ministyle.Infrastructure.IService;

namespace ministyle.Controllers
{
    public class BoysController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly IProductService _productservice;

        public BoysController(ISubCategoryService subCategoryService, IProductService productservice)
        {
            _subCategoryService = subCategoryService;
            _productservice = productservice;
        }

        public IActionResult Index()
        {
            return View(new Domain.ProductLister());
        }

        public IActionResult List(Domain.ProductLister mLister)
        {
            try
            {
                if (mLister.SearchCriteria.CategoryId <= 0)
                    mLister.SearchCriteria.CategoryId = EnumHelper.GetEnumIndex(Enums.Category.Boys);

                mLister = _productservice.GetAllActiveProducts(mLister).GetAwaiter().GetResult();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ViewBag.SubCategories = _subCategoryService.GetActiveSubCategoriesByCategoryAsync((int)EnumHelper.GetEnumIndex(Enums.Category.Boys)).GetAwaiter().GetResult();
            }
            return View("_List", mLister);
        }
    }
}
