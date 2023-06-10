using Exercio.WebApi.Minimal.Ecommerce.Configurations.DTOs;
using Exercio.WebApi.Minimal.Ecommerce.Requests;
using Exercio.WebApi.Minimal.Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exercio.WebApi.Minimal.Ecommerce.Routes;

public class CustomerRoute
{
    private readonly WebApplication _app;
    private readonly ICustomerService _customerService; 

    public CustomerRoute(WebApplication app)
    {
        _app = app;
    }

    public CustomerRoute(ICustomerService customerService)
    {
        _customerService = customerService;
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

    private IEnumerable<CustomerDTO> GetAllCustomers()
    {
        return _customerService.GetAllCustomers();
    }

    private CustomerDTO GetCustomerById(int id)
    {
        return _customerService.GetCustomerById(id);
    }

    private CustomerDTO RegisterCustomer([FromBody] CustomerRequest customer)
    {
        return _customerService.CreateCustomer(customer);
    }

    private bool UpdateCustomer(int id, [FromBody] CustomerRequest customer)
    {
        return _customerService.UpdateCustomer(id, customer);
    }

    private bool DeleteCustomer(int id)
    {
        return _customerService.DeleteCustomer(id);
    }
}
