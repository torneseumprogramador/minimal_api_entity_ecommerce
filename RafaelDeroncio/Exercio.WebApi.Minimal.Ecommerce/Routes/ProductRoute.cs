using Exercio.WebApi.Minimal.Ecommerce.Models;
using Exercio.WebApi.Minimal.Ecommerce.Requests;
using Exercio.WebApi.Minimal.Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exercio.WebApi.Minimal.Ecommerce.Routes;

public class ProductRoute
{
    private readonly WebApplication _app;

    public ProductRoute(WebApplication app)
    {
        _app = app;
    }

    public void Register()
    {
        _app.MapGet("/products", GetAllProducts)
            .WithName("Products")
            .WithOpenApi();

        _app.MapGet("/product/{id:int}", GetProductById)
            .WithName("Product")
            .WithOpenApi();

        _app.MapPost("/product/create", CreateProduct)
            .WithName("CreateProduct")
            .WithOpenApi();

        _app.MapPut("/product/update/{id:int}", UpdateProduct)
            .WithName("UpdateProduct")
            .WithOpenApi();

        _app.MapDelete("/product/delete/{id:int}", DeleteProduct)
            .WithName("DeleteProduct")
            .WithOpenApi();
    }

    private IEnumerable<ProductModel> GetAllProducts([FromServices] IProductService productService, HttpContext context)
    {
        int pageNumber = Convert.ToInt32(context.Request.Query["pageNumber"]);
        int pageSize = Convert.ToInt32(context.Request.Query["pageSize"]);

        return productService.GetAllProducts(pageNumber, pageSize);
    }

    private ProductModel GetProductById(int id, [FromServices] IProductService productService)
    {
        return productService.GetProductById(id);
    }

    private ProductModel CreateProduct([FromBody] ProductRequest product, [FromServices] IProductService productService)
    {
        return productService.CreateProduct(product);
    }

    private bool UpdateProduct(int id, [FromBody] ProductRequest product, [FromServices] IProductService productService)
    {
        return productService.UpdateProduct(id, product);
    }

    private bool DeleteProduct(int id, [FromServices] IProductService productService)
    {
        return productService.DeleteProduct(id);
    }
}
