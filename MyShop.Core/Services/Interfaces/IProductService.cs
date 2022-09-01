using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.DataLayer.Entities;

namespace MyShop.Core.Services.Interfaces
{
    public interface IProductService
    {
        int AddProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProductById(int productId);
        void UpdateProduct(Product product);
    }
}
