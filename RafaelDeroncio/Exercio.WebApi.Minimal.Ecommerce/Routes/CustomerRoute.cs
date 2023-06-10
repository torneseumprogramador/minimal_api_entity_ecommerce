using Exercio.WebApi.Minimal.Ecommerce.Configurations.DTOs;
using Exercio.WebApi.Minimal.Ecommerce.Models;
using Exercio.WebApi.Minimal.Ecommerce.Requests;
using Exercio.WebApi.Minimal.Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exercio.WebApi.Minimal.Ecommerce.Routes;

public class CustomerRoute
{
    private readonly WebApplication _app;
    public CustomerRoute(WebApplication app)
    {
        _app = app;
    }

    public void Register()
    {
        _app.MapGet("/customers", GetAllCustomers)
            .WithName("Customers")
            .WithOpenApi();

        _app.MapGet("/customer/{id:int}", GetCustomerById)
            .WithName("Customer")
            .WithOpenApi();

        _app.MapPost("/customer/register", RegisterCustomer)
            .WithName("Register")
            .WithOpenApi();

        _app.MapPut("/customer/update/{id:int}", UpdateCustomer)
            .WithName("Update")
            .WithOpenApi();

        _app.MapDelete("/customer/delete/{id:int}", DeleteCustomer)
            .WithName("Delete")
            .WithOpenApi();
    }

    private IEnumerable<CustomerModel> GetAllCustomers([FromServices] ICustomerService customerService)
    {
        return customerService.GetAllCustomers();
    }

    private CustomerModel GetCustomerById(int id, [FromServices] ICustomerService customerService)
    {
        return customerService.GetCustomerById(id);
    }

    private CustomerModel RegisterCustomer([FromBody] CustomerRequest customer, [FromServices] ICustomerService customerService)
    {
        return customerService.CreateCustomer(customer);
    }

    private bool UpdateCustomer(int id, [FromBody] CustomerRequest customer, [FromServices] ICustomerService customerService)
    {
        return customerService.UpdateCustomer(id, customer);
    }

    private bool DeleteCustomer(int id, [FromServices] ICustomerService customerService)
    {
        return customerService.DeleteCustomer(id);
    }
}
