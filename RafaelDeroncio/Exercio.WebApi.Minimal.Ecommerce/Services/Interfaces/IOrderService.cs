using Exercio.WebApi.Minimal.Ecommerce.Models;
using Exercio.WebApi.Minimal.Ecommerce.Requests;

namespace Exercio.WebApi.Minimal.Ecommerce.Services.Interfaces;

/// <summary>
/// Interface for Order service.
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Retrieves an order by ID.
    /// </summary>
    /// <param name="orderId">The ID of the order.</param>
    /// <returns>The order with the specified ID.</returns>
    OrderModel GetOrderById(int orderId);

    /// <summary>
    /// Retrieves all orders.
    /// </summary>
    /// <returns>A collection of all orders.</returns>
    IEnumerable<OrderModel> GetAllOrders();

    /// <summary>
    /// Creates a new order.
    /// </summary>
    /// <param name="order">The order request object with the order details.</param>
    /// <returns>The created order.</returns>
    OrderModel CreateOrder(OrderRequest order);

    /// <summary>
    /// Updates an existing order.
    /// </summary>
    /// <param name="id">The ID of the order to update.</param>
    /// <param name="order">The order request object with the updated order details.</param>
    /// <returns>True if the order was successfully updated, otherwise false.</returns>
    bool UpdateOrder(int id, OrderRequest order);

    /// <summary>
    /// Deletes an order.
    /// </summary>
    /// <param name="orderId">The ID of the order to delete.</param>
    /// <returns>True if the order was successfully deleted, otherwise false.</returns>
    bool DeleteOrder(int orderId);
}
