using Exercio.WebApi.Minimal.Ecommerce.Models;
using Exercio.WebApi.Minimal.Ecommerce.Requests;

namespace Exercio.WebApi.Minimal.Ecommerce.Services.Interfaces;

/// <summary>
/// Interface for Product service.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Retrieves a product by ID.
    /// </summary>
    /// <param name="productId">The ID of the product.</param>
    /// <returns>The product with the specified ID.</returns>
    ProductModel GetProductById(int productId);

    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <returns>A collection of all products.</returns>
    IEnumerable<ProductModel> GetAllProducts();

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="product">The product request object with the product details.</param>
    /// <returns>The created product.</returns>
    ProductModel CreateProduct(ProductRequest product);

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="id">The ID of the product to update.</param>
    /// <param name="product">The product request object with the updated product details.</param>
    /// <returns>True if the product was successfully updated, otherwise false.</returns>
    bool UpdateProduct(int id, ProductRequest product);

    /// <summary>
    /// Deletes a product.
    /// </summary>
    /// <param name="productId">The ID of the product to delete.</param>
    /// <returns>True if the product was successfully deleted, otherwise false.</returns>
    bool DeleteProduct(int productId);
}

