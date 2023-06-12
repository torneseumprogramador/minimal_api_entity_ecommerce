using Exercio.WebApi.Minimal.Ecommerce.Contexts;
using Exercio.WebApi.Minimal.Ecommerce.Models;
using Exercio.WebApi.Minimal.Ecommerce.Requests;
using Exercio.WebApi.Minimal.Ecommerce.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Exercio.WebApi.Minimal.Ecommerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly EcommerceDatabaseContext _databaseContext;

        public OrderService(EcommerceDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public OrderModel CreateOrder(OrderRequest order)
        {
            CustomerModel customer = _databaseContext.Customers.FirstOrDefault(x => x.Id == order.CustomerId);

            if (customer is null)
                throw new InvalidOperationException("O cliente não existe.");

            OrderModel newOrder = new()
            {
                CustomerId = order.CustomerId,
                Customer = customer,
                OrderDate = DateTime.Now,
                TotalAmount = (decimal)order.Products.Sum(product => product.Price)
            };

            _databaseContext.Orders.Add(newOrder);
            _databaseContext.SaveChanges();

            return newOrder;
        }

        public bool DeleteOrder(int orderId)
        {
            OrderModel order = _databaseContext.Orders.FirstOrDefault(x => x.Id == orderId);

            if (order is null)
                return false;

            _databaseContext.Orders.Remove(order);

            return _databaseContext.SaveChanges() > 0;
        }

        public IEnumerable<OrderModel> GetAllOrders(int pageNumber, int pageSize)
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            pageSize = pageSize > 0 ? pageSize : 5;

            var query = _databaseContext.Orders
                .OrderBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking();

            return query.ToList();
        }


        public OrderModel GetOrderById(int orderId)
        {
            return _databaseContext.Orders
                .Where(o => o.Id == orderId)
                .AsNoTracking()
                .FirstOrDefault();
        }


        public bool UpdateOrder(int id, OrderRequest order)
        {
            if (!_databaseContext.Orders.Any(x => x.Id == id))
                return false;

            OrderModel updatedOrder = new()
            {
                TotalAmount = (decimal)order.Products.Sum(product => product.Price)
            };

            _databaseContext.Orders.Update(updatedOrder);

            return _databaseContext.SaveChanges() > 0;
        }
    }
}
