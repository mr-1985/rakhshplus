using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataLayer.Entities
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }


        public List<Product> Product { get; set; }
        public Store Store { get; set; }
    }
}
