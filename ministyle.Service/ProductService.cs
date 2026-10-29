using Microsoft.Extensions.Options;
using ministyle.Infrastructure;
using ministyle.Infrastructure.IService;

namespace ministyle.Service
{
    public class ProductService : IProductService
    {
        private readonly Domain.AppSettings _settings;
        private readonly IHttpClientService _httpClientService;

        public ProductService(IOptions<Domain.AppSettings> settings, IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
            _settings = settings.Value;
        }

        public async Task<Domain.ProductLister> GetAllActiveProducts(Domain.ProductLister mLister)
        {
            return await _httpClientService.PostAsync<Domain.ProductLister>($"{_settings.BaseUrl}/Product/GetAllActiveProducts", mLister).ConfigureAwait(false);
        }

        public async Task<Domain.ProductViewModel> GetProductDetail(int id)
        {
            return await _httpClientService.GetAsync<Domain.ProductViewModel>($"{_settings.BaseUrl}/Product/GetProductDetails/{id}").ConfigureAwait(false);
        }
    }
}
