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

    private object GetAllCustomers()
    {
        return null;
    }

    private object GetCustomerById(int id)
    {
        return 1;
    }

    private object RegisterCustomer([FromBody] object customer)
    {
        return customer;
    }

    private object UpdateCustomer(int id, [FromBody] object customer)
    {
        return customer;
    }

    private object DeleteCustomer(int id)
    {
        return id;
    }
}
