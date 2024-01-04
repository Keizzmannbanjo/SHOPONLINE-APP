using Microsoft.EntityFrameworkCore;
using Shoponline.api.Models;

namespace Shoponline.api.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            IEnumerable<Product> products = new List<Product>
            {
                new Product { Id=1, Name="Super Mario Masthead", Description="This masthead of your favourite super plumber bros rock", ImageUrl="/Images/Frames/Supermario.png", Price=250000, ProductCategoryId=1, Qty=50}, new Product { Id=2, Name="Super Mario Rainbow Race", Description="This masthead of your favourite super plumber bros riding on all amazing rainbow arc running for their dear lives", ImageUrl="/Images/Frames/Supermario on the rainbow.png", Price=200000, ProductCategoryId=1, Qty=50}, new Product { Id=3, Name="Cooked Noodles with Eggs and Supplements", Description="This well cooked noodles seems to be calling your name", ImageUrl="/Images/Food/Noodles.jpg", Price=5000, ProductCategoryId=2, Qty=30}, new Product { Id=4, Name="Ofada Rice and Stew", Description="Welcome to the bliss of local food, Ofada rice has got you. Nuff said", ImageUrl="/Images/Food/Ofada rice.jpg", Price=7000, ProductCategoryId=2, Qty=50}
            };
            IEnumerable<ProductCategory> categories = new List<ProductCategory> { new ProductCategory { Id = 1, Name = "Frames" }, new ProductCategory { Id = 2, Name = "Food" } };
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<ProductCategory>().HasData(categories);
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
