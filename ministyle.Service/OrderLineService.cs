using Microsoft.Extensions.Options;
using ministyle.Infrastructure;
using ministyle.Infrastructure.IService;

namespace ministyle.Service
{
    public class OrderLineService : IOrderLineService
    {
        private readonly Domain.AppSettings _settings;
        private readonly IHttpClientService _httpClientService;

        public OrderLineService(IOptions<Domain.AppSettings> settings, IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
            _settings = settings.Value;
        }

        public async Task<Domain.OrderLine> Get(int id)
        {
            return await _httpClientService.GetAsync<Domain.OrderLine>($"{_settings.BaseUrl}/OrderLine/{id}").ConfigureAwait(false);
        }
    }
}
