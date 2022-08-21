using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0}  را وارد نمایید.")]
        [MaxLength(200, ErrorMessage = "{0}  نمی تواند بیشتر از {1}  کاراکتر باشد")]
        public string UserName { get; set; }

        [Display(Name = "کلمه عبور ")]
        [Required(ErrorMessage = "لطفا {0}  را وارد نمایید.")]
        [MaxLength(200, ErrorMessage = "{0}  نمی تواند بیشتر از {1}  کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار ")]
        public bool RememberMe { get; set; }
    }

    public class SideBarAdminPanelViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }

    }
}
