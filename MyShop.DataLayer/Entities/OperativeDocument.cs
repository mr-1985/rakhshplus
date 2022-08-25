using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataLayer.Entities
{
    public class OperativeDocument
    {
        [Key]
        public int OperativeDocumentId { get; set; }

        public int OperativeId { get; set; }

        [Display(Name = "تصویر  سر درب فروشگاه")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string SarDarbForoushgahImage { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }

        public Operative Operative { get; set; }
    }
}
