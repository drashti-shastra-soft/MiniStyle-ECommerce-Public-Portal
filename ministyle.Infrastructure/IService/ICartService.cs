namespace ministyle.Infrastructure.IService
{
    public interface ICartService
    {
        Task<Domain.Cart> AddToCart(Domain.Cart mCart);

        Task<List<Domain.Cart>> GetAllCartItems(string sessionId);

        Task<Domain.CartSummary> CartSummary(string sessionId);

        Task Delete(int id);
        
        Task UpdateQty(int id, int qty);
    }
}
