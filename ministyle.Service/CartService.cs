using Microsoft.Extensions.Options;
using ministyle.Infrastructure;
using ministyle.Infrastructure.IService;

namespace ministyle.Service
{
    public class CartService : ICartService
    {
        private readonly Domain.AppSettings _settings;
        private readonly IHttpClientService _httpClientService;

        public CartService(IOptions<Domain.AppSettings> settings, IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
            _settings = settings.Value;
        }

        public async Task<List<Domain.Cart>> GetAllCartItems(string sessionId)
        {
            return await _httpClientService.GetAsync<List<Domain.Cart>>($"{_settings.BaseUrl}/Cart/SessionId/{sessionId}").ConfigureAwait(false);
        }

        public async Task<Domain.Cart> AddToCart(Domain.Cart mCart)
        {
            return await _httpClientService.PostAsync<Domain.Cart>($"{_settings.BaseUrl}/Cart/", mCart).ConfigureAwait(false);
        }

        public async Task<Domain.CartSummary> CartSummary(string sessionId)
        {
            return await _httpClientService.GetAsync<Domain.CartSummary>($"{_settings.BaseUrl}/Cart/Summary/SessionId/{sessionId}").ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
             await _httpClientService.DeleteAsync($"{_settings.BaseUrl}/Cart/{id}").ConfigureAwait(false);
        }

        public async Task UpdateQty(int id, int qty)
        {
            await _httpClientService.PatchAsync($"{_settings.BaseUrl}/Cart/UpdateQty/{id}/Qty/{qty}").ConfigureAwait(false);
        }

    }
}
