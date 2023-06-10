using Exercio.WebApi.Minimal.Ecommerce.Configurations.DTOs;
using Exercio.WebApi.Minimal.Ecommerce.Requests;
using Exercio.WebApi.Minimal.Ecommerce.Services.Interfaces;

namespace Exercio.WebApi.Minimal.Ecommerce.Services;

public class ProductService : IProductService
{
    public ProductDTO CreateProduct(ProductRequest product)
    {
        throw new NotImplementedException();
    }

    public bool DeleteProduct(int productId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ProductDTO> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public ProductDTO GetProductById(int productId)
    {
        throw new NotImplementedException();
    }

    public bool UpdateProduct(int id, ProductRequest product)
    {
        throw new NotImplementedException();
    }
}