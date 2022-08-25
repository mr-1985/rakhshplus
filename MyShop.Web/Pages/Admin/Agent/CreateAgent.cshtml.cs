using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyShop.Core.Services.Interfaces;

namespace MyShop.Web.Pages.Admin.Agent
{
    public class CreateAgentModel : PageModel
    {
        private IAgentService _agentService;

        public CreateAgentModel(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [BindProperty] 
        public DataLayer.Entities.Agent Agent { get; set; }
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

            _agentService.AddAgent(Agent);
            //return RedirectToPage("Index");

            return Redirect("/Admin/Agent/AddAgentDocument/" + Agent.AgentId);
        }
    }
}
