using Core.Entities;

namespace Core.Interfaces
{
	public interface IBasketRepository
	{
		Task<CustomerBasket> GetBasketAsync(string basketId);

        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket custometBasket);

        Task<bool> DeleteBasketAsync(string basketId);
    }
}

