using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyShop.Core.Services.Interfaces;

namespace MyShop.Web.Pages.Admin.Agent
{
    public class EditAgentModel : PageModel
    {
        private IAgentService _agentService;

        public EditAgentModel(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [BindProperty]
        public DataLayer.Entities.Agent Agent { get; set; }
        public void OnGet(int id)
        {
            Agent = _agentService.GetAgentById(id);

            var province = _agentService.GetAllProvinceSelectList();
            ViewData["province"] = new SelectList(province, "Value", "Text");

            List<SelectListItem> city = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = ""}
            };

            city.AddRange(_agentService.GetCityByProvinceIDSelectList(Convert.ToInt32(Agent.Ostan)));
            string selectedCity = null;
            if (Agent.City != null)
            {
                selectedCity = Agent.City;
            }

            ViewData["City"] = new SelectList(city, "Value", "Text", selectedCity);
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                var province = _agentService.GetAllProvinceSelectList();
                ViewData["province"] = new SelectList(province, "Value", "Text");

                var city = _agentService.GetCityByProvinceIDSelectList(int.Parse(province.First().Value));
                ViewData["City"] = new SelectList(city, "Value", "Text");


                return Page();
            }
                

            _agentService.UpdateAgent(Agent);

            return Redirect("/Admin/Agent/EditAgentDocument/" + id);
        }
    }
}
