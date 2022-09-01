using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Core.Services.Interfaces;
using MyShop.Core.ViewModels;

namespace MyShop.Web.Pages.UserPanel
{
    public class ChangePasswordModel : PageModel
    {
        private IUserService _userService;

        public ChangePasswordModel(IUserService userService)
        {
            _userService = userService;
        }
        [BindProperty]
        public ChangePasswordViewModel ChangePassword { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(string oldPassword, string password, string rePassword)
        {
            if (!ModelState.IsValid)
                return Page();

            if (!_userService.CompareOldPassword(User.Identity.Name, oldPassword))
            {
                ViewData["InvalidOldPassword"] = true;
                //ModelState.AddModelError("OldPassword", "کلمه عبور فعلی صحیح نمی باشد");
                return Page();
            }

            if (!_userService.ComparePasswords(password, rePassword))
            {
                ViewData["NotMatchPassword"] = true;
                return Page();
            }

            _userService.ChangeUserPassword(User.Identity.Name, password.ToString());
            ViewData["IsSuccess"] = true;

            return Page();
        }
    }
}
