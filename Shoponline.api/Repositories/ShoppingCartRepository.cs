using Microsoft.EntityFrameworkCore;
using Shoponline.api.Data;
using Shoponline.api.Models;
using Shoponline.api.Repositories.Contracts;
using Shoponline.Dtos.Dtos;

namespace Shoponline.api.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApiDbContext db;

        public ShoppingCartRepository(ApiDbContext db)
        {
            this.db = db;
        }
        public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            if (await CartItemExists(cartItemToAddDto.CartId, cartItemToAddDto.ProductId) == false)
            {
                var item = await (from product in db.Products where product.Id == cartItemToAddDto.ProductId select new CartItem { CartId = cartItemToAddDto.CartId, ProductId = product.Id, Qty = cartItemToAddDto.Qty }).SingleOrDefaultAsync();
                if (item != null)
                {
                    var result = await db.CartItems.AddAsync(item);
                    await db.SaveChangesAsync();
                    return result.Entity;
                }
            }
            return null;
        }

        public Task<CartItem> DeleteItem(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<CartItem> GetItem(int Id)
        {
            return await (from cart in db.Carts join cartItem in db.CartItems on cart.Id equals cartItem.CartId where cartItem.Id == Id select new CartItem { Id = cartItem.Id, CartId = cartItem.CartId, ProductId = cartItem.ProductId, Qty = cartItem.Qty }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>> GetItems(int userId)
        {
            return await (from cart in db.Carts join cartItem in db.CartItems on cart.Id equals cartItem.CartId where cart.UserId == userId select new CartItem { Id = cartItem.Id, ProductId = cartItem.ProductId, Qty = cartItem.Qty, CartId = cartItem.CartId }).ToListAsync();
        }

        public Task<CartItem> UpdateQty(int Id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> CartItemExists(int cartId, int productId)
        {
            return await db.CartItems.AnyAsync(c => c.CartId == cartId && c.ProductId == productId);
        }
    }
}
