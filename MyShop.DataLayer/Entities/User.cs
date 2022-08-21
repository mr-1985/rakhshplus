using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataLayer.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }
        public string FatherName { get; set; }
        public string NationalCode { get; set; }
        public string ShomareShenasnameh { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Password { get; set; }
        public string Tell { get; set; }
        public string Mobile { get; set; }
        public string MahaleSodour { get; set; }
        public string Gender { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string ActiveCode { get; set; }
        public string UserAvatar { get; set; }
        public string FrontNationalImage { get; set; }
        public string BackNationalImage { get; set; }
        public string FrontShenasnamehImage { get; set; }
        public string DescriptionShenasnamehImage { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        #region Relations

        public int? AgentId { get; set; }
        public Agent Agent { get; set; }
        public List<Order> Orders { get; set; }
        public  List<UserRole> UserRoles { get; set; }

        #endregion
    }
}
