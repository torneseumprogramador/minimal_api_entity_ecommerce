using Exercio.WebApi.Minimal.Ecommerce.Configurations.DTOs;
using Exercio.WebApi.Minimal.Ecommerce.Requests;

namespace Exercio.WebApi.Minimal.Ecommerce.Services.Interfaces;

/// <summary>
/// Interface for Customer service.
/// </summary>
public interface ICustomerService
{
    /// <summary>
    /// Retrieves a customer by ID.
    /// </summary>
    /// <param name="customerId">The ID of the customer.</param>
    /// <returns>The customer with the specified ID.</returns>
    CustomerDTO GetCustomerById(int customerId);

    /// <summary>
    /// Retrieves all customers.
    /// </summary>
    /// <returns>A collection of all customers.</returns>
    IEnumerable<CustomerDTO> GetAllCustomers();

    /// <summary>
    /// Creates a new customer.
    /// </summary>
    /// <param name="customer">The customer request object with the customer details.</param>
    /// <returns>The created customer.</returns>
    CustomerDTO CreateCustomer(CustomerRequest customer);

    /// <summary>
    /// Updates an existing customer.
    /// </summary>
    /// <param name="id">The ID of the customer to update.</param>
    /// <param name="customer">The customer request object with the updated customer details.</param>
    /// <returns>True if the customer was successfully updated, otherwise false.</returns>
    bool UpdateCustomer(int id, CustomerRequest customer);

    /// <summary>
    /// Deletes a customer.
    /// </summary>
    /// <param name="customerId">The ID of the customer to delete.</param>
    /// <returns>True if the customer was successfully deleted, otherwise false.</returns>
    bool DeleteCustomer(int customerId);
}
