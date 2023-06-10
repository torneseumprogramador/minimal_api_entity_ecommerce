using Exercio.WebApi.Minimal.Ecommerce.Configurations.DTOs;
using Exercio.WebApi.Minimal.Ecommerce.Requests;
using Exercio.WebApi.Minimal.Ecommerce.Services.Interfaces;

namespace Exercio.WebApi.Minimal.Ecommerce.Services;

public class OrderService : IOrderService
{
    public OrderDTO CreateOrder(OrderRequest order)
    {
        throw new NotImplementedException();
    }

    public bool DeleteOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<OrderDTO> GetAllOrders()
    {
        throw new NotImplementedException();
    }

    public OrderDTO GetOrderById(int orderId)
    {
        throw new NotImplementedException();
    }

    public bool UpdateOrder(int id, OrderRequest order)
    {
        throw new NotImplementedException();
    }
}