using Microsoft.AspNetCore.Mvc;
using Shoponline.api.Extensions;
using Shoponline.api.Repositories.Contracts;
using Shoponline.Dtos.Dtos;

namespace Shoponline.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await productRepository.GetItems();
                var categories = await productRepository.GetCategories();
                if (products == null || categories == null)
                {
                    return NotFound();
                }
                else
                {
                    var productsDto = products.ConvertToDto(categories);
                    return Ok(productsDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<ProductDto>> GetItem(int Id)
        {
            try
            {
                var product = await productRepository.GetItem(Id);
                if (product == null)
                {
                    return BadRequest();
                }
                else
                {
                    var productCategory = await productRepository.GetCategory(product.ProductCategoryId);
                    var productDto = product.ConvertToDto(productCategory);
                    return Ok(productDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
