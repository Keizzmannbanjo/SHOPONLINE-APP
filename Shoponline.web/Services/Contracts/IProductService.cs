using Shoponline.Dtos.Dtos;

namespace Shoponline.web.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetItems();
        Task<ProductDto> GetItem(int Id);
    }
}
