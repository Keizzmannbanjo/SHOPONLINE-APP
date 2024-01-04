using Microsoft.AspNetCore.Components;
using Shoponline.Dtos.Dtos;

namespace Shoponline.web.Pages
{
    public class DisplayProductBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
