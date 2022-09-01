using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Core.Services.Interfaces;
using MyShop.Core.ViewModels;

namespace MyShop.Web.Pages.UserPanel
{
    public class EditProfileModel : PageModel
    {
        private IUserService _userService;

        public EditProfileModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public EditProfileViewModel EditProfileViewModel { get; set; }
        public void OnGet()
        {
            EditProfileViewModel = _userService.GetDataForEditProfileUser(User.Identity.Name);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _userService.EditProfile(User.Identity.Name, EditProfileViewModel);

            //Log Out User
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/Account/Login?EditProfile=true");
        }
    }
}
