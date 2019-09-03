using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.Models;

namespace WebAPIDemo.Services
{
    public interface IProduct
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
