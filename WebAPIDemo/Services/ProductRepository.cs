using System;
using System.Collections.Generic;
using WebAPIDemo.Data;
using WebAPIDemo.Models;
using System.Linq;

namespace WebAPIDemo.Services
{
    public class ProductRepository : IProduct
    {
        private ProductDbContext _productDbContext;

        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productDbContext.Products;
        }

        public Product GetProduct(int id)
        {
            return _productDbContext.Products.SingleOrDefault(x => x.ProductId == id);
        }

        public void AddProduct(Product product)
        {
            _productDbContext.Products.Add(product);
            _productDbContext.SaveChanges(true);
        }

        public void UpdateProduct(Product product)
        {
            _productDbContext.Products.Update(product);
            _productDbContext.SaveChanges(true);
        }

        public void DeleteProduct(int id)
        {
            var product = _productDbContext.Products.Find(id);
            _productDbContext.Products.Remove(product);
            _productDbContext.SaveChanges();
        }
    }
}
