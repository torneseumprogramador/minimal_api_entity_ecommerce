using Exercio.WebApi.Minimal.Ecommerce.Configurations.DTOs;
using Exercio.WebApi.Minimal.Ecommerce.Requests;
using Exercio.WebApi.Minimal.Ecommerce.Services.Interfaces;

namespace Exercio.WebApi.Minimal.Ecommerce.Services;

public class CustomerService : ICustomerService
{
    public CustomerDTO CreateCustomer(CustomerRequest customer)
    {
        throw new NotImplementedException();
    }

    public bool DeleteCustomer(int customerId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<CustomerDTO> GetAllCustomers()
    {
        throw new NotImplementedException();
    }

    public CustomerDTO GetCustomerById(int customerId)
    {
        throw new NotImplementedException();
    }

    public bool UpdateCustomer(int id, CustomerRequest customer)
    {
        throw new NotImplementedException();
    }
}