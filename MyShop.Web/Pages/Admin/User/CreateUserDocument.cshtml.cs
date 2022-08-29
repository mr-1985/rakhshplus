using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Core.Services.Interfaces;
using MyShop.DataLayer.Entities;

namespace MyShop.Web.Pages.Admin.User
{
    public class CreateUserDocumentModel : PageModel
    {
        private IUserService _userService;

        public CreateUserDocumentModel(IUserService userService)
        {
            _userService = userService;
        }

        public UsersDocument Document { get; set; }
        public void OnGet(int id)
        {
            ViewData["UserId"] = id;
        }
    }
}
