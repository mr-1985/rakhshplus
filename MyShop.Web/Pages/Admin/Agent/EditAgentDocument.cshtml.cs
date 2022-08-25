using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Core.Services.Interfaces;
using MyShop.DataLayer.Entities;

namespace MyShop.Web.Pages.Admin.Agent
{
    public class EditAgentDocumentModel : PageModel
    {
        private IAgentService _agentService;

        public EditAgentDocumentModel(IAgentService agentService)
        {
            _agentService = agentService;
        }

        public AgentDocument Document { get; set; }
        public void OnGet(int id)
        {
            //Document = new AgentDocument();
            //Document.AgentId = id;

            ViewData["AgentId"] = id;

            Document = _agentService.GetDocumentByAgentId(id);
        }
    }
}
