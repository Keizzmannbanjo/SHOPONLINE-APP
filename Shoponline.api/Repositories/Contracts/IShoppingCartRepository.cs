using Shoponline.api.Models;
using Shoponline.Dtos.Dtos;

namespace Shoponline.api.Repositories.Contracts
{
    public interface IShoppingCartRepository
    {
        Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto);
        Task<CartItem> UpdateQty(int Id, CartItemQtyUpdateDto cartItemQtyUpdateDto);
        Task<CartItem> DeleteItem(int Id);
        Task<CartItem> GetItem(int Id);
        Task<IEnumerable<CartItem>> GetItems(int userId);
    }
}
