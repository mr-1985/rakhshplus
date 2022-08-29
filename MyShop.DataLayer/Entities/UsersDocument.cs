using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataLayer.Entities
{
    public class UsersDocument
    {
        [Key]
        public int UserDocumentId { get; set; }

        public int UserId { get; set; }

        [Display(Name = "عکس پرسنلی 4*3")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string PersonalImage { get; set; }

        [Display(Name = "تصویر  روی کارت ملی")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string FrontNationalImage { get; set; }

        [Display(Name = "تصویر  پشت کارت ملی")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string BackNationalImage { get; set; }

        [Display(Name = "تصویر  صفحه اول شناسنامه")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string FrontShenasnamehImage { get; set; }

        [Display(Name = "تصویر  صفحه توضیحات")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string DescriptionShenasnamehImage { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }

        public User User { get; set; }
    }
}
