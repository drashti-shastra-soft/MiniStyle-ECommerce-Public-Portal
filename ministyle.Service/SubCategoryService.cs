using ministyle.Infrastructure.IService;
using Microsoft.Extensions.Options;
using ministyle.Infrastructure;

namespace ministyle.Service
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly Domain.AppSettings _settings;
        private readonly IHttpClientService _httpClientService;

        public SubCategoryService(IOptions<Domain.AppSettings> settings, IHttpClientService httpClientService)
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
    }
}
