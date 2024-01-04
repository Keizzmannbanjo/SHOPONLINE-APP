using Shoponline.api.Models;
using Shoponline.Dtos.Dtos;

namespace Shoponline.api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products, IEnumerable<ProductCategory> productCategories)
        {
            return (from product in products
                    join productCategory in productCategories on product.ProductCategoryId equals productCategory.Id
                    select new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ImageUrl = product.ImageUrl,
                        Price = product.Price,
                        Qty = product.Qty,
                        CategoryId = productCategory.Id,
                        CategoryName = productCategory.Name
                    }).ToList();
        }

        public static ProductDto ConvertToDto(this Product product, ProductCategory productCategory)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = productCategory.Id,
                CategoryName = productCategory.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Qty = product.Qty
            };
        }

        public static IEnumerable<CartItemDto> ConvertToDto(this IEnumerable<CartItem> cartItems, IEnumerable<Product> products)
        {
            return (from cartItem in cartItems join product in products on cartItem.ProductId equals product.Id select new CartItemDto { ProductId = cartItem.ProductId, CartItemId = cartItem.Id, ProductDescription = product.Description, ProductImageUrl = product.ImageUrl, ProductName = product.Name, ProductPrice = product.Price, TotalPrice = product.Price * cartItem.Qty, Qty = cartItem.Qty }).ToList();
        }

        public static CartItemDto ConvertToDto(this CartItem cartItem, Product product)
        {
            return new CartItemDto
            {
                ProductId = cartItem.ProductId,
                CartItemId = cartItem.Id,
                ProductDescription = product.Description,
                ProductImageUrl = product.ImageUrl,
                ProductName = product.Name,
                ProductPrice = product.Price,
                TotalPrice = product.Price * cartItem.Qty,
                Qty = cartItem.Qty
            };
        }
    }
}
