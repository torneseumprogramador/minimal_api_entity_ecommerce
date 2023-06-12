using Exercio.WebApi.Minimal.Ecommerce.Models;
using Exercio.WebApi.Minimal.Ecommerce.Requests;
using Exercio.WebApi.Minimal.Ecommerce.Services.Interfaces;
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

    private IEnumerable<OrderModel> GetAllOrders([FromServices] IOrderService orderService, HttpContext context)
    {
        int pageNumber = Convert.ToInt32(context.Request.Query["pageNumber"]);
        int pageSize = Convert.ToInt32(context.Request.Query["pageSize"]);

        return orderService.GetAllOrders(pageNumber, pageSize);
    }

    private OrderModel GetOrderById(int id, [FromServices] IOrderService orderService)
    {
        return orderService.GetOrderById(id);
    }

    private OrderModel CreateOrder([FromBody] OrderRequest order, [FromServices] IOrderService orderService)
    {
        return orderService.CreateOrder(order);
    }

    private bool UpdateOrder(int id, [FromBody] OrderRequest order, [FromServices] IOrderService orderService)
    {
        return orderService.UpdateOrder(id, order);
    }

    private bool DeleteOrder(int id, [FromServices] IOrderService orderService)
    {
        return orderService.DeleteOrder(id);
    }
}
