using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyShop.Core.Services.Interfaces;

namespace MyShop.Web.Pages.Admin.Operative
{
    public class CreateOperativeModel : PageModel
    {
        private IAgentService _agentService;

        public CreateOperativeModel(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [BindProperty]
        public DataLayer.Entities.Operative Operative { get; set; }
        public void OnGet()
        {
            var province = _agentService.GetAllProvinceSelectList();
            ViewData["province"] = new SelectList(province, "Value", "Text");

            var city = _agentService.GetCityByProvinceIDSelectList(int.Parse(province.First().Value));
            ViewData["City"] = new SelectList(city, "Value", "Text");
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                var province = _agentService.GetAllProvinceSelectList();
                ViewData["province"] = new SelectList(province, "Value", "Text");

                var city = _agentService.GetCityByProvinceIDSelectList(int.Parse(province.First().Value));
                ViewData["City"] = new SelectList(city, "Value", "Text");


                return Page();
            }

            _agentService.AddOperative(Operative);
            //return RedirectToPage("Index");

            return Redirect("/Admin/Agent/AddOperativeDocument/" + Operative.OperativeId);
        }

    }
}
