using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataLayer.Entities
{
    public class Item
    {
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }


        public Product Product { get; set; }
    }
}
