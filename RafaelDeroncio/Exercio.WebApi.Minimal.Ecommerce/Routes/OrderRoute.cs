using Microsoft.AspNetCore.Mvc;

namespace Exercio.WebApi.Minimal.Ecommerce.Routes;

public class OrderRoute
{
    private readonly WebApplication _app;

    public OrderRoute(WebApplication app)
    {
        _app = app;
    }

    public void Register()
    {
        _app.MapGet("/orders", GetAllOrders)
            .WithName("Orders")
            .WithOpenApi();

        _app.MapGet("/order/{id:int}", GetOrderById)
            .WithName("Order")
            .WithOpenApi();

        _app.MapPost("/order/create", CreateOrder)
            .WithName("CreateOrder")
            .WithOpenApi();

        _app.MapPut("/order/update/{id:int}", UpdateOrder)
            .WithName("UpdateOrder")
            .WithOpenApi();

        _app.MapDelete("/order/delete/{id:int}", DeleteOrder)
            .WithName("DeleteOrder")
            .WithOpenApi();
    }

    private object GetAllOrders()
    {
        return null;
    }

    private object GetOrderById(int id)
    {
        return null;
    }

    private object CreateOrder([FromBody] object order)
    {
        return order;
    }

    private object UpdateOrder(int id, [FromBody] object order)
    {
        return order;
    }

    private object DeleteOrder(int id)
    {
        return id;
    }
}
