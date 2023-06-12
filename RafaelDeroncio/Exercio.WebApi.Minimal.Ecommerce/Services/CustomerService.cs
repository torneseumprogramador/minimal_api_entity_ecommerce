using Exercio.WebApi.Minimal.Ecommerce.Contexts;
using Exercio.WebApi.Minimal.Ecommerce.Models;
using Exercio.WebApi.Minimal.Ecommerce.Requests;
using Exercio.WebApi.Minimal.Ecommerce.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Exercio.WebApi.Minimal.Ecommerce.Services;

public class CustomerService : ICustomerService
{
    private readonly EcommerceDatabaseContext _databaseContext;

    public CustomerService(EcommerceDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public CustomerModel CreateCustomer(CustomerRequest customer)
    {
        var existingCustomer = _databaseContext.Customers.FirstOrDefault(x => x.Email == customer.Email || x.IdentificationDoc == customer.IdentificationDoc);

        if (existingCustomer != null)
        {
            throw new InvalidOperationException("Um cliente com o mesmo e-mail ou documento já existe.");
        }

        CustomerModel newCustomer = new()
        {
            Name = customer.Name,
            PhoneNumber = customer.PhoneNumber,
            Email = customer.Email,
            IdentificationDoc = customer.IdentificationDoc,
            Address = customer.Address
        };

        _databaseContext.Customers.Add(newCustomer);
        _databaseContext.SaveChanges();

        return newCustomer;
    }


    public bool DeleteCustomer(int customerId)
    {
        CustomerModel customer = _databaseContext.Customers.FirstOrDefault(x => x.Id == customerId);

        if (customer is null)
            return false;

        _databaseContext.Customers.Remove(customer);

        return _databaseContext.SaveChanges() > 0;
    }

    public IEnumerable<CustomerModel> GetAllCustomers(int pageNumber, int pageSize)
    {
        pageNumber = pageNumber > 0 ? pageNumber : 1;   
        pageSize = pageSize > 0 ? pageSize : 5;

        return _databaseContext.Customers
            .OrderBy(x => x.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(c => new CustomerModel
            {
                Id = c.Id,
                Name = c.Name,
                PhoneNumber = c.PhoneNumber,
                Email = c.Email,
                IdentificationDoc = c.IdentificationDoc,
                Address = c.Address,
                RegisterDate = c.RegisterDate
            })
            .AsNoTracking()
            .ToList();
    }



    public CustomerModel GetCustomerById(int customerId)
    {
        return _databaseContext.Customers
            .Where(c => c.Id == customerId)
            .Select(c => new CustomerModel
            {
                Id = c.Id,
                Name = c.Name,
                PhoneNumber = c.PhoneNumber,
                Email = c.Email,
                IdentificationDoc = c.IdentificationDoc,
                Address = c.Address,
                RegisterDate = c.RegisterDate
            })
            .AsNoTracking()
            .FirstOrDefault();
    }


    public bool UpdateCustomer(int id, CustomerRequest customer)
    {
        if (!_databaseContext.Customers.Any(x => x.Id == id))
            return false;

        CustomerModel updatedCustomer = new()
        {
            Name = customer.Name,
            PhoneNumber = customer.PhoneNumber,
            Email = customer.Email,
            IdentificationDoc = customer.IdentificationDoc,
            Address = customer.Address
        };

        _databaseContext.Customers.Update(updatedCustomer);

        return _databaseContext.SaveChanges() > 0;
    }
}
