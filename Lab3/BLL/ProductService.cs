using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public void AddProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new ArgumentException("Product name cannot be empty!");
            }
            if (product.Price < 0)
            {
                throw new ArgumentException("Product price must be non-negative!");
            }
            _productRepository.AddProduct(product);
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public void UpdateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new ArgumentException("Product name cannot be empty!");
            }
            if (product.Price < 0)
            {
                throw new ArgumentException("Product price must be non-negative!");
            }
            _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }
    }
}
