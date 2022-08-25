using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataLayer.Entities
{
    public class City
    {
        [Key]
        
        public int CityId { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        public int ProvinceId { get; set; }

        
    }
}
