using Microsoft.Extensions.Options;
using ministyle.Infrastructure;
using ministyle.Infrastructure.IService;

namespace ministyle.Service
{
    public class OrderService : IOrderService
    {

        private readonly Domain.AppSettings _settings;
        private readonly IHttpClientService _httpClientService;

        public OrderService(IOptions<Domain.AppSettings> settings, IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
            _settings = settings.Value;
        }

        public async Task<Domain.Order> GetAll(Domain.Order mOrder)
        {
            return await _httpClientService.PostAsync<Domain.Order>($"{_settings.BaseUrl}/Order/GetAll/",mOrder).ConfigureAwait(false);
        }

        public async Task<Domain.Order> Get(int id)
        {
            return await _httpClientService.GetAsync<Domain.Order>($"{_settings.BaseUrl}/Order/{id}").ConfigureAwait(false);
        }

        public async Task<Domain.Order> Post(Domain.Order mOrder)
        {
            return await _httpClientService.PostAsync<Domain.Order>($"{_settings.BaseUrl}/Order/",mOrder).ConfigureAwait(false);
        }
    }
}
