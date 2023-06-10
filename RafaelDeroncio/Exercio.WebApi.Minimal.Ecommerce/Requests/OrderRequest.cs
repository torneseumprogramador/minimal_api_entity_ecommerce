using Exercio.WebApi.Minimal.Ecommerce.Configurations.DTOs;

namespace Exercio.WebApi.Minimal.Ecommerce.Requests;

public class OrderRequest
{
    public int CustomerId { get; set; }
    public IEnumerable<ProductDTO> Products { get; set; }
}