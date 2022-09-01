using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Core.Services.Interfaces;
using MyShop.Core.ViewModels;
using MyShop.DataLayer.Entities;

namespace MyShop.Web.Pages.UserPanel
{
    public class ProfileModel : PageModel
    {
        private IUserService _userService;

        public ProfileModel(IUserService userService)
        {
            _userService = userService;
        }

        public User Information { get; set; }
        public void OnGet()
        {
            Information = _userService.GetUserForShowInProfile(User.Identity.Name);
        }
    }
}
