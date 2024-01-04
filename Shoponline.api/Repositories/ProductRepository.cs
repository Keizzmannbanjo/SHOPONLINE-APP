using Microsoft.EntityFrameworkCore;
using Shoponline.api.Data;
using Shoponline.api.Models;
using Shoponline.api.Repositories.Contracts;

namespace Shoponline.api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiDbContext db;

        public ProductRepository(ApiDbContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await db.ProductCategories.ToListAsync();
            return categories;
        }

        public async Task<ProductCategory> GetCategory(int Id)
        {
            var category = await db.ProductCategories.SingleOrDefaultAsync(c => c.Id == Id);
            return category;
        }

        public async Task<Product> GetItem(int Id)
        {
            var product = await db.Products.FindAsync(Id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await db.Products.ToListAsync();
            return products;
        }
    }
}
