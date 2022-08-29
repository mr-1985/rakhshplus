using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Core.Services.Interfaces;
using MyShop.DataLayer.Entities;

namespace MyShop.Web.Pages.Admin.User
{
    public class ShowUserDocumentsModel : PageModel
    {
        IUserService _userService;

        public ShowUserDocumentsModel(IUserService userService)
        {
            _userService = userService;
        }

        public UsersDocument UsersDocument { get; set; }
        public void OnGet(int id)
        {
            UsersDocument = _userService.GetDocumentByUserId(id);
        }
    }
}
