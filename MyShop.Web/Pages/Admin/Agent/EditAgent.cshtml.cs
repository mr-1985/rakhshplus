using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
                return Page();

            _agentService.UpdateAgent(Agent);

            return Redirect("/Admin/Agent/EditAgentDocument/" + id);
        }
    }
}
