using Microsoft.Extensions.Options;
using ministyle.Infrastructure;
using ministyle.Infrastructure.IService;

namespace ministyle.Service
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly Domain.AppSettings _settings;
        private readonly IHttpClientService _httpClientService;

        public ProductDetailService(IOptions<Domain.AppSettings> settings, IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
            _settings = settings.Value;
        }

        public async Task<List<Domain.SubCategory>> GetActiveSubCategoriesByCategoryAsync(int categoryId)
        {
            string requestUrl = $"{_settings.BaseUrl}/SubCategory/GetAllActiveSubCategoriesBy/CategoryId/{categoryId}";

            var mSubCategories = await _httpClientService
                .GetAsync<List<Domain.SubCategory>>(requestUrl)
                .ConfigureAwait(false);

            return mSubCategories;
        }

        public async Task<List<Domain.ProductImage>> GetProductImages(int productId, int productColorId)
        {
            var result = await _httpClientService
                .GetAsync<List<Domain.ProductImage>>($"{_settings.BaseUrl}/ProductImage/ProductId/{productId}/ProductColorId/{productColorId}")
                .ConfigureAwait(false);
            return result;
        }
        
    }
}
