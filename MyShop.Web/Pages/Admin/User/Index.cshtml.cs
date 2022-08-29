using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Core.Services.Interfaces;

namespace MyShop.Web.Pages.Admin.User
{
    public class IndexModel : PageModel
    {
        private IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public List<DataLayer.Entities.User> Users { get; set; }
        public void OnGet()
        {
            Users = _userService.GetAllUsers();
        }
    }
}
