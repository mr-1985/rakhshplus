using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _agentService.AddAgent(Agent);
            //return RedirectToPage("Index");

            return Redirect("/Admin/Agent/AddAgentDocument/" + Agent.AgentId);
        }
    }
}
