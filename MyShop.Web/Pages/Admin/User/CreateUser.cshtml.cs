using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Core.Services.Interfaces;

namespace MyShop.Web.Pages.Admin.User
{
    public class CreateUserModel : PageModel
    {
        private IUserService _userService;

        public CreateUserModel(IUserService userService)
        {
            _userService = userService;
        }

        //[BindProperty]
        //public UserViewModel.CreateUserViewModel CreateUserViewModel { get; set; }
        public void OnGet()
        {
            //ViewData["Roles"] = _permissionService.GetRoles();
        }
    }
}
