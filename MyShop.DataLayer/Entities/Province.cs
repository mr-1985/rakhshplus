using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataLayer.Entities
{
    public class Province
    {

        [Key]
        
        public int ProvinceId { get; set; }
        [Required]
        public string ProvinceName { get; set; }

        public List<City> Cities { get; set; }
    }
}
