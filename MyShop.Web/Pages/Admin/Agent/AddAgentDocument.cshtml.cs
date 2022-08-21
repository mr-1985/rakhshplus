using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Core.Services.Interfaces;
using MyShop.DataLayer.Entities;

namespace MyShop.Web.Pages.Admin.Agent
{
    public class AddAgentDocumentModel : PageModel
    {
        private IAgentService _agentService;

        public AddAgentDocumentModel(IAgentService agentService)
        {
            _agentService = agentService;
        }

        public AgentDocument ListofDocument { get; set; }

        [BindProperty]
        public AgentDocument Document { get; set; }
        public void OnGet(int id)
        {
            Document = new AgentDocument();
            Document.AgentId = id;

            ListofDocument = _agentService.GetDocumentByAgentId(id);
        }

        public IActionResult OnPost(IFormFile imgMojavez,IFormFile imgSherkatname,IFormFile imgFishab,IFormFile imgFishtelephone,
            IFormFile imgAgahitaasis,IFormFile imgAkharintaaghirat,IFormFile imgFishgaz,IFormFile imgSanadNoe,
            IFormFile imgRoozname,IFormFile imgSardarforoshgah,IFormFile imgFishbargh)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _agentService.AddAgentDocument(Document, imgMojavez, imgAgahitaasis, imgRoozname, imgSherkatname,
                imgAkharintaaghirat, imgSardarforoshgah, imgFishab, imgFishgaz,
                imgFishbargh, imgFishtelephone, imgSanadNoe);

            return RedirectToPage("Index");
        }


    }
}
