using Exercio.WebApi.Minimal.Ecommerce.Configurations.DTOs;
using Exercio.WebApi.Minimal.Ecommerce.Contexts;
using Exercio.WebApi.Minimal.Ecommerce.Models;
using Exercio.WebApi.Minimal.Ecommerce.Requests;
using Exercio.WebApi.Minimal.Ecommerce.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercio.WebApi.Minimal.Ecommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly EcommerceDatabaseContext _databaseContext;

        public ProductService(EcommerceDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public ProductModel CreateProduct(ProductRequest product)
        {
            var existingProduct = _databaseContext.Products.FirstOrDefault(x => x.Name == product.Name && x.Price == (decimal)product.Price);

            if (existingProduct != null)
                throw new InvalidOperationException("Produto já cadastrado.");

            ProductModel newProduct = new ProductModel
            {
                Name = product.Name,
                Price = product.Price
            };

            _databaseContext.Products.Add(newProduct);
            _databaseContext.SaveChanges();

            return newProduct;
        }

        public bool DeleteProduct(int productId)
        {
            ProductModel product = _databaseContext.Products.FirstOrDefault(x => x.Id == productId);

            if (product is null)
                return false;

            _databaseContext.Products.Remove(product);

            return _databaseContext.SaveChanges() > 0;
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            return _databaseContext.Products
                .OrderBy(x => x.Id)
                .Select(p => new ProductModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                })
                .AsNoTracking()
                .ToList();
        }

        public ProductModel GetProductById(int productId)
        {
            return _databaseContext.Products
                .Where(p => p.Id == productId)
                .Select(p => new ProductModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                })
                .AsNoTracking()
                .FirstOrDefault();
        }

        public bool UpdateProduct(int id, ProductRequest product)
        {
            if (!_databaseContext.Products.Any(x => x.Id == id))
                return false;

            ProductModel updatedProduct = new ProductModel
            {
                Id = id,
                Name = product.Name,
                Price = product.Price
            };

            _databaseContext.Products.Update(updatedProduct);

            return _databaseContext.SaveChanges() > 0;
        }
    }
}
