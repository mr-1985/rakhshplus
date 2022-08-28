using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Core.Services.Interfaces;
using MyShop.DataLayer.Entities;

namespace MyShop.Web.Pages.Admin.Operative
{
    public class AddOperativeDocumentModel : PageModel
    {
        private IAgentService _agentService;

        public AddOperativeDocumentModel(IAgentService agentService)
        {
            _agentService = agentService;
        }

        public OperativeDocument OperativeDocument { get; set; }
        public void OnGet(int id)
        {
            ViewData["OperativeId"] = id;

            OperativeDocument = _agentService.GetOperativeDocumentByOperativeId(id);
        }
    }
}
