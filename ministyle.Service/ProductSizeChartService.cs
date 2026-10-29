using Microsoft.Extensions.Options;
using ministyle.Infrastructure;
using ministyle.Infrastructure.IService;


namespace ministyle.Service
{
    public class ProductSizeChartService : IProductSizeChartService
    {
        private readonly Domain.AppSettings _settings;
        private readonly IHttpClientService _httpClientService;

        public ProductSizeChartService(IOptions<Domain.AppSettings> settings, IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
            _settings = settings.Value;
        }

        public async Task<List<Domain.ProductSizeChart>> GetSizeChart(int productId ,string unitType)
        {
            return await _httpClientService.GetAsync<List<Domain.ProductSizeChart>>($"{_settings.BaseUrl}/ProductSizeChart/ProductId/{productId}/UnitType/{unitType}").ConfigureAwait(false);
        }

    }
}
