using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Core.Services.Interfaces;

namespace MyShop.Web.Pages.Admin.Operative
{
    public class OperativeContractListModel : PageModel
    {
        private IAgentService _agentService;

        public OperativeContractListModel(IAgentService agentService)
        {
            _agentService = agentService;
        }
        public List<DataLayer.Entities.Contract> Contract { get; set; }
        public void OnGet()
        {
            Contract = _agentService.GetAllOperativeContracts();
        }
    }
}
