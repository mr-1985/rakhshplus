using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Core.Services.Interfaces;
using MyShop.DataLayer.Entities;

namespace MyShop.Web.Pages.Admin.Operative
{
    public class ShowOperativeDocumentsModel : PageModel
    {
        private IAgentService _agentService;

        public ShowOperativeDocumentsModel(IAgentService agentService)
        {
            _agentService = agentService;
        }

        public OperativeDocument Document { get; set; }
        public void OnGet(int id)
        {
            Document = _agentService.GetOperativeDocumentByOperativeId(id);
        }
    }
}
