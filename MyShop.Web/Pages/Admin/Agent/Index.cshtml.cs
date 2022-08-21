using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Core.Services.Interfaces;

namespace MyShop.Web.Pages.Admin.Agent
{
    public class IndexModel : PageModel
    {
        private IAgentService _agentService;

        public IndexModel(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [BindProperty]
        public List<DataLayer.Entities.Agent> Agent { get; set; }

        public void OnGet()
        {
            Agent = _agentService.GetAllGent();
        }
    }
}
