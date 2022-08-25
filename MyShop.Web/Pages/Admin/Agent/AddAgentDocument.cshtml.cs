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

        
        public AgentDocument Document { get; set; }
        public void OnGet(int id)
        {
            //Document = new AgentDocument();
            //Document.AgentId = id;

            ViewData["AgentId"] = id;

            ListofDocument = _agentService.GetDocumentByAgentId(id);
        }

    }
}
