using System;
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
    public class EditUserModel : PageModel
    {
        private IUserService _userService;
        private IPermissionService _permissionService;
        private IAgentService _agentService;

        public EditUserModel(IUserService userService, IPermissionService permissionService, IAgentService agentService)
        {
            _userService = userService;
            _permissionService = permissionService;
            _agentService = agentService;
        }

        [BindProperty]
        public DataLayer.Entities.User User { get; set; }

        public void OnGet(int id)
        {
            User = _userService.GetUserById(id);

            var province = _agentService.GetAllProvinceSelectList();
            ViewData["province"] = new SelectList(province, "Value", "Text");

            List<SelectListItem> city = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = ""}
            };

            city.AddRange(_agentService.GetCityByProvinceIDSelectList(Convert.ToInt32(User.Province)));
            string selectedCity = null;
            if (User.City != null)
            {
                selectedCity = User.City;
            }

            ViewData["City"] = new SelectList(city, "Value", "Text", selectedCity);

            List<SelectListItem> mahaleSodour = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = ""}
            };

           mahaleSodour.AddRange(_agentService.GetCityByProvinceIDSelectList(Convert.ToInt32(User.Province)));
            string selectedmahaleSodour = null;
            if (User.MahaleSodour != null)
            {
                selectedmahaleSodour = User.MahaleSodour;
            }

            ViewData["mahaleSodour"] = new SelectList(mahaleSodour, "Value", "Text", selectedmahaleSodour);

            ViewData["Roles"] = _permissionService.GetRoles();
        }

        public IActionResult OnPost(List<int> SelectedRoles, string gendre,int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ViewData["Roles"] = _permissionService.GetRoles();
            //if (_userService.IsExistUserName(FixedText.SkipLetter(User.UserName)))
            //{
            //    ModelState.AddModelError("User.UserName", "نام کاربری وارد شده تکراری می باشد");

            //    return Page();
            //}

            //if (_userService.IsExistMobile(User.Mobile))
            //{
            //    ModelState.AddModelError("User.Mobile", "شماره موبایل وارد شده تکراری می باشد");

            //    return Page();
            //}

            User.Gender = gendre;

            int userId =id;

            //Edit Roles
            _permissionService.EditRolesUser(userId, SelectedRoles);
            _userService.UpdateUser(User);
            //return Redirect("/Admin/User/CreateUserDocument/" + userId);
            return RedirectToPage("Index");

        }
    }
}
