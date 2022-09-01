using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyShop.Core.Convertors;
using MyShop.Core.Services.Interfaces;
using MyShop.Core.ViewModels;

namespace MyShop.Web.Pages.Admin.User
{
    public class CreateUserModel : PageModel
    {
        private IUserService _userService;
        private IPermissionService _permissionService;
        private IAgentService _agentService;

        public CreateUserModel(IUserService userService, IPermissionService permissionService, IAgentService agentService)
        {
            _userService = userService;
            _permissionService = permissionService;
            _agentService = agentService;
        }


        [BindProperty]
        public CreateUserViewModel User { get; set; }
        public void OnGet()
        {
            var province = _agentService.GetAllProvinceSelectList();
            ViewData["province"] = new SelectList(province, "Value", "Text");

            var city = _agentService.GetCityByProvinceIDSelectList(int.Parse(province.First().Value));
            ViewData["City"] = new SelectList(city, "Value", "Text");

            var mahaleSodour = _agentService.GetCityByProvinceIDSelectList(int.Parse(province.First().Value));
            ViewData["mahaleSodour"] = new SelectList(city, "Value", "Text");


            ViewData["Roles"] = _permissionService.GetRoles();
        }

        public IActionResult OnPost(List<int> SelectedRoles,string gendre)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ViewData["Roles"] = _permissionService.GetRoles();
            if (_userService.IsExistUserName(FixedText.SkipLetter(User.UserName)))
            {
                ModelState.AddModelError("User.UserName", "نام کاربری وارد شده تکراری می باشد");

                return Page();
            }

            if (_userService.IsExistMobile(User.Mobile))
            {
                ModelState.AddModelError("User.Mobile", "شماره موبایل وارد شده تکراری می باشد");

                return Page();
            }

            User.Gendre = gendre;

            int userId = _userService.AddUserFromAdmin(User);
            _permissionService.AddRolesToUser(SelectedRoles, userId);
            return Redirect("/Admin/User/CreateUserDocument/" + userId);
            
        }
    }
}
