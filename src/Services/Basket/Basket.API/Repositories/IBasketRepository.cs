using Basket.API.Entities;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<Cart> GetBasketAsync(string userName);
        Task<Cart> UpdateBasketAsync(Cart cart);
        Task DeleteBasketAsync(string userName);
    }
}
