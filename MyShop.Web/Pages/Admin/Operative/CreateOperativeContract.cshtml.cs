using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyShop.Core.Services.Interfaces;

namespace MyShop.Web.Pages.Admin.Operative
{
    public class CreateOperativeContractModel : PageModel
    {
        private IAgentService _agentService;
        private IUserService _userService;

        public CreateOperativeContractModel(IAgentService agentService, IUserService userService)
        {
            _agentService = agentService;
            _userService = userService;
        }

        [BindProperty]
        public DataLayer.Entities.Contract Contract { get; set; }
        public DataLayer.Entities.Operative Operative { get; set; }
        public void OnGet()
        {
            var operative = _agentService.GetAllOperativeSelectList();
            ViewData["operative"] = new SelectList(operative, "Value", "Text");
        }

        public IActionResult OnPost(string stDate = "", string endDate = "")
        {
            if (stDate != "")
            {
                string[] std = stDate.Split('/');
                Contract.StartDate = new DateTime(
                    int.Parse(std[0]),
                    int.Parse(std[1]),
                    int.Parse(std[2]),
                    new PersianCalendar()
                );
            }

            if (endDate != "")
            {
                //string[] edd = endDate.Split('/');
                string[] edd = endDate.Split('/');
                Contract.EndDate = new DateTime(int.Parse(edd[0]),
                    int.Parse(edd[1]),
                    int.Parse(edd[2]),
                    new PersianCalendar()
                );
            }

            var userId = _userService.GetUserIdByUserName(User.Identity.Name);
            Contract.UserId = userId;

            if (!ModelState.IsValid)
                return Page();
            _agentService.AddContract(Contract);
            return RedirectToPage("OperativeContractList");
        }
    }
}
