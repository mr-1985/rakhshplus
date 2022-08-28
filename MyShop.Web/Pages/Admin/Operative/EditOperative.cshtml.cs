using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyShop.Core.Services.Interfaces;

namespace MyShop.Web.Pages.Admin.Operative
{
    public class EditOperativeModel : PageModel
    {
        private IAgentService _agentService;

        public EditOperativeModel(IAgentService agentService)
        {
            _agentService = agentService;
        }
        [BindProperty]
        public DataLayer.Entities.Operative Operative { get; set; }
        public void OnGet(int id)
        {
            Operative = _agentService.GetOperativeById(id);

            var province = _agentService.GetAllProvinceSelectList();
            ViewData["province"] = new SelectList(province, "Value", "Text");

            List<SelectListItem> city = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = ""}
            };

            city.AddRange(_agentService.GetCityByProvinceIDSelectList( Convert.ToInt32(Operative.Ostan)));
            string selectedCity = null;
            if (Operative.City != null)
            {
                selectedCity = Operative.City;
            }

            ViewData["City"] = new SelectList(city, "Value", "Text", selectedCity);
        }

        public IActionResult OnPost(int id)
        {

            if (!ModelState.IsValid)
            {
                //var province = _agentService.GetAllProvinceSelectList();
                //ViewData["province"] = new SelectList(province, "Value", "Text");

                //var city = _agentService.GetCityByProvinceIDSelectList(int.Parse(province.First().Value));
                //ViewData["City"] = new SelectList(city, "Value", "Text");


                return Page();
            }

            _agentService.UpdateOperative(Operative);
            //return RedirectToPage("Index");

            return Redirect("/Admin/Operative/AddOperativeDocument/" + Operative.OperativeId);
        }

    }
}
