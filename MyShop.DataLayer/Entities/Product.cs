using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataLayer.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(50)]
        public string ProductImageName { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; }

        public Item Item { get; set; }
    }
}
