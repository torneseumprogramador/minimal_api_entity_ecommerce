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
        _app.MapGet("/product", GetAllProducts)
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

    private object GetAllProducts()
    {
        return null;
    }

    private object GetProductById(int id)
    {
        return null;
    }

    private object CreateProduct([FromBody] object product)
    {
        return product;
    }

    private object UpdateProduct(int id, [FromBody] object product)
    {
        return product;
    }

    private object DeleteProduct(int id)
    {
        return id;
    }
}
