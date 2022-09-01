using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.Services.Interfaces;
using MyShop.DataLayer.Context;
using MyShop.DataLayer.Entities;

namespace MyShop.Core.Services
{
    
    public class ProductService:IProductService
    {
        private MyShopContext _context;

        public ProductService(MyShopContext context)
        {
            _context = context;
        }
        public int AddProduct(Product product)
        {
           product.CreateDate=DateTime.Now;
           _context.Add(product);
           _context.SaveChanges();
           return product.ProductId;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.Where(p => p.IsDelete == false).ToList();
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.Find(productId);
        }

        public void UpdateProduct(Product product)
        {
            product.CreateDate=DateTime.Now;
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
